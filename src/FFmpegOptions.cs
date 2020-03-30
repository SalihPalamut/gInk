using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace gInk
{
    class FFmpegOptions : IDisposable
    {
    
        public const string SourceNone = "None";
        public const string SourceGDIGrab = "GDI grab";
        public const string SourceVideoDevice = "screen-capture-recorder";
        public const string SourceAudioDevice = "virtual-audio-capturer";

        public const int x264_min = 0;
        public const int x264_max = 51;
        public const int x265_min = 0;
        public const int x265_max = 51;
        public const int vp8_min = 4;
        public const int vp8_max = 63;
        public const int vp9_min = 0;
        public const int vp9_max = 63;
        public const int xvid_min = 1;
        public const int xvid_max = 31;
        public const int mp3_min = 0;
        public const int mp3_max = 9;

        public delegate void EncodeStartedEventHandler();
        public event EncodeStartedEventHandler EncodeStarted;

        public delegate void EncodeProgressChangedEventHandler(float percentage);
        public event EncodeProgressChangedEventHandler EncodeProgressChanged;

        // General
        public bool OverrideCLIPath { get; set; } = false;
        public string CLIPath { get; set; } = "";
        public string VideoSource { get; set; } = SourceGDIGrab;
        public string AudioSource { get; set; } = SourceNone;
        public FFmpegVideoCodec VideoCodec { get; set; } = FFmpegVideoCodec.libx264;
        public FFmpegAudioCodec AudioCodec { get; set; } = FFmpegAudioCodec.libvoaacenc;
        public string UserArgs { get; set; } = "";
        public bool UseCustomCommands { get; set; } = false;
        public string CustomCommands { get; set; } = "";
        public bool ShowError { get; set; } = true;

        // Video
        public FFmpegPreset x264_Preset { get; set; } = FFmpegPreset.ultrafast;
        public int x264_CRF { get; set; } = 28;
        public int VPx_bitrate { get; set; } = 3000; // kbit/s
        public int XviD_qscale { get; set; } = 10;
        public FFmpegNVENCPreset NVENC_preset { get; set; } = FFmpegNVENCPreset.llhp;
        public int NVENC_bitrate { get; set; } = 3000; // kbit/s
        public FFmpegPaletteGenStatsMode GIFStatsMode { get; set; } = FFmpegPaletteGenStatsMode.full;
        public FFmpegPaletteUseDither GIFDither { get; set; } = FFmpegPaletteUseDither.sierra2_4a;
        public FFmpegAMFUsage AMF_usage { get; set; } = FFmpegAMFUsage.transcoding;
        public FFmpegAMFQuality AMF_quality { get; set; } = FFmpegAMFQuality.speed;
        public FFmpegQSVPreset QSV_preset { get; set; } = FFmpegQSVPreset.fast;
        public int QSV_bitrate { get; set; } = 3000;
        //WaterMark
        public bool WaterMarkUse { get; set; }
        public int WaterMark_X { get; set; }
        public int WaterMark_Y { get; set; }
        public bool WaterMark_location_Top { get; set; }
        public bool WaterMark_location_Left { get; set; }
        public int WaterMark_Opacity { get; set; }
        // Audio
        public int AAC_bitrate { get; set; } = 128; // kbit/s
        public int Opus_bitrate { get; set; } = 128; //kbit/s
        public int Vorbis_qscale { get; set; } = 3;
        public int MP3_qscale { get; set; } = 4;
        public string Extension
        {
            get
            {
                if (!VideoSource.Equals(SourceNone, StringComparison.InvariantCultureIgnoreCase))
                {
                    switch (VideoCodec)
                    {
                        case FFmpegVideoCodec.libx264:
                        case FFmpegVideoCodec.libx265:
                        case FFmpegVideoCodec.h264_nvenc:
                        case FFmpegVideoCodec.hevc_nvenc:
                        case FFmpegVideoCodec.h264_amf:
                        case FFmpegVideoCodec.hevc_amf:
                        case FFmpegVideoCodec.h264_qsv:
                        case FFmpegVideoCodec.hevc_qsv:
                            return "mp4";
                        case FFmpegVideoCodec.libvpx:
                        case FFmpegVideoCodec.libvpx_vp9:
                            return "webm";
                        case FFmpegVideoCodec.libxvid:
                            return "avi";
                        case FFmpegVideoCodec.gif:
                            return "gif";
                        case FFmpegVideoCodec.libwebp:
                            return "webp";
                        case FFmpegVideoCodec.apng:
                            return "apng";
                    }
                }
                else if (!AudioSource.Equals(SourceNone, StringComparison.InvariantCultureIgnoreCase))
                {
                    switch (AudioCodec)
                    {
                        case FFmpegAudioCodec.libvoaacenc:
                            return "m4a";
                        case FFmpegAudioCodec.libopus:
                            return "opus";
                        case FFmpegAudioCodec.libvorbis:
                            return "ogg";
                        case FFmpegAudioCodec.libmp3lame:
                            return "mp3";
                    }
                }

                return "mp4";
            }
        }

        public bool IsSourceSelected => IsVideoSourceSelected || IsAudioSourceSelected;

        public bool IsVideoSourceSelected => !string.IsNullOrEmpty(VideoSource) && !VideoSource.Equals(SourceNone, StringComparison.InvariantCultureIgnoreCase);

        public bool IsAudioSourceSelected => !string.IsNullOrEmpty(AudioSource) && !AudioSource.Equals(SourceNone, StringComparison.InvariantCultureIgnoreCase) &&
            (!IsVideoSourceSelected || !IsAnimatedImage);

        public bool IsAnimatedImage => VideoCodec == FFmpegVideoCodec.gif || VideoCodec == FFmpegVideoCodec.libwebp || VideoCodec == FFmpegVideoCodec.apng;

        public bool IsEvenSizeRequired => !IsAnimatedImage;
        public void save()
        {
            lock (this)
            {

                string tempFilePath = Directory.GetCurrentDirectory() + "\\a.json";

                using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.ContractResolver = new WritablePropertiesOnlyResolver();
                    serializer.Converters.Add(new StringEnumConverter());
                    serializer.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonWriter, this);
                    jsonWriter.Flush();
                }

            }
        }

        public void Dispose()
        {
            
        }
        [JsonConstructor]
        public FFmpegOptions(bool a = true)
        {
            CaptureArea = new CaptureArea();
        }
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
   


        private CaptureArea getScreenSize()
        {
            CaptureArea ret = new CaptureArea();
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr screenDc = g.GetHdc();
            const int DESKTOPHORZRES = 118;
            const int DESKTOPVERTRES = 117;
            ret.Width = GetDeviceCaps(screenDc, DESKTOPHORZRES);
            ret.Height = GetDeviceCaps(screenDc, DESKTOPVERTRES);
            
            return ret;
        }
        public FFmpegOptions()
        {

          

            string tempFilePath = Directory.GetCurrentDirectory() + "\\a.json";
            if (!File.Exists(tempFilePath))
            {

                CaptureArea = getScreenSize();
                save();
                //return;
            }

            using (StreamReader streamReader = new StreamReader(tempFilePath))
            using (FFmpegOptions options = JsonConvert.DeserializeObject<FFmpegOptions>(streamReader.ReadToEnd()))
            {
                foreach (var property in typeof(FFmpegOptions).GetProperties())
                {
                    try
                    {
                        property.SetValue(this, property.GetValue(options));
                    } catch { }
                }
            }
            if (OutputPath == null) OutputPath = "output";
            if ((CaptureArea.Width  | CaptureArea.Height)==0)
                CaptureArea = getScreenSize();
        }
        public string OutputPath { get; set; }= "output";
        public string InputPath { get; set; }
        public float Duration { get; set; }
        public bool IsRecording=true, DrawCursor=true, IsLossless=false;
        public int FPS { get; set; } = 30;
        public CaptureArea CaptureArea { get; set; } 
        
        public string GetFFmpegArgs(bool isCustom = false)
        {
            if (IsRecording && !IsVideoSourceSelected && !IsAudioSourceSelected)
            {
                return null;
            }

            StringBuilder args = new StringBuilder();
            args.Append("-rtbufsize 150M "); // default real time buffer size was 3041280 (3M)

            string fps;

            if (isCustom)
            {
                fps = "$fps$";
            }
            else
            {
                fps = FPS.ToString();
            }

            if (IsRecording)
            {
                if (IsVideoSourceSelected)
                {
                    if (VideoSource.Equals(SourceGDIGrab, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // http://ffmpeg.org/ffmpeg-devices.html#gdigrab
                        args.AppendFormat("-f gdigrab -framerate {0} -offset_x {1} -offset_y {2} -video_size {3}x{4} -draw_mouse {5} -i desktop ",
                            fps, isCustom ? "$area_x$" : CaptureArea.X.ToString(), isCustom ? "$area_y$" : CaptureArea.Y.ToString(),
                            isCustom ? "$area_width$" : CaptureArea.Width.ToString(), isCustom ? "$area_height$" : CaptureArea.Height.ToString(),
                            isCustom ? "$cursor$" : DrawCursor ? "1" : "0");
                    }
                    else
                    {
                        args.AppendFormat("-f dshow -framerate {0} -i video=\"{1}\" ", fps, VideoSource);
                    }
                    //https://stackoverflow.com/questions/10918907/how-to-add-transparent-watermark-in-center-of-a-video-with-ffmpeg
                    //https://stackoverflow.com/questions/47989621/ffmpeg-add-watermark-libx264-width-not-divisible-by-2-853x480
                    //https://stackoverflow.com/questions/44568887/ffmpeg-overlay-image-and-lower-transparency
                    if (WaterMarkUse)
                    {
                        string set_watermark = " -i Logo.png -filter_complex [0]scale='iw-mod(iw,2)':'ih-mod(ih,2)'[a];[1]format=argb,colorchannelmixer=aa=";
                        set_watermark += (WaterMark_Opacity / 100.0).ToString().Replace(",", ".") + "[b];[a][b]\"overlay=";
                        if (WaterMark_location_Top)
                        {
                            if (WaterMark_location_Left)
                                set_watermark += WaterMark_X.ToString() + ":" + WaterMark_Y.ToString();
                            else
                                set_watermark += "W-w-" + WaterMark_X.ToString() + ":" + WaterMark_Y.ToString();
                        }
                        else
                        {
                            if (WaterMark_location_Left)
                                set_watermark += WaterMark_X.ToString() + ":H-h-" + WaterMark_Y.ToString();
                            else
                                set_watermark += "W-w-" + WaterMark_X.ToString() + ":H-h-" + WaterMark_Y.ToString();

                        }
                        set_watermark += "\" ";
                        args.Append(set_watermark);
                    }
                    if (IsAudioSourceSelected)
                    {
                        args.AppendFormat("-f dshow -i audio=\"{0}\" ", AudioSource);
                    }
                }
                else if (IsAudioSourceSelected)
                {
                    args.AppendFormat("-f dshow -i audio=\"{0}\" ", AudioSource);
                }
            }
            else
            {
                args.Append($"-i \"{InputPath}\" ");
            }

            if (!string.IsNullOrEmpty(UserArgs))
            {
                args.Append(UserArgs + " ");
            }

            if (IsVideoSourceSelected)
            {
                if (IsLossless || VideoCodec != FFmpegVideoCodec.apng)
                {
                    string videoCodec;

                    if (IsLossless)
                    {
                        videoCodec = FFmpegVideoCodec.libx264.ToString();
                    }
                    else if (VideoCodec == FFmpegVideoCodec.libvpx_vp9)
                    {
                        videoCodec = "libvpx-vp9";
                    }
                    else
                    {
                        videoCodec = VideoCodec.ToString();
                    }

                    args.AppendFormat("-c:v {0} ", videoCodec);
                    args.AppendFormat("-r {0} ", fps); // output FPS
                }

                if (IsLossless)
                {
                    args.AppendFormat("-preset {0} ", FFmpegPreset.ultrafast);
                    args.AppendFormat("-tune {0} ", FFmpegTune.zerolatency);
                    args.AppendFormat("-qp {0} ", 0);
                }
                else
                {
                    switch (VideoCodec)
                    {
                        case FFmpegVideoCodec.libx264: // https://trac.ffmpeg.org/wiki/Encode/H.264
                        case FFmpegVideoCodec.libx265: // https://trac.ffmpeg.org/wiki/Encode/H.265
                            args.AppendFormat("-preset {0} ", x264_Preset);
                            if (IsRecording) args.AppendFormat("-tune {0} ", FFmpegTune.zerolatency);
                            args.AppendFormat("-crf {0} ", x264_CRF);
                            args.AppendFormat("-pix_fmt {0} ", "yuv420p"); // -pix_fmt yuv420p required otherwise can't stream in Chrome
                            args.AppendFormat("-movflags {0} ", "+faststart"); // This will move some information to the beginning of your file and allow the video to begin playing before it is completely downloaded by the viewer
                            break;
                        case FFmpegVideoCodec.libvpx: // https://trac.ffmpeg.org/wiki/Encode/VP8
                        case FFmpegVideoCodec.libvpx_vp9: // https://trac.ffmpeg.org/wiki/Encode/VP9
                            if (IsRecording) args.AppendFormat("-deadline {0} ", "realtime");
                            args.AppendFormat("-b:v {0}k ", VPx_bitrate);
                            args.AppendFormat("-pix_fmt {0} ", "yuv420p"); // -pix_fmt yuv420p required otherwise causing issues in Chrome related to WebM transparency support
                            break;
                        case FFmpegVideoCodec.libxvid: // https://trac.ffmpeg.org/wiki/Encode/MPEG-4
                            args.AppendFormat("-qscale:v {0} ", XviD_qscale);
                            break;
                        case FFmpegVideoCodec.h264_nvenc: // https://trac.ffmpeg.org/wiki/HWAccelIntro#NVENC
                        case FFmpegVideoCodec.hevc_nvenc:
                            args.AppendFormat("-preset {0} ", NVENC_preset);
                            args.AppendFormat("-b:v {0}k ", NVENC_bitrate);
                            args.AppendFormat("-pix_fmt {0} ", "yuv420p");
                            break;
                        case FFmpegVideoCodec.h264_amf:
                        case FFmpegVideoCodec.hevc_amf:
                            args.AppendFormat("-usage {0} ", AMF_usage);
                            args.AppendFormat("-quality {0} ", AMF_quality);
                            args.AppendFormat("-pix_fmt {0} ", "yuv420p");
                            break;
                        case FFmpegVideoCodec.h264_qsv: // https://trac.ffmpeg.org/wiki/Hardware/QuickSync
                        case FFmpegVideoCodec.hevc_qsv:
                            args.AppendFormat("-preset {0} ", QSV_preset);
                            args.AppendFormat("-b:v {0}k ", QSV_bitrate);
                            break;
                        case FFmpegVideoCodec.libwebp: // https://www.ffmpeg.org/ffmpeg-codecs.html#libwebp
                            args.AppendFormat("-lossless {0} ", "0");
                            args.AppendFormat("-preset {0} ", "default");
                            args.AppendFormat("-loop {0} ", "0");
                            break;
                        case FFmpegVideoCodec.apng:
                            args.Append("-f apng ");
                            args.AppendFormat("-plays {0} ", "0");
                            break;
                    }
                }
            }

            if (IsAudioSourceSelected)
            {
                switch (AudioCodec)
                {
                    case FFmpegAudioCodec.libvoaacenc: // http://trac.ffmpeg.org/wiki/Encode/AAC
                        args.AppendFormat("-c:a aac -ac 2 -b:a {0}k ", AAC_bitrate); // -ac 2 required otherwise failing with 7.1
                        break;
                    case FFmpegAudioCodec.libopus: // https://www.ffmpeg.org/ffmpeg-codecs.html#libopus-1
                        args.AppendFormat("-c:a libopus -b:a {0}k ", Opus_bitrate);
                        break;
                    case FFmpegAudioCodec.libvorbis: // http://trac.ffmpeg.org/wiki/TheoraVorbisEncodingGuide
                        args.AppendFormat("-c:a libvorbis -qscale:a {0} ", Vorbis_qscale);
                        break;
                    case FFmpegAudioCodec.libmp3lame: // http://trac.ffmpeg.org/wiki/Encode/MP3
                        args.AppendFormat("-c:a libmp3lame -qscale:a {0} ", MP3_qscale);
                        break;
                }
            }

            if (Duration > 0)
            {
                args.AppendFormat("-t {0} ", isCustom ? "$duration$" : Duration.ToString("0.0", CultureInfo.InvariantCulture)); // duration limit
            }

            args.Append("-y "); // overwrite file

            string output;

            if (isCustom)
            {
                output = "$output$";
            }
            else
            {
                output = Path.ChangeExtension(OutputPath, IsLossless ? "mp4" : Extension);
            }

            args.AppendFormat("\"{0}\"", output);
            CustomCommands = args.ToString();
            return CustomCommands;
        }

    }

    public class CaptureArea
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CaptureArea(int x = 0, int y=0, int width=0, int height=0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    internal class WritablePropertiesOnlyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p.Writable).ToList();
        }
    }
}
