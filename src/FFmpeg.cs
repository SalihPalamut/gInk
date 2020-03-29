using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gInk
{
    public class DirectShowDevices
    {
        public List<string> VideoDevices = new List<string>();
        public List<string> AudioDevices = new List<string>();
    }
    public  class FFmpeg : IDisposable
    {
        public event DataReceivedEventHandler DataReceived;
     
        protected Process process;
        public int ExtCode { get; private set; }
        public bool IsProcessRunning { get; private set; }
        public StringBuilder OutputData { get; private set; }
   
        string FFmpeg_path;
        public FFmpeg()
        {
            OutputData = new StringBuilder();
           
            FFmpeg_path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            FFmpeg_path += @"\Local\gInk\";
        }
        public void Dispose()
        {
            if (process != null)
            {
                process.Dispose();
            }
        }

        public virtual int Open(string args = null,string program="ffmpeg.exe")
        {
            OutputData.Clear();
           program= FFmpeg_path+program;


                if (File.Exists(program))
            {
                using (process = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = program,
                        WorkingDirectory = Path.GetDirectoryName(program),
                        Arguments = args,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    };

                    process.EnableRaisingEvents = true;
                    if (psi.RedirectStandardOutput) process.OutputDataReceived += cli_DataReceived;
                    if (psi.RedirectStandardError) process.ErrorDataReceived += cli_DataReceived;
                    process.StartInfo = psi;

                    process.Start();

                    if (psi.RedirectStandardOutput) process.BeginOutputReadLine();
                    if (psi.RedirectStandardError) process.BeginErrorReadLine();

                    try
                    {
                        IsProcessRunning = true;
                        process.WaitForExit();
                    }
                    finally
                    {
                        IsProcessRunning = false;
                    }
                    ExtCode = process.ExitCode;
                    return ExtCode;
                }
            }

            return -1;
        }
  

        private void cli_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                OutputData.AppendLine(e.Data);
                if (DataReceived != null)
                {
                    DataReceived(sender, e);
                }
            }
        }

        public DirectShowDevices GetDirectShowDevices() 
        {
            DirectShowDevices devices=new DirectShowDevices();
            Open("-list_devices true -f dshow -i dummy");
            while (IsProcessRunning) ;
            string types = "DirectShow video devices(.*)DirectShow audio devices(.*)";
            string names = "\\[dshow.*\\]\\s*\"(.*)\".*\n";
            Regex Rtypes = new Regex(types, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);
            Regex Rnames = new Regex(names, RegexOptions.Compiled | RegexOptions.CultureInvariant);
            Match match = Rtypes.Match(OutputData.ToString());
            if (match.Success)
            {
                Match match2 = Rnames.Match(match.Groups[1].Value);
                while (match2.Success)
                {
                    devices.VideoDevices.Add( match2.Groups[1].Value);
                    match2 = match2.NextMatch();
                }
                match2 = Rnames.Match(match.Groups[2].Value);
                while (match2.Success)
                {
                    devices.AudioDevices.Add(match2.Groups[1].Value);
                    match2 = match2.NextMatch();
                }
            }
            return devices;
        }
        public void test_commands(string cmd)
        {
            StringBuilder create_command=new StringBuilder();
            int time = 3;
            create_command.AppendFormat("-t 00:00:0{0} -c", time);
            cmd=cmd.Replace("-c", create_command.ToString());
            Open(cmd);
            while (IsProcessRunning);

            if (ExtCode == 1)
            {
                ErrorDump(cmd);
            }
            else
            {
                string title = "Ön İzleme";
                create_command.Clear();
                create_command.AppendFormat(" -window_title \"{0}\"",title);
                cmd = "-autoexit -i output.mp4 -x 720 -y 480 -volume 100" + create_command.ToString();
                Open(cmd, "ffplay.exe");
            }            
        }
        public string ErrorDump(string cmd)
        {
            string ret = "";
            try
            {
                using (Process process = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        WorkingDirectory = Path.GetDirectoryName(FFmpeg_path),
                        Arguments = $"/k {"ffmpeg.exe"} {cmd}",
                        UseShellExecute = true
                    };

                    process.StartInfo = psi;
                    process.Start();
                }
                ret = "Ok";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
    }
}
