using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gInk
{

    public partial class FormOptions : Form
    {
        public Root Root;

        Label[] lbPens = new Label[10];
        CheckBox[] cbPens = new CheckBox[10];
        PictureBox[] pboxPens = new PictureBox[10];
        ComboBox[] comboPensAlpha = new ComboBox[10];
        ComboBox[] comboPensWidth = new ComboBox[10];
        Label lbcbPens, lbpboxPens, lbcomboPensAlpha, lbcomboPensWidth;

        Label[] lbHotkeyPens = new Label[10];
        HotkeyInputBox[] hiPens = new HotkeyInputBox[10];
        private bool settingsLoaded = false;
        public FormOptions(Root root)
        {
            Root = root;
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {

            Root.UnsetHotkey();

            if (Root.EraserEnabled)
                cbEraserEnabled.Checked = true;
            if (Root.PointerEnabled)
                cbPointerEnabled.Checked = true;
            if (Root.SnapEnabled)
                cbSnapEnabled.Checked = true;
            if (Root.UndoEnabled)
                cbUndoEnabled.Checked = true;
            if (Root.ClearEnabled)
                cbClearEnabled.Checked = true;
            if (Root.PenWidthEnabled)
                cbWidthEnabled.Checked = true;
            if (Root.PanEnabled)
                cbPanEnabled.Checked = true;
            if (Root.InkVisibleEnabled)
                cbInkVisibleEnabled.Checked = true;

            if (Root.WhiteTrayIcon)
                cbWhiteIcon.Checked = true;
            if (Root.AllowDraggingToolbar)
                cbAllowDragging.Checked = true;
            if (Root.AllowHotkeyInPointerMode)
                cbAllowHotkeyInPointer.Checked = true;

            comboCanvasCursor.SelectedIndex = Root.CanvasCursor;

            tbSnapPath.Text = Root.SnapshotBasePath;

            lbNote.ForeColor = Color.Black;

            lbcbPens = new Label();
            lbcbPens.Left = 25;
            lbcbPens.Width = 100;
            lbcbPens.Top = 15;

            tabPage2.Controls.Add(lbcbPens);
            lbpboxPens = new Label();
            lbpboxPens.Left = 140;
            lbpboxPens.Width = 60;
            lbpboxPens.Top = 15;

            tabPage2.Controls.Add(lbpboxPens);
            lbcomboPensAlpha = new Label();
            lbcomboPensAlpha.Left = 200;
            lbcomboPensAlpha.Width = 100;
            lbcomboPensAlpha.Top = 15;

            tabPage2.Controls.Add(lbcomboPensAlpha);
            lbcomboPensWidth = new Label();
            lbcomboPensWidth.Left = 325;
            lbcomboPensWidth.Width = 100;
            lbcomboPensWidth.Top = 15;

            tabPage2.Controls.Add(lbcomboPensWidth);

            for (int p = 0; p < Root.MaxPenCount; p++)
            {
                int top = p * 32 + 40;
                lbPens[p] = new Label();
                lbPens[p].Left = 60;
                lbPens[p].Width = 80;
                lbPens[p].Top = top;

                cbPens[p] = new CheckBox();
                cbPens[p].Left = 30;
                cbPens[p].Width = 15;
                cbPens[p].Top = top - 5;
                cbPens[p].Text = "";
                cbPens[p].Checked = Root.PenEnabled[p];
                cbPens[p].CheckedChanged += cbPens_CheckedChanged;

                pboxPens[p] = new PictureBox();
                pboxPens[p].Left = 145;
                pboxPens[p].Top = top;
                pboxPens[p].Width = 15;
                pboxPens[p].Height = 15;
                pboxPens[p].BackColor = Root.PenAttr[p].Color;
                pboxPens[p].Click += pboxPens_Click;

                comboPensAlpha[p] = new ComboBox();

                comboPensAlpha[p].Left = 205;
                comboPensAlpha[p].Top = top - 2;
                comboPensAlpha[p].Width = 100;
                comboPensAlpha[p].Text = (255 - Root.PenAttr[p].Transparency).ToString();
                comboPensAlpha[p].TextChanged += comboPensAlpha_TextChanged;

                comboPensWidth[p] = new ComboBox();

                comboPensWidth[p].Left = 330;
                comboPensWidth[p].Top = top - 2;
                comboPensWidth[p].Width = 100;
                comboPensWidth[p].Text = ((int)Root.PenAttr[p].Width).ToString();
                comboPensWidth[p].TextChanged += comboPensWidth_TextChanged;

                tabPage2.Controls.Add(lbPens[p]);
                tabPage2.Controls.Add(cbPens[p]);
                tabPage2.Controls.Add(pboxPens[p]);
                tabPage2.Controls.Add(comboPensAlpha[p]);
                tabPage2.Controls.Add(comboPensWidth[p]);
            }

            for (int p = 0; p < Root.MaxPenCount; p++)
            {
                int top = p * 25 + 120;
                lbHotkeyPens[p] = new Label();
                lbHotkeyPens[p].Left = 20;
                lbHotkeyPens[p].Width = 80;
                lbHotkeyPens[p].Top = top;

                hiPens[p] = new HotkeyInputBox();
                hiPens[p].Hotkey = Root.Hotkey_Pens[p];
                hiPens[p].Left = 100;
                hiPens[p].Width = 120;
                hiPens[p].Top = top;
                hiPens[p].OnHotkeyChanged += hi_OnHotkeyChanged;

                tabPage3.Controls.Add(lbHotkeyPens[p]);
                tabPage3.Controls.Add(hiPens[p]);
            }

            hiGlobal.Hotkey = Root.Hotkey_Global;
            hiEraser.Hotkey = Root.Hotkey_Eraser;
            hiPan.Hotkey = Root.Hotkey_Pan;
            hiInkVisible.Hotkey = Root.Hotkey_InkVisible;
            hiPointer.Hotkey = Root.Hotkey_Pointer;
            hiSnapshot.Hotkey = Root.Hotkey_Snap;
            hiUndo.Hotkey = Root.Hotkey_Undo;
            hiRedo.Hotkey = Root.Hotkey_Redo;
            hiClear.Hotkey = Root.Hotkey_Clear;

            FormOptions_LocalReload();

        }

        private void FormOptions_LocalReload()
        {
            this.Text = Root.Local.MenuEntryOptions + " - gInk";
            tabControl1.TabPages[0].Text = Root.Local.OptionsTabGeneral;
            tabControl1.TabPages[1].Text = Root.Local.OptionsTabPens;
            tabControl1.TabPages[2].Text = Root.Local.OptionsTabHotkeys;
            this.lbLanguage.Text = Root.Local.OptionsGeneralLanguage;
            this.lbCanvascursor.Text = Root.Local.OptionsGeneralCanvascursor;
            this.lbSnapshotsavepath.Text = Root.Local.OptionsGeneralSnapshotsavepath;
            this.cbWhiteIcon.Text = Root.Local.OptionsGeneralWhitetrayicon;
            this.cbAllowDragging.Text = Root.Local.OptionsGeneralAllowdragging;
            this.lbNote.Text = Root.Local.OptionsGeneralNotePenwidth;

            this.lbHkClear.Text = Root.Local.ButtonNameClear;
            this.lbHkEraser.Text = Root.Local.ButtonNameErasor;
            this.lbHkInkVisible.Text = Root.Local.ButtonNameInkVisible;
            this.lbHkPan.Text = Root.Local.ButtonNamePan;
            this.lbHkPointer.Text = Root.Local.ButtonNameMousePointer;
            this.lbHkRedo.Text = Root.Local.ButtonNameRedo;
            this.lbHkSnapshot.Text = Root.Local.ButtonNameSnapshot;
            this.lbHkUndo.Text = Root.Local.ButtonNameUndo;
            this.lbGlobalHotkey.Text = Root.Local.OptionsHotkeysglobal;
            this.cbAllowHotkeyInPointer.Text = Root.Local.OptionsHotkeysEnableinpointer;

            this.comboCanvasCursor.Items[0] = Root.Local.OptionsGeneralCanvascursorArrow;
            this.comboCanvasCursor.Items[1] = Root.Local.OptionsGeneralCanvascursorPentip;


            for (int p = 0; p < Root.MaxPenCount; p++)
            {
                comboPensAlpha[p].Items.Clear();
                comboPensWidth[p].Items.Clear();
                comboPensAlpha[p].Items.AddRange(new object[] { Root.Local.OptionsPensPencil, Root.Local.OptionsPensHighlighter });
                comboPensWidth[p].Items.AddRange(new object[] { Root.Local.OptionsPensThin, Root.Local.OptionsPensNormal, Root.Local.OptionsPensThick });

                lbPens[p].Text = Root.Local.ButtonNamePen[p];
                lbHotkeyPens[p].Text = Root.Local.ButtonNamePen[p];

                lbcbPens.Text = Root.Local.OptionsPensShow;
                lbpboxPens.Text = Root.Local.OptionsPensColor;
                lbcomboPensAlpha.Text = Root.Local.OptionsPensAlpha;
                lbcomboPensWidth.Text = Root.Local.OptionsPensWidth;
            }

            comboLanguage.Items.Clear();
            List<string> langs = Root.Local.GetLanguagenames();
            foreach (string languagename in langs)
            {
                comboLanguage.Items.Add(languagename);
            }

            string ln = Root.Local.GetLanguagenameByFilename(Root.Local.CurrentLanguageFile);
            if (comboLanguage.Items.Contains(ln))
                comboLanguage.SelectedIndex = comboLanguage.Items.IndexOf(ln);
        }

        private void comboPensAlpha_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < Root.MaxPenCount; p++)
                if ((ComboBox)sender == comboPensAlpha[p])
                {
                    byte o;
                    if (byte.TryParse(comboPensAlpha[p].Text, out o) && o >= 0 && o <= 255)
                    {
                        Root.PenAttr[p].Transparency = (byte)(255 - o);
                        comboPensAlpha[p].BackColor = Color.White;
                    }
                    else
                    {
                        comboPensAlpha[p].BackColor = Color.IndianRed;
                    }
                }
        }

        private void comboPensWidth_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < Root.MaxPenCount; p++)
                if ((ComboBox)sender == comboPensWidth[p])
                {
                    int o;
                    if (int.TryParse(comboPensWidth[p].Text, out o) && o >= 30 && o <= 3000)
                    {
                        Root.PenAttr[p].Width = o;
                        comboPensWidth[p].BackColor = Color.White;
                    }
                    else
                    {
                        comboPensWidth[p].BackColor = Color.IndianRed;
                    }
                }
        }

        private void pboxPens_Click(object sender, EventArgs e)
        {
            for (int p = 0; p < Root.MaxPenCount; p++)
                if ((PictureBox)sender == pboxPens[p])
                {
                    colorDialog1.Color = Root.PenAttr[p].Color;
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Root.PenAttr[p].Color = colorDialog1.Color;
                        pboxPens[p].BackColor = colorDialog1.Color;
                    }
                }
        }

        private void cbPens_CheckedChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < Root.MaxPenCount; p++)
                if ((CheckBox)sender == cbPens[p])
                    Root.PenEnabled[p] = cbPens[p].Checked;
        }

        private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Root.SetHotkey();

            Root.SaveOptions("pens.ini");
            Root.SaveOptions("config.ini");
            Root.SaveOptions("hotkeys.ini");
            if (settingsLoaded)
            Options.save();

        }

        private void cbWidthEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.PenWidthEnabled = cbWidthEnabled.Checked;
            lbNote.ForeColor = Color.Red;
        }

        private void cbEraserEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.EraserEnabled = cbEraserEnabled.Checked;
        }

        private void cbPointerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.PointerEnabled = cbPointerEnabled.Checked;
        }

        private void cbSnapEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.SnapEnabled = cbSnapEnabled.Checked;
        }

        private void cbUndoEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.UndoEnabled = cbUndoEnabled.Checked;
        }

        private void cbClearEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.ClearEnabled = cbClearEnabled.Checked;
        }

        private void cbPanEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.PanEnabled = cbPanEnabled.Checked;
        }

        private void cbInkVisibleEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Root.InkVisibleEnabled = cbInkVisibleEnabled.Checked;
        }

       

        private void btSnapPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Root.SnapshotBasePath;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
            {
                tbSnapPath.Text = folderBrowserDialog1.SelectedPath;
                Root.SnapshotBasePath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void tbSnapPath_ModifiedChanged(object sender, EventArgs e)
        {
            Root.SnapshotBasePath = tbSnapPath.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int p = 0; p < Root.MaxPenCount; p++)
            {
                if (comboPensWidth[p].Text == Root.Local.OptionsPensThin)
                {
                    comboPensWidth[p].Text = "30";
                }
                else if (comboPensWidth[p].Text == Root.Local.OptionsPensNormal)
                {
                    comboPensWidth[p].Text = "80";
                }
                else if (comboPensWidth[p].Text == Root.Local.OptionsPensThick)
                {
                    comboPensWidth[p].Text = "500";
                }

                if (comboPensAlpha[p].Text == Root.Local.OptionsPensPencil)
                {
                    comboPensAlpha[p].Text = "255";
                }
                else if (comboPensAlpha[p].Text == Root.Local.OptionsPensHighlighter)
                {
                    comboPensAlpha[p].Text = "80";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Root.CanvasCursor = comboCanvasCursor.SelectedIndex;
        }

        private void cbAllowDragging_CheckedChanged(object sender, EventArgs e)
        {
            Root.AllowDraggingToolbar = cbAllowDragging.Checked;
        }
        public static bool Is64Bit()
        {

            return IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor());
        }

        private static bool Is32BitProcessOn64BitProcessor()
        {
            bool retVal;
            IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);
            return retVal;
        }
        string gInk_path;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;
            work.RunWorkerAsync();
        }
        string DownloadLocation = Path.GetTempPath() + "ffmpeg.zip";
        private void ThrowEvent(EventHandler eventHandler)
        {
            work.ReportProgress(0, eventHandler);
        }
        private void Download(object sender, DoWorkEventArgs e)
        {
            if (File.Exists(DownloadLocation))
            {
                work.ReportProgress(-1, 100);
                work.ReportProgress(100);
                return;
            }
            string url = string.Format("https://ffmpeg.zeranoe.com/builds/{0}/static/ffmpeg-latest-{0}-static.zip", system_type);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "gInk";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    long FileSize = response.ContentLength;
                    long DownloadedSize = 0;
                    int bytesRead = 0;
                    if (FileSize > 0)
                    {
                        work.ReportProgress(-1, FileSize);
                        byte[] buffer = new byte[(int)Math.Min(10240, FileSize)];
                        using (FileStream fs = new FileStream(DownloadLocation, FileMode.Create, FileAccess.Write, FileShare.Read))
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            while (DownloadedSize < FileSize)
                            {
                                bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, bytesRead);
                                DownloadedSize += bytesRead;
                                work.ReportProgress(bytesRead);
                            }
                            fs.Close();
                        }
                    }
                }
            }
            catch (Exception el)
            {
                MessageBox.Show("Error", "Not Downloading" + el);
            }
        }
        private void cbAllowHotkeyInPointer_CheckedChanged(object sender, EventArgs e)
        {
            Root.AllowHotkeyInPointerMode = cbAllowHotkeyInPointer.Checked;
        }
        BackgroundWorker work;
        ProgressBar progressBar1;
        string system_type, TempPath;
        private string logo;
        FFmpegOptions Options;

        private void load_ffmpeg_settings()
        {
            settingsLoaded = false;

            btnRefreshSources.PerformClick();
            cboVideoCodec.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegVideoCodec>());
            cboAudioCodec.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegAudioCodec>());
            cbx264Preset.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegPreset>());
            cbGIFStatsMode.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegPaletteGenStatsMode>());
            cbNVENCPreset.Items.AddRange(EnumExtensions.GetEnums<FFmpegNVENCPreset>().Select(x => $"{x} ({x.GetDescription()})").ToArray());
            cbGIFDither.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegPaletteUseDither>());
            cbAMFUsage.Items.AddRange(EnumExtensions.GetEnums<FFmpegAMFUsage>().Select(x => $"{x} ({x.GetDescription()})").ToArray());
            cbAMFQuality.Items.AddRange(EnumExtensions.GetEnums<FFmpegAMFQuality>().Select(x => $"{x} ({x.GetDescription()})").ToArray());
            cbQSVPreset.Items.AddRange(EnumExtensions.GetEnumDescriptions<FFmpegQSVPreset>());

            Options = new FFmpegOptions();




            cboVideoSource.SelectedIndex = cboVideoSource.Items.IndexOf(Options.VideoSource);


            cboAudioSource.SelectedIndex = cboAudioSource.Items.IndexOf(Options.AudioSource);



            cboVideoCodec.SelectedIndex = (int)Options.VideoCodec;
            cboAudioCodec.SelectedIndex = (int)Options.AudioCodec;

            tbUserArgs.Text = Options.UserArgs;

            // x264
            nudx264CRF.Value = (Options.x264_CRF);
            cbx264Preset.SelectedIndex = (int)Options.x264_Preset;

            // VPx
            nudVP8Bitrate.Value = (Options.VPx_bitrate);

            // Xvid
            nudXvidQscale.Value = (Options.XviD_qscale);

            // NVENC
            nudNVENCBitrate.Value = (Options.NVENC_bitrate);
            cbNVENCPreset.SelectedIndex = (int)Options.NVENC_preset;

            // GIF
            cbGIFStatsMode.SelectedIndex = (int)Options.GIFStatsMode;
            cbGIFDither.SelectedIndex = (int)Options.GIFDither;

            // AMF
            cbAMFUsage.SelectedIndex = (int)Options.AMF_usage;
            cbAMFQuality.SelectedIndex = (int)Options.AMF_quality;

            // QuickSync
            nudQSVBitrate.Value = (Options.QSV_bitrate);
            cbQSVPreset.SelectedIndex = (int)Options.QSV_preset;

            // AAC
            tbAACBitrate.Value = Options.AAC_bitrate / 32;

            // Vorbis
            tbVorbis_qscale.Value = Options.Vorbis_qscale;

            // MP3
            tbMP3_qscale.Value = FFmpegOptions.mp3_max - Options.MP3_qscale;


            watermark_X.Value = Options.WaterMark_X;
            watermark_Y.Value = Options.WaterMark_Y;
            watermark_location_top.Checked = Options.WaterMark_location_Top;
            watermark_location_bottom.Checked = !watermark_location_top.Checked;
            watermark_location_left.Checked = Options.WaterMark_location_Left;
            watermark_location_right.Checked = !Options.WaterMark_location_Left;
            watermark_opacity.Value = Options.WaterMark_Opacity;
            watermark_opacity_text.Text = "%" + watermark_opacity.Value;
            watermark_use.Checked = Options.WaterMarkUse;

            settingsLoaded = true;
            UpdateUI();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Record"])//your specific tabname
            {
                //Environment.SpecialFolder.MyVideos
                TempPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
                gInk_path = TempPath + @"\Local\gInk";
                if (!Directory.Exists(gInk_path))
                    Directory.CreateDirectory(gInk_path);
                if (File.Exists(gInk_path + @"\ffmpeg.exe"))
                    btnDownload.Visible = false;

                ffmpeg_path.Text = @"%USERPROFILE%\AppData\Local\gInk\ffmpeg.exe";

                if (btnDownload.Visible)
                {
                    system_type = (Is64Bit() ? "win64" : "win32");
                    work = new BackgroundWorker();
                    work.WorkerReportsProgress = true;
                    work.DoWork += Download;
                    work.ProgressChanged += worker_ProgressChanged;
                    work.RunWorkerCompleted += worker_RunWorkerCompleted;
                    progressBar1 = new ProgressBar();
                    progressBar1.Dock = DockStyle.Fill;
                    gbFFmpegExe.Controls.Add(progressBar1);
                    ffmpeg_path.Visible = false;
                }

                logo = Path.Combine(gInk_path, "Logo.png");
                if (File.Exists(logo))
                    watermark_show.Image = new Bitmap(logo);
                //read ffmpeg settings

                load_ffmpeg_settings();
            }
        }
        private void watermark_chose_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog Fl = new OpenFileDialog();
            Fl.Filter = "Image Files(*.png)|*.png";
            Fl.FileName = "Logo.png";
            Fl.Title = "Chose Watermark";
            Fl.DefaultExt = ".png";
            if (Fl.ShowDialog() == DialogResult.OK)
            {
                if (watermark_show.Image != null)
                    watermark_show.Image.Dispose();

                File.Copy(Fl.FileName, logo, true);
                watermark_show.Image = new Bitmap(logo);
            }
        }
        private void UpdateUI()
        {
            txtCommandLinePreview.Text = Options.GetFFmpegArgs();
        }
        private void watermark_location_CheckedChanged(object sender, EventArgs e)
        {
            if (settingsLoaded)
            {
                Options.WaterMark_location_Top = watermark_location_top.Checked;
                Options.WaterMark_location_Left = watermark_location_left.Checked;
                Options.WaterMark_X = (int)watermark_X.Value;
                Options.WaterMark_Y = (int)watermark_Y.Value;

                Options.WaterMark_Opacity = watermark_opacity.Value;
                UpdateUI();
            }
            watermark_opacity_text.Text = "%" + watermark_opacity.Value;
        }

        private void watermark_use_CheckedChanged(object sender, EventArgs e)
        {
            watermark_show.Enabled = watermark_use.Checked;
            groupBox1.Enabled = watermark_use.Checked;
            groupBox2.Enabled = watermark_use.Checked;
            groupBox3.Enabled = watermark_use.Checked;
            Options.WaterMarkUse = watermark_use.Checked;
            UpdateUI();
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                progressBar1.Maximum = Convert.ToInt32(e.UserState);
                btnDownload.Text = "% 0";
            }
            else
            {
                progressBar1.Value += e.ProgressPercentage;
                double a, b, c;
                a = progressBar1.Value*100.0;
                b = progressBar1.Maximum;
                c = a / b;
                c=Math.Round(c, 2);
                btnDownload.Text = "% "+c.ToString();
            }
        }

        private void Record_Click(object sender, EventArgs e)
        {

        }


        private async void btnTest_ClickAsync(object sender, EventArgs e)
        {
            btnTest.Enabled = false;
            FFmpeg a = new FFmpeg();
            string al = txtCommandLinePreview.Text;
            Timer b = new Timer();
            b.Interval = 1000;
            btnTest.Text = "5";
            b.Tick += (o,c)=>{
                btnTest.Text=(int.Parse(btnTest.Text) -1).ToString();
                if (btnTest.Text == "0")
                {
                    btnTest.Text = "Test with CMD";
                    btnTest.Enabled = true;
                    b.Stop();
                }
               
            };
            b.Start();
            await Task.Run(() =>
            {
                if (al.Length > 0)
                    a.test_commands(al);
            });
            
        }
    

        private void btnRefreshSources_Click(object sender, EventArgs e)
        {
            btnRefreshSources.Enabled = false;
            FFmpeg a = new FFmpeg();
            DirectShowDevices devs = a.GetDirectShowDevices();
            cboVideoSource.Items.Clear();
            cboVideoSource.Items.Add("None");
            cboVideoSource.Items.Add("GDI grab");
            cboAudioSource.Items.Clear();
            cboAudioSource.Items.Add("None");
            if (devs != null)
            {
                cboVideoSource.Items.AddRange(devs.VideoDevices.ToArray());
                cboAudioSource.Items.AddRange(devs.AudioDevices.ToArray());

            }

            btnRefreshSources.Enabled = true;
        }

        private void cboVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.VideoCodec = (FFmpegVideoCodec)cboVideoCodec.SelectedIndex;

            if (cboVideoCodec.SelectedIndex >= 0)
            {
                switch (Options.VideoCodec)
                {
                    default:
                    case FFmpegVideoCodec.libx264:
                    case FFmpegVideoCodec.libx265:
                        tcFFmpegVideoCodecs.SelectedIndex = 0;
                        break;
                    case FFmpegVideoCodec.libvpx:
                    case FFmpegVideoCodec.libvpx_vp9:
                        tcFFmpegVideoCodecs.SelectedIndex = 1;
                        break;
                    case FFmpegVideoCodec.libxvid:
                        tcFFmpegVideoCodecs.SelectedIndex = 2;
                        break;
                    case FFmpegVideoCodec.h264_nvenc:
                    case FFmpegVideoCodec.hevc_nvenc:
                        tcFFmpegVideoCodecs.SelectedIndex = 3;
                        break;
                    case FFmpegVideoCodec.gif:
                        tcFFmpegVideoCodecs.SelectedIndex = 4;
                        break;
                    case FFmpegVideoCodec.h264_amf:
                    case FFmpegVideoCodec.hevc_amf:
                        tcFFmpegVideoCodecs.SelectedIndex = 5;
                        break;
                    case FFmpegVideoCodec.h264_qsv:
                    case FFmpegVideoCodec.hevc_qsv:
                        tcFFmpegVideoCodecs.SelectedIndex = 6;
                        break;
                }
            }

            UpdateUI();
        }

        private void cboAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.AudioCodec = (FFmpegAudioCodec)cboAudioCodec.SelectedIndex;

            if (cboAudioCodec.SelectedIndex >= 0)
            {
                switch (Options.AudioCodec)
                {
                    default:
                    case FFmpegAudioCodec.libvoaacenc:
                        tcFFmpegAudioCodecs.SelectedIndex = 0;
                        break;
                    case FFmpegAudioCodec.libopus:
                        tcFFmpegAudioCodecs.SelectedIndex = 1;
                        break;
                    case FFmpegAudioCodec.libvorbis:
                        tcFFmpegAudioCodecs.SelectedIndex = 2;
                        break;
                    case FFmpegAudioCodec.libmp3lame:
                        tcFFmpegAudioCodecs.SelectedIndex = 3;
                        break;
                }
            }

            UpdateUI();
        }

        private void nudx264CRF_ValueChanged(object sender, EventArgs e)
        {
            Options.x264_CRF = (int)nudx264CRF.Value;
            UpdateUI();
        }

        private void cbx264Preset_SelectedIndexChanged(object sender, EventArgs e)
        {

            Options.x264_Preset = (FFmpegPreset)cbx264Preset.SelectedIndex;
            UpdateUI();
        }

        private void nudVP8Bitrate_ValueChanged(object sender, EventArgs e)
        {
            Options.VPx_bitrate = (int)nudVP8Bitrate.Value;
            UpdateUI();
        }

        private void nudXvidQscale_ValueChanged(object sender, EventArgs e)
        {
            Options.XviD_qscale = (int)nudXvidQscale.Value;
            UpdateUI();
        }

        private void cbNVENCPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.NVENC_preset = (FFmpegNVENCPreset)cbNVENCPreset.SelectedIndex;
            UpdateUI();
        }

        private void nudNVENCBitrate_ValueChanged(object sender, EventArgs e)
        {
            Options.NVENC_bitrate = (int)nudNVENCBitrate.Value;
            UpdateUI();
        }

        private void cbGIFStatsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.GIFStatsMode = (FFmpegPaletteGenStatsMode)cbGIFStatsMode.SelectedIndex;
            UpdateUI();
        }

        private void cbGIFDither_SelectedIndexChanged(object sender, EventArgs e)
        {

            Options.GIFDither = (FFmpegPaletteUseDither)cbGIFDither.SelectedIndex;
            UpdateUI();
        }

        private void cbAMFUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.AMF_usage = (FFmpegAMFUsage)cbAMFUsage.SelectedIndex;
            UpdateUI();
        }

        private void cbAMFQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.AMF_quality = (FFmpegAMFQuality)cbAMFQuality.SelectedIndex;
            UpdateUI();
        }

        private void cbQSVPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.QSV_preset = (FFmpegQSVPreset)cbQSVPreset.SelectedIndex;
            UpdateUI();
        }

        private void nudQSVBitrate_ValueChanged(object sender, EventArgs e)
        {
            Options.QSV_bitrate = (int)nudQSVBitrate.Value;
            UpdateUI();
        }

        private void tbAACBitrate_ValueChanged(object sender, EventArgs e)
        {
            Options.AAC_bitrate = tbAACBitrate.Value * 32;
            UpdateUI();
        }

        private void tbOpusBirate_ValueChanged(object sender, EventArgs e)
        {
            Options.Opus_bitrate = tbOpusBitrate.Value * 32;
            UpdateUI();
        }

        private void tbVorbis_qscale_ValueChanged(object sender, EventArgs e)
        {
            Options.Vorbis_qscale = tbVorbis_qscale.Value;
            UpdateUI();
        }

        private void tbMP3_qscale_ValueChanged(object sender, EventArgs e)
        {
            Options.MP3_qscale = FFmpegOptions.mp3_max - tbMP3_qscale.Value;
            UpdateUI();
        }

        private void tbUserArgs_TextChanged(object sender, EventArgs e)
        {
            Options.UserArgs = tbUserArgs.Text;
            UpdateUI();
        }

        private void cboVideoSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.VideoSource = cboVideoSource.Text;
            UpdateUI();
        }

        private void cboAudioSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.AudioSource = cboAudioSource.Text;
            UpdateUI();
        }


        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory(DownloadLocation, Path.GetTempPath());
            }
            catch { }
            try
            {
                string copy_location = Path.GetTempPath() + string.Format(@"ffmpeg-latest-{0}-static\bin\", system_type);
                File.Copy(copy_location + "ffplay.exe", gInk_path + @"\ffplay.exe");
                File.Copy(copy_location + "ffmpeg.exe", gInk_path + @"\ffmpeg.exe");
                btnDownload.Visible = false;
                ffmpeg_path.Visible = true;
            }
            catch { }
            gbFFmpegExe.Controls.Remove(progressBar1);
            work.Dispose();
        }
        private void hi_OnHotkeyChanged(object sender, EventArgs e)
        {
            foreach (Control c in tabPage3.Controls)
            {
                if (c.GetType() != typeof(HotkeyInputBox))
                    continue;
                HotkeyInputBox hi = (HotkeyInputBox)c;

                hi.ExternalConflictFlag = false;
                foreach (Control c2 in tabPage3.Controls)
                {
                    if (c2.GetType() != typeof(HotkeyInputBox))
                        continue;
                    if (c == c2)
                        continue;
                    HotkeyInputBox hi2 = (HotkeyInputBox)c2;

                    if (hi.Hotkey.ConflictWith(hi2.Hotkey))
                    {
                        hi.ExternalConflictFlag = true;
                        break;
                    }
                }
            }
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLanguage.Text != Root.Local.GetLanguagenameByFilename(Root.Local.CurrentLanguageFile))
            {
                Root.ChangeLanguage(Root.Local.GetFilenameByLanguagename(comboLanguage.Text));
                FormOptions_LocalReload();
            }
        }
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
    }

}
