using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
namespace gInk
{
    public class Language : IDisposable
    {

        public void Dispose()
        {

        }

        [JsonConstructor]
        public Language(bool a = true)
        {

        }
        public Language(string code)
        {
            ButtonNamePen[0] = "Red";
            ButtonNamePen[1] = "Green";
            ButtonNamePen[2] = "Blue";
            ButtonNamePen[3] = "Colorful";
            ButtonNamePen[4] = "Pen 4";
            ButtonNamePen[5] = "Pen 5";
            ButtonNamePen[6] = "Record";
            ButtonNamePen[7] = "Pen 7";
            ButtonNamePen[8] = "Pen 8";
            ButtonNamePen[9] = "Pen 9";
            StringBuilder SavePath = new StringBuilder();
            SavePath.AppendFormat(Path, code);
            if (!File.Exists(SavePath.ToString()))
                return;
            using (StreamReader streamReader = new StreamReader(SavePath.ToString()))
            using (Language options = JsonConvert.DeserializeObject<Language>(streamReader.ReadToEnd()))
            {
                foreach (var property in typeof(Language).GetProperties())
                {
                    try
                    {
                        property.SetValue(this, property.GetValue(options));
                    }
                    catch { }
                }
            }
          
        }
        public List<string> GetLanguages()
        {
            List<string> Languages = new List<string>();

            DirectoryInfo d = new DirectoryInfo(Path.Replace("{0}.json", ""));
            if (!d.Exists)
                return null;

            FileInfo[] Files = d.GetFiles("*.json");
            foreach (FileInfo file in Files)
            {
                Languages.Add(file.Name.Substring(0, file.Name.Length - 5));
            }
            return Languages;
        }
        public void Create(string code)
        {
            StringBuilder SavePath = new StringBuilder();
            SavePath.AppendFormat(Path, code);
            if (File.Exists(SavePath.ToString())) return;
            lock (this)
            {
                using (FileStream fileStream = new FileStream(SavePath.ToString(), FileMode.Create, FileAccess.Write, FileShare.Read))
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
        internal class WritablePropertiesOnlyResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                return props.Where(p => p.Writable).ToList();
            }
        }
        private string Path = Directory.GetCurrentDirectory() + @"\Languages\{0}.json";
        public string[] ButtonNamePen { get; set; } = new string[10];
        public string ButtonNamePenwidth { get; set; } = "Pen width";
        public string ButtonNameErasor { get; set; } = "Eraser";
        public string ButtonNamePan { get; set; } = "Pan";
        public string ButtonNameMousePointer { get; set; } = "Mouse pointer";
        public string ButtonNameInkVisible { get; set; } = "Ink visible";
        public string ButtonNameSnapshot { get; set; } = "Snapshot";
        public string ButtonNameUndo { get; set; } = "Undo";
        public string ButtonNameRedo { get; set; } = "Redo";
        public string ButtonNameClear { get; set; } = "Clear";
        public string ButtonNameExit { get; set; } = "Exit drawing";
        public string ButtonNameDock { get; set; } = "Dock";
        public string MenuEntryExit { get; set; } = "Exit";
        public string MenuEntryOptions { get; set; } = "Options";
        public string MenuEntryAbout { get; set; } = "About";
        public string OptionsTabGeneral { get; set; } = "General";
        public string OptionsTabPens { get; set; } = "Pens";
        public string OptionsTabHotkeys { get; set; } = "Hotkeys";
        public string OptionsGeneralLanguage { get; set; } = "Language";
        public string OptionsGeneralCanvascursor { get; set; } = "Canvus cursor";
        public string OptionsGeneralCanvascursorArrow { get; set; } = "Arrow";
        public string OptionsGeneralCanvascursorPentip { get; set; } = "Pen tip";
        public string OptionsGeneralSnapshotsavepath { get; set; } = "Snapshot save path";
        public string OptionsGeneralWhitetrayicon { get; set; } = "Use white tray icon";
        public string OptionsGeneralAllowdragging { get; set; } = "Allow dragging toolbar";
        public string OptionsGeneralNotePenwidth { get; set; } = "Note: pen width panel overides each individual pen width settings";
        public string OptionsPensShow { get; set; } = "Show";
        public string OptionsPensColor { get; set; } = "Color";
        public string OptionsPensAlpha { get; set; } = "Alpha";
        public string OptionsPensWidth { get; set; } = "Width";
        public string OptionsPensPencil { get; set; } = "Pencil";
        public string OptionsPensHighlighter { get; set; } = "Highlighter";
        public string OptionsPensThin { get; set; } = "Thin";
        public string OptionsPensNormal { get; set; } = "Normal";
        public string OptionsPensThick { get; set; } = "Thick";
        public string OptionsHotkeysglobal { get; set; } = "Global hotkey (start drawing, switch between mouse pointer and drawing)";
        public string OptionsHotkeysEnableinpointer { get; set; } = "Enable all following hotkeys in mouse pointer mode (may cause a mess)";
        public string NotificationSnapshot { get; set; } = "File saved. Click here to browse snapshots.";
        public string Record { get; set; } = "Recording";
        public string RecordStart { get; set; } = "Start Recording";
        public string RecordStop { get; set; } = "Stop Recording";
        public string ToolbarSize { get; set; } = "Toolbar Size";
        public string LngAdd { get; set; } = "Add";
        public string btnDownload { get; set; } = "Download";
        public string gbFFmpegExe { get; set; } = "FFmpeg Path";
        public string gbSource { get; set; } = "Source";
        public string btnRefreshSources { get; set; } = "Refresh";
        public string lblVideoSource { get; set; } = "Video Source";
        public string lblAudioSource { get; set; } = "Audio Source";
        public string gbCodecs { get; set; } = "Codecs";
        public string lblCodec { get; set; } = "Video Codec";
        public string lblAudioCodec { get; set; } = "Audio Codec";
        public string gbCommandLineArgs { get; set; } = "Additional command line arguments";
        public string WaterMark { get; set; } = "Add Watermark";
        public string watermark_use { get; set; } = "Use Watermark";
        public string setlLocwater { get; set; } = "Set Location";
        public string waterpadd { get; set; } = "Padding";
        public string setopacity { get; set; } = "Set Opacity";
        public string btnTest { get; set; } = "Test with CMD";
    }
}
