namespace gInk
{
	partial class FormOptions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            gInk.Hotkey hotkey1 = new gInk.Hotkey();
            gInk.Hotkey hotkey2 = new gInk.Hotkey();
            gInk.Hotkey hotkey3 = new gInk.Hotkey();
            gInk.Hotkey hotkey4 = new gInk.Hotkey();
            gInk.Hotkey hotkey5 = new gInk.Hotkey();
            gInk.Hotkey hotkey6 = new gInk.Hotkey();
            gInk.Hotkey hotkey7 = new gInk.Hotkey();
            gInk.Hotkey hotkey8 = new gInk.Hotkey();
            gInk.Hotkey hotkey9 = new gInk.Hotkey();
            this.cbEraserEnabled = new System.Windows.Forms.CheckBox();
            this.cbPointerEnabled = new System.Windows.Forms.CheckBox();
            this.cbSnapEnabled = new System.Windows.Forms.CheckBox();
            this.cbUndoEnabled = new System.Windows.Forms.CheckBox();
            this.cbClearEnabled = new System.Windows.Forms.CheckBox();
            this.cbWidthEnabled = new System.Windows.Forms.CheckBox();
            this.cbWhiteIcon = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSnapPath = new System.Windows.Forms.TextBox();
            this.lbSnapshotsavepath = new System.Windows.Forms.Label();
            this.btSnapPath = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbCanvascursor = new System.Windows.Forms.Label();
            this.comboCanvasCursor = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolbar_size = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.cbInkVisibleEnabled = new System.Windows.Forms.CheckBox();
            this.cbPanEnabled = new System.Windows.Forms.CheckBox();
            this.cbAllowDragging = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbAllowHotkeyInPointer = new System.Windows.Forms.CheckBox();
            this.lbHkInkVisible = new System.Windows.Forms.Label();
            this.lbHkSnapshot = new System.Windows.Forms.Label();
            this.lbHkClear = new System.Windows.Forms.Label();
            this.lbHkPan = new System.Windows.Forms.Label();
            this.lbHkPointer = new System.Windows.Forms.Label();
            this.lbHkRedo = new System.Windows.Forms.Label();
            this.lbHkUndo = new System.Windows.Forms.Label();
            this.lbHkEraser = new System.Windows.Forms.Label();
            this.lbGlobalHotkey = new System.Windows.Forms.Label();
            this.Record = new System.Windows.Forms.TabPage();
            this.gbCommandLinePreview = new System.Windows.Forms.GroupBox();
            this.txtCommandLinePreview = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.WaterMark = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.watermark_opacity_text = new System.Windows.Forms.Label();
            this.watermark_opacity = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.watermark_Y = new System.Windows.Forms.NumericUpDown();
            this.watermark_X = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.watermark_location_right = new System.Windows.Forms.RadioButton();
            this.watermark_location_left = new System.Windows.Forms.RadioButton();
            this.watermark_location_top = new System.Windows.Forms.RadioButton();
            this.watermark_location_bottom = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.watermark_show = new System.Windows.Forms.PictureBox();
            this.watermark_use = new System.Windows.Forms.CheckBox();
            this.gbCommandLineArgs = new System.Windows.Forms.GroupBox();
            this.tbUserArgs = new System.Windows.Forms.TextBox();
            this.gbCodecs = new System.Windows.Forms.GroupBox();
            this.pbAudioCodecWarning = new System.Windows.Forms.PictureBox();
            this.cboAudioCodec = new System.Windows.Forms.ComboBox();
            this.lblAudioCodec = new System.Windows.Forms.Label();
            this.cboVideoCodec = new System.Windows.Forms.ComboBox();
            this.lblCodec = new System.Windows.Forms.Label();
            this.tcFFmpegAudioCodecs = new System.Windows.Forms.TabControl();
            this.tpAAC = new System.Windows.Forms.TabPage();
            this.tbAACBitrate = new System.Windows.Forms.TrackBar();
            this.lblAACQuality = new System.Windows.Forms.Label();
            this.tpOpus = new System.Windows.Forms.TabPage();
            this.tbOpusBitrate = new System.Windows.Forms.TrackBar();
            this.lblOpusQuality = new System.Windows.Forms.Label();
            this.tpVorbis = new System.Windows.Forms.TabPage();
            this.tbVorbis_qscale = new System.Windows.Forms.TrackBar();
            this.lblVorbisQuality = new System.Windows.Forms.Label();
            this.tpMP3 = new System.Windows.Forms.TabPage();
            this.tbMP3_qscale = new System.Windows.Forms.TrackBar();
            this.lblMP3Quality = new System.Windows.Forms.Label();
            this.tcFFmpegVideoCodecs = new System.Windows.Forms.TabControl();
            this.tpX264 = new System.Windows.Forms.TabPage();
            this.pbx264PresetWarning = new System.Windows.Forms.PictureBox();
            this.nudx264CRF = new System.Windows.Forms.NumericUpDown();
            this.lblx264CRF = new System.Windows.Forms.Label();
            this.cbx264Preset = new System.Windows.Forms.ComboBox();
            this.lblx264Preset = new System.Windows.Forms.Label();
            this.tpVpx = new System.Windows.Forms.TabPage();
            this.lblVP8BitrateK = new System.Windows.Forms.Label();
            this.nudVP8Bitrate = new System.Windows.Forms.NumericUpDown();
            this.lblVP8Bitrate = new System.Windows.Forms.Label();
            this.tpXvid = new System.Windows.Forms.TabPage();
            this.nudXvidQscale = new System.Windows.Forms.NumericUpDown();
            this.lblXvidQscale = new System.Windows.Forms.Label();
            this.tpNVENC = new System.Windows.Forms.TabPage();
            this.cbNVENCPreset = new System.Windows.Forms.ComboBox();
            this.lblNVENCPreset = new System.Windows.Forms.Label();
            this.nudNVENCBitrate = new System.Windows.Forms.NumericUpDown();
            this.lblNVENCBitrate = new System.Windows.Forms.Label();
            this.tpGIF = new System.Windows.Forms.TabPage();
            this.cbGIFDither = new System.Windows.Forms.ComboBox();
            this.lblGIFDither = new System.Windows.Forms.Label();
            this.cbGIFStatsMode = new System.Windows.Forms.ComboBox();
            this.lblGIFStatsMode = new System.Windows.Forms.Label();
            this.tbAMF = new System.Windows.Forms.TabPage();
            this.cbAMFQuality = new System.Windows.Forms.ComboBox();
            this.lblAMFQuality = new System.Windows.Forms.Label();
            this.cbAMFUsage = new System.Windows.Forms.ComboBox();
            this.lblAMFUsage = new System.Windows.Forms.Label();
            this.tbQSV = new System.Windows.Forms.TabPage();
            this.cbQSVPreset = new System.Windows.Forms.ComboBox();
            this.lblQSVPreset = new System.Windows.Forms.Label();
            this.nudQSVBitrate = new System.Windows.Forms.NumericUpDown();
            this.lblQSVBitrate = new System.Windows.Forms.Label();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.cboAudioSource = new System.Windows.Forms.ComboBox();
            this.lblAudioSource = new System.Windows.Forms.Label();
            this.cboVideoSource = new System.Windows.Forms.ComboBox();
            this.lblVideoSource = new System.Windows.Forms.Label();
            this.btnRefreshSources = new System.Windows.Forms.Button();
            this.gbFFmpegExe = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.ffmpeg_path = new System.Windows.Forms.Label();
            this.LngAdd = new System.Windows.Forms.Button();
            this.LngCode = new System.Windows.Forms.TextBox();
            this.hiInkVisible = new gInk.HotkeyInputBox();
            this.hiSnapshot = new gInk.HotkeyInputBox();
            this.hiClear = new gInk.HotkeyInputBox();
            this.hiPan = new gInk.HotkeyInputBox();
            this.hiPointer = new gInk.HotkeyInputBox();
            this.hiRedo = new gInk.HotkeyInputBox();
            this.hiUndo = new gInk.HotkeyInputBox();
            this.hiEraser = new gInk.HotkeyInputBox();
            this.hiGlobal = new gInk.HotkeyInputBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolbar_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.Record.SuspendLayout();
            this.gbCommandLinePreview.SuspendLayout();
            this.WaterMark.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_opacity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_X)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_show)).BeginInit();
            this.gbCommandLineArgs.SuspendLayout();
            this.gbCodecs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioCodecWarning)).BeginInit();
            this.tcFFmpegAudioCodecs.SuspendLayout();
            this.tpAAC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAACBitrate)).BeginInit();
            this.tpOpus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpusBitrate)).BeginInit();
            this.tpVorbis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVorbis_qscale)).BeginInit();
            this.tpMP3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMP3_qscale)).BeginInit();
            this.tcFFmpegVideoCodecs.SuspendLayout();
            this.tpX264.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx264PresetWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudx264CRF)).BeginInit();
            this.tpVpx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVP8Bitrate)).BeginInit();
            this.tpXvid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudXvidQscale)).BeginInit();
            this.tpNVENC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNVENCBitrate)).BeginInit();
            this.tpGIF.SuspendLayout();
            this.tbAMF.SuspendLayout();
            this.tbQSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQSVBitrate)).BeginInit();
            this.gbSource.SuspendLayout();
            this.gbFFmpegExe.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEraserEnabled
            // 
            this.cbEraserEnabled.AutoSize = true;
            this.cbEraserEnabled.Location = new System.Drawing.Point(52, 100);
            this.cbEraserEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbEraserEnabled.Name = "cbEraserEnabled";
            this.cbEraserEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbEraserEnabled.TabIndex = 0;
            this.cbEraserEnabled.UseVisualStyleBackColor = true;
            this.cbEraserEnabled.CheckedChanged += new System.EventHandler(this.cbEraserEnabled_CheckedChanged);
            // 
            // cbPointerEnabled
            // 
            this.cbPointerEnabled.AutoSize = true;
            this.cbPointerEnabled.Location = new System.Drawing.Point(183, 100);
            this.cbPointerEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbPointerEnabled.Name = "cbPointerEnabled";
            this.cbPointerEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbPointerEnabled.TabIndex = 0;
            this.cbPointerEnabled.UseVisualStyleBackColor = true;
            this.cbPointerEnabled.CheckedChanged += new System.EventHandler(this.cbPointerEnabled_CheckedChanged);
            // 
            // cbSnapEnabled
            // 
            this.cbSnapEnabled.AutoSize = true;
            this.cbSnapEnabled.Location = new System.Drawing.Point(433, 101);
            this.cbSnapEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbSnapEnabled.Name = "cbSnapEnabled";
            this.cbSnapEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbSnapEnabled.TabIndex = 0;
            this.cbSnapEnabled.UseVisualStyleBackColor = true;
            this.cbSnapEnabled.CheckedChanged += new System.EventHandler(this.cbSnapEnabled_CheckedChanged);
            // 
            // cbUndoEnabled
            // 
            this.cbUndoEnabled.AutoSize = true;
            this.cbUndoEnabled.Location = new System.Drawing.Point(503, 101);
            this.cbUndoEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbUndoEnabled.Name = "cbUndoEnabled";
            this.cbUndoEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbUndoEnabled.TabIndex = 0;
            this.cbUndoEnabled.UseVisualStyleBackColor = true;
            this.cbUndoEnabled.CheckedChanged += new System.EventHandler(this.cbUndoEnabled_CheckedChanged);
            // 
            // cbClearEnabled
            // 
            this.cbClearEnabled.AutoSize = true;
            this.cbClearEnabled.Location = new System.Drawing.Point(568, 101);
            this.cbClearEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbClearEnabled.Name = "cbClearEnabled";
            this.cbClearEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbClearEnabled.TabIndex = 0;
            this.cbClearEnabled.UseVisualStyleBackColor = true;
            this.cbClearEnabled.CheckedChanged += new System.EventHandler(this.cbClearEnabled_CheckedChanged);
            // 
            // cbWidthEnabled
            // 
            this.cbWidthEnabled.AutoSize = true;
            this.cbWidthEnabled.Checked = true;
            this.cbWidthEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWidthEnabled.Location = new System.Drawing.Point(296, 102);
            this.cbWidthEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbWidthEnabled.Name = "cbWidthEnabled";
            this.cbWidthEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbWidthEnabled.TabIndex = 0;
            this.cbWidthEnabled.UseVisualStyleBackColor = true;
            this.cbWidthEnabled.CheckedChanged += new System.EventHandler(this.cbWidthEnabled_CheckedChanged);
            // 
            // cbWhiteIcon
            // 
            this.cbWhiteIcon.AutoSize = true;
            this.cbWhiteIcon.Location = new System.Drawing.Point(15, 293);
            this.cbWhiteIcon.Margin = new System.Windows.Forms.Padding(4);
            this.cbWhiteIcon.Name = "cbWhiteIcon";
            this.cbWhiteIcon.Size = new System.Drawing.Size(149, 21);
            this.cbWhiteIcon.TabIndex = 0;
            this.cbWhiteIcon.Text = "Use white tray icon";
            this.cbWhiteIcon.UseVisualStyleBackColor = true;
            // 
            // tbSnapPath
            // 
            this.tbSnapPath.Location = new System.Drawing.Point(236, 249);
            this.tbSnapPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbSnapPath.Name = "tbSnapPath";
            this.tbSnapPath.Size = new System.Drawing.Size(335, 22);
            this.tbSnapPath.TabIndex = 1;
            this.tbSnapPath.ModifiedChanged += new System.EventHandler(this.tbSnapPath_ModifiedChanged);
            // 
            // lbSnapshotsavepath
            // 
            this.lbSnapshotsavepath.AutoSize = true;
            this.lbSnapshotsavepath.Location = new System.Drawing.Point(11, 249);
            this.lbSnapshotsavepath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSnapshotsavepath.Name = "lbSnapshotsavepath";
            this.lbSnapshotsavepath.Size = new System.Drawing.Size(134, 17);
            this.lbSnapshotsavepath.TabIndex = 2;
            this.lbSnapshotsavepath.Text = "Snapshot save path";
            // 
            // btSnapPath
            // 
            this.btSnapPath.Location = new System.Drawing.Point(580, 241);
            this.btSnapPath.Margin = new System.Windows.Forms.Padding(4);
            this.btSnapPath.Name = "btSnapPath";
            this.btSnapPath.Size = new System.Drawing.Size(41, 28);
            this.btSnapPath.TabIndex = 3;
            this.btSnapPath.Text = "...";
            this.btSnapPath.UseVisualStyleBackColor = true;
            this.btSnapPath.Click += new System.EventHandler(this.btSnapPath_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbCanvascursor
            // 
            this.lbCanvascursor.AutoSize = true;
            this.lbCanvascursor.Location = new System.Drawing.Point(12, 206);
            this.lbCanvascursor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCanvascursor.Name = "lbCanvascursor";
            this.lbCanvascursor.Size = new System.Drawing.Size(99, 17);
            this.lbCanvascursor.TabIndex = 5;
            this.lbCanvascursor.Text = "Canvas cursor";
            // 
            // comboCanvasCursor
            // 
            this.comboCanvasCursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCanvasCursor.FormattingEnabled = true;
            this.comboCanvasCursor.Items.AddRange(new object[] {
            "Arrow",
            "Pen tip"});
            this.comboCanvasCursor.Location = new System.Drawing.Point(236, 199);
            this.comboCanvasCursor.Margin = new System.Windows.Forms.Padding(4);
            this.comboCanvasCursor.Name = "comboCanvasCursor";
            this.comboCanvasCursor.Size = new System.Drawing.Size(335, 24);
            this.comboCanvasCursor.TabIndex = 6;
            this.comboCanvasCursor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.Record);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 640);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage1.Controls.Add(this.LngCode);
            this.tabPage1.Controls.Add(this.LngAdd);
            this.tabPage1.Controls.Add(this.toolbar_size);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lbLanguage);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.comboLanguage);
            this.tabPage1.Controls.Add(this.comboCanvasCursor);
            this.tabPage1.Controls.Add(this.cbInkVisibleEnabled);
            this.tabPage1.Controls.Add(this.cbPanEnabled);
            this.tabPage1.Controls.Add(this.cbEraserEnabled);
            this.tabPage1.Controls.Add(this.lbCanvascursor);
            this.tabPage1.Controls.Add(this.cbWidthEnabled);
            this.tabPage1.Controls.Add(this.cbPointerEnabled);
            this.tabPage1.Controls.Add(this.btSnapPath);
            this.tabPage1.Controls.Add(this.cbSnapEnabled);
            this.tabPage1.Controls.Add(this.cbUndoEnabled);
            this.tabPage1.Controls.Add(this.cbClearEnabled);
            this.tabPage1.Controls.Add(this.lbSnapshotsavepath);
            this.tabPage1.Controls.Add(this.cbAllowDragging);
            this.tabPage1.Controls.Add(this.cbWhiteIcon);
            this.tabPage1.Controls.Add(this.tbSnapPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(859, 611);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // toolbar_size
            // 
            this.toolbar_size.Location = new System.Drawing.Point(236, 121);
            this.toolbar_size.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.toolbar_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toolbar_size.Name = "toolbar_size";
            this.toolbar_size.Size = new System.Drawing.Size(52, 22);
            this.toolbar_size.TabIndex = 10;
            this.toolbar_size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.toolbar_size.ValueChanged += new System.EventHandler(this.toolbar_size_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Toolbar Size";
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Location = new System.Drawing.Point(12, 160);
            this.lbLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(72, 17);
            this.lbLanguage.TabIndex = 8;
            this.lbLanguage.Text = "Language";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gInk.Properties.Resources.paneloption;
            this.pictureBox1.Location = new System.Drawing.Point(11, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(468, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // comboLanguage
            // 
            this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Location = new System.Drawing.Point(236, 156);
            this.comboLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(254, 24);
            this.comboLanguage.TabIndex = 6;
            this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.comboLanguage_SelectedIndexChanged);
            // 
            // cbInkVisibleEnabled
            // 
            this.cbInkVisibleEnabled.AutoSize = true;
            this.cbInkVisibleEnabled.Location = new System.Drawing.Point(367, 101);
            this.cbInkVisibleEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbInkVisibleEnabled.Name = "cbInkVisibleEnabled";
            this.cbInkVisibleEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbInkVisibleEnabled.TabIndex = 0;
            this.cbInkVisibleEnabled.UseVisualStyleBackColor = true;
            this.cbInkVisibleEnabled.CheckedChanged += new System.EventHandler(this.cbInkVisibleEnabled_CheckedChanged);
            // 
            // cbPanEnabled
            // 
            this.cbPanEnabled.AutoSize = true;
            this.cbPanEnabled.Location = new System.Drawing.Point(116, 100);
            this.cbPanEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbPanEnabled.Name = "cbPanEnabled";
            this.cbPanEnabled.Size = new System.Drawing.Size(18, 17);
            this.cbPanEnabled.TabIndex = 0;
            this.cbPanEnabled.UseVisualStyleBackColor = true;
            this.cbPanEnabled.CheckedChanged += new System.EventHandler(this.cbPanEnabled_CheckedChanged);
            // 
            // cbAllowDragging
            // 
            this.cbAllowDragging.AutoSize = true;
            this.cbAllowDragging.Location = new System.Drawing.Point(15, 330);
            this.cbAllowDragging.Margin = new System.Windows.Forms.Padding(4);
            this.cbAllowDragging.Name = "cbAllowDragging";
            this.cbAllowDragging.Size = new System.Drawing.Size(264, 21);
            this.cbAllowDragging.TabIndex = 0;
            this.cbAllowDragging.Text = "Allow dragging toolbar (experimental)";
            this.cbAllowDragging.UseVisualStyleBackColor = true;
            this.cbAllowDragging.CheckedChanged += new System.EventHandler(this.cbAllowDragging_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(859, 611);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pens";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage3.Controls.Add(this.cbAllowHotkeyInPointer);
            this.tabPage3.Controls.Add(this.lbHkInkVisible);
            this.tabPage3.Controls.Add(this.lbHkSnapshot);
            this.tabPage3.Controls.Add(this.lbHkClear);
            this.tabPage3.Controls.Add(this.lbHkPan);
            this.tabPage3.Controls.Add(this.lbHkPointer);
            this.tabPage3.Controls.Add(this.lbHkRedo);
            this.tabPage3.Controls.Add(this.lbHkUndo);
            this.tabPage3.Controls.Add(this.lbHkEraser);
            this.tabPage3.Controls.Add(this.lbGlobalHotkey);
            this.tabPage3.Controls.Add(this.hiInkVisible);
            this.tabPage3.Controls.Add(this.hiSnapshot);
            this.tabPage3.Controls.Add(this.hiClear);
            this.tabPage3.Controls.Add(this.hiPan);
            this.tabPage3.Controls.Add(this.hiPointer);
            this.tabPage3.Controls.Add(this.hiRedo);
            this.tabPage3.Controls.Add(this.hiUndo);
            this.tabPage3.Controls.Add(this.hiEraser);
            this.tabPage3.Controls.Add(this.hiGlobal);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(859, 611);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hotkeys";
            // 
            // cbAllowHotkeyInPointer
            // 
            this.cbAllowHotkeyInPointer.AutoSize = true;
            this.cbAllowHotkeyInPointer.Location = new System.Drawing.Point(25, 107);
            this.cbAllowHotkeyInPointer.Margin = new System.Windows.Forms.Padding(4);
            this.cbAllowHotkeyInPointer.Name = "cbAllowHotkeyInPointer";
            this.cbAllowHotkeyInPointer.Size = new System.Drawing.Size(474, 21);
            this.cbAllowHotkeyInPointer.TabIndex = 18;
            this.cbAllowHotkeyInPointer.Text = "Allow all following hotkeys in mouse pointer mode (may cause a mess):";
            this.cbAllowHotkeyInPointer.UseVisualStyleBackColor = true;
            this.cbAllowHotkeyInPointer.CheckedChanged += new System.EventHandler(this.cbAllowHotkeyInPointer_CheckedChanged);
            // 
            // lbHkInkVisible
            // 
            this.lbHkInkVisible.AutoSize = true;
            this.lbHkInkVisible.Location = new System.Drawing.Point(315, 249);
            this.lbHkInkVisible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkInkVisible.Name = "lbHkInkVisible";
            this.lbHkInkVisible.Size = new System.Drawing.Size(70, 17);
            this.lbHkInkVisible.TabIndex = 16;
            this.lbHkInkVisible.Text = "View/Hide";
            // 
            // lbHkSnapshot
            // 
            this.lbHkSnapshot.AutoSize = true;
            this.lbHkSnapshot.Location = new System.Drawing.Point(315, 282);
            this.lbHkSnapshot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkSnapshot.Name = "lbHkSnapshot";
            this.lbHkSnapshot.Size = new System.Drawing.Size(68, 17);
            this.lbHkSnapshot.TabIndex = 12;
            this.lbHkSnapshot.Text = "Snapshot";
            // 
            // lbHkClear
            // 
            this.lbHkClear.AutoSize = true;
            this.lbHkClear.Location = new System.Drawing.Point(315, 382);
            this.lbHkClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkClear.Name = "lbHkClear";
            this.lbHkClear.Size = new System.Drawing.Size(41, 17);
            this.lbHkClear.TabIndex = 13;
            this.lbHkClear.Text = "Clear";
            // 
            // lbHkPan
            // 
            this.lbHkPan.AutoSize = true;
            this.lbHkPan.Location = new System.Drawing.Point(315, 181);
            this.lbHkPan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkPan.Name = "lbHkPan";
            this.lbHkPan.Size = new System.Drawing.Size(33, 17);
            this.lbHkPan.TabIndex = 10;
            this.lbHkPan.Text = "Pan";
            // 
            // lbHkPointer
            // 
            this.lbHkPointer.AutoSize = true;
            this.lbHkPointer.Location = new System.Drawing.Point(315, 215);
            this.lbHkPointer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkPointer.Name = "lbHkPointer";
            this.lbHkPointer.Size = new System.Drawing.Size(98, 17);
            this.lbHkPointer.TabIndex = 6;
            this.lbHkPointer.Text = "Mouse pointer";
            this.lbHkPointer.Visible = false;
            // 
            // lbHkRedo
            // 
            this.lbHkRedo.AutoSize = true;
            this.lbHkRedo.Location = new System.Drawing.Point(315, 348);
            this.lbHkRedo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkRedo.Name = "lbHkRedo";
            this.lbHkRedo.Size = new System.Drawing.Size(42, 17);
            this.lbHkRedo.TabIndex = 7;
            this.lbHkRedo.Text = "Redo";
            // 
            // lbHkUndo
            // 
            this.lbHkUndo.AutoSize = true;
            this.lbHkUndo.Location = new System.Drawing.Point(315, 315);
            this.lbHkUndo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkUndo.Name = "lbHkUndo";
            this.lbHkUndo.Size = new System.Drawing.Size(42, 17);
            this.lbHkUndo.TabIndex = 4;
            this.lbHkUndo.Text = "Undo";
            // 
            // lbHkEraser
            // 
            this.lbHkEraser.AutoSize = true;
            this.lbHkEraser.Location = new System.Drawing.Point(315, 148);
            this.lbHkEraser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHkEraser.Name = "lbHkEraser";
            this.lbHkEraser.Size = new System.Drawing.Size(50, 17);
            this.lbHkEraser.TabIndex = 4;
            this.lbHkEraser.Text = "Eraser";
            // 
            // lbGlobalHotkey
            // 
            this.lbGlobalHotkey.AutoSize = true;
            this.lbGlobalHotkey.Location = new System.Drawing.Point(23, 22);
            this.lbGlobalHotkey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGlobalHotkey.Name = "lbGlobalHotkey";
            this.lbGlobalHotkey.Size = new System.Drawing.Size(468, 17);
            this.lbGlobalHotkey.TabIndex = 4;
            this.lbGlobalHotkey.Text = "Global hotkey (start drawing, switch between mouse pointer and drawing)";
            // 
            // Record
            // 
            this.Record.Controls.Add(this.gbCommandLinePreview);
            this.Record.Controls.Add(this.WaterMark);
            this.Record.Controls.Add(this.gbCommandLineArgs);
            this.Record.Controls.Add(this.gbCodecs);
            this.Record.Controls.Add(this.gbSource);
            this.Record.Controls.Add(this.gbFFmpegExe);
            this.Record.Location = new System.Drawing.Point(4, 25);
            this.Record.Name = "Record";
            this.Record.Padding = new System.Windows.Forms.Padding(3);
            this.Record.Size = new System.Drawing.Size(859, 611);
            this.Record.TabIndex = 3;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // gbCommandLinePreview
            // 
            this.gbCommandLinePreview.Controls.Add(this.txtCommandLinePreview);
            this.gbCommandLinePreview.Controls.Add(this.btnTest);
            this.gbCommandLinePreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCommandLinePreview.Location = new System.Drawing.Point(3, 495);
            this.gbCommandLinePreview.Margin = new System.Windows.Forms.Padding(4);
            this.gbCommandLinePreview.Name = "gbCommandLinePreview";
            this.gbCommandLinePreview.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.gbCommandLinePreview.Size = new System.Drawing.Size(853, 119);
            this.gbCommandLinePreview.TabIndex = 13;
            this.gbCommandLinePreview.TabStop = false;
            this.gbCommandLinePreview.Text = "Command line preview";
            // 
            // txtCommandLinePreview
            // 
            this.txtCommandLinePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandLinePreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCommandLinePreview.Location = new System.Drawing.Point(171, 25);
            this.txtCommandLinePreview.Margin = new System.Windows.Forms.Padding(4);
            this.txtCommandLinePreview.Multiline = true;
            this.txtCommandLinePreview.Name = "txtCommandLinePreview";
            this.txtCommandLinePreview.ReadOnly = true;
            this.txtCommandLinePreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandLinePreview.Size = new System.Drawing.Size(671, 84);
            this.txtCommandLinePreview.TabIndex = 0;
            this.txtCommandLinePreview.Text = resources.GetString("txtCommandLinePreview.Text");
            // 
            // btnTest
            // 
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTest.Location = new System.Drawing.Point(11, 25);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(160, 84);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test with CMD";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_ClickAsync);
            // 
            // WaterMark
            // 
            this.WaterMark.Controls.Add(this.groupBox3);
            this.WaterMark.Controls.Add(this.groupBox2);
            this.WaterMark.Controls.Add(this.groupBox1);
            this.WaterMark.Controls.Add(this.panel3);
            this.WaterMark.Dock = System.Windows.Forms.DockStyle.Top;
            this.WaterMark.Location = new System.Drawing.Point(3, 358);
            this.WaterMark.Name = "WaterMark";
            this.WaterMark.Size = new System.Drawing.Size(853, 137);
            this.WaterMark.TabIndex = 12;
            this.WaterMark.TabStop = false;
            this.WaterMark.Text = "Add Watermark";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.watermark_opacity_text);
            this.groupBox3.Controls.Add(this.watermark_opacity);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(387, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 116);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Opacity";
            // 
            // watermark_opacity_text
            // 
            this.watermark_opacity_text.AutoSize = true;
            this.watermark_opacity_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_opacity_text.Location = new System.Drawing.Point(83, 54);
            this.watermark_opacity_text.Name = "watermark_opacity_text";
            this.watermark_opacity_text.Size = new System.Drawing.Size(36, 17);
            this.watermark_opacity_text.TabIndex = 7;
            this.watermark_opacity_text.Text = "%50";
            // 
            // watermark_opacity
            // 
            this.watermark_opacity.Dock = System.Windows.Forms.DockStyle.Top;
            this.watermark_opacity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_opacity.Location = new System.Drawing.Point(3, 18);
            this.watermark_opacity.Maximum = 100;
            this.watermark_opacity.Name = "watermark_opacity";
            this.watermark_opacity.Size = new System.Drawing.Size(194, 56);
            this.watermark_opacity.TabIndex = 1;
            this.watermark_opacity.Value = 50;
            this.watermark_opacity.ValueChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.watermark_Y);
            this.groupBox2.Controls.Add(this.watermark_X);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(268, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 116);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Padding";
            // 
            // watermark_Y
            // 
            this.watermark_Y.Location = new System.Drawing.Point(34, 51);
            this.watermark_Y.Name = "watermark_Y";
            this.watermark_Y.Size = new System.Drawing.Size(48, 22);
            this.watermark_Y.TabIndex = 7;
            this.watermark_Y.ValueChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // watermark_X
            // 
            this.watermark_X.Location = new System.Drawing.Point(34, 26);
            this.watermark_X.Name = "watermark_X";
            this.watermark_X.Size = new System.Drawing.Size(48, 22);
            this.watermark_X.TabIndex = 6;
            this.watermark_X.ValueChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(88, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(88, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "px";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(134, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Location";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.watermark_location_top);
            this.panel1.Controls.Add(this.watermark_location_bottom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 95);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.watermark_location_right);
            this.panel2.Controls.Add(this.watermark_location_left);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 21);
            this.panel2.TabIndex = 5;
            // 
            // watermark_location_right
            // 
            this.watermark_location_right.AutoSize = true;
            this.watermark_location_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.watermark_location_right.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_location_right.Location = new System.Drawing.Point(66, 0);
            this.watermark_location_right.Name = "watermark_location_right";
            this.watermark_location_right.Size = new System.Drawing.Size(62, 21);
            this.watermark_location_right.TabIndex = 3;
            this.watermark_location_right.Tag = "";
            this.watermark_location_right.Text = "Right";
            this.watermark_location_right.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.watermark_location_right.UseVisualStyleBackColor = true;
            this.watermark_location_right.CheckedChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // watermark_location_left
            // 
            this.watermark_location_left.AutoSize = true;
            this.watermark_location_left.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.watermark_location_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.watermark_location_left.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_location_left.Location = new System.Drawing.Point(0, 0);
            this.watermark_location_left.Name = "watermark_location_left";
            this.watermark_location_left.Size = new System.Drawing.Size(53, 21);
            this.watermark_location_left.TabIndex = 2;
            this.watermark_location_left.Tag = "";
            this.watermark_location_left.Text = "Left";
            this.watermark_location_left.UseVisualStyleBackColor = true;
            this.watermark_location_left.CheckedChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // watermark_location_top
            // 
            this.watermark_location_top.AutoSize = true;
            this.watermark_location_top.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.watermark_location_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.watermark_location_top.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_location_top.Location = new System.Drawing.Point(0, 0);
            this.watermark_location_top.Name = "watermark_location_top";
            this.watermark_location_top.Size = new System.Drawing.Size(128, 37);
            this.watermark_location_top.TabIndex = 0;
            this.watermark_location_top.Tag = "";
            this.watermark_location_top.Text = "Top";
            this.watermark_location_top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.watermark_location_top.UseVisualStyleBackColor = true;
            this.watermark_location_top.CheckedChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // watermark_location_bottom
            // 
            this.watermark_location_bottom.AutoSize = true;
            this.watermark_location_bottom.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.watermark_location_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.watermark_location_bottom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_location_bottom.Location = new System.Drawing.Point(0, 58);
            this.watermark_location_bottom.Name = "watermark_location_bottom";
            this.watermark_location_bottom.Size = new System.Drawing.Size(128, 37);
            this.watermark_location_bottom.TabIndex = 1;
            this.watermark_location_bottom.Tag = "";
            this.watermark_location_bottom.Text = "Bottom";
            this.watermark_location_bottom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.watermark_location_bottom.UseVisualStyleBackColor = true;
            this.watermark_location_bottom.CheckedChanged += new System.EventHandler(this.watermark_location_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.watermark_show);
            this.panel3.Controls.Add(this.watermark_use);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(131, 116);
            this.panel3.TabIndex = 9;
            // 
            // watermark_show
            // 
            this.watermark_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.watermark_show.Enabled = false;
            this.watermark_show.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_show.Location = new System.Drawing.Point(20, 22);
            this.watermark_show.Name = "watermark_show";
            this.watermark_show.Size = new System.Drawing.Size(90, 90);
            this.watermark_show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.watermark_show.TabIndex = 0;
            this.watermark_show.TabStop = false;
            this.watermark_show.MouseClick += new System.Windows.Forms.MouseEventHandler(this.watermark_chose_MouseClick);
            // 
            // watermark_use
            // 
            this.watermark_use.AutoSize = true;
            this.watermark_use.Dock = System.Windows.Forms.DockStyle.Top;
            this.watermark_use.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.watermark_use.Location = new System.Drawing.Point(0, 0);
            this.watermark_use.Name = "watermark_use";
            this.watermark_use.Size = new System.Drawing.Size(131, 21);
            this.watermark_use.TabIndex = 3;
            this.watermark_use.Text = "Use Watermark";
            this.watermark_use.UseVisualStyleBackColor = true;
            this.watermark_use.CheckedChanged += new System.EventHandler(this.watermark_use_CheckedChanged);
            // 
            // gbCommandLineArgs
            // 
            this.gbCommandLineArgs.Controls.Add(this.tbUserArgs);
            this.gbCommandLineArgs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCommandLineArgs.Location = new System.Drawing.Point(3, 299);
            this.gbCommandLineArgs.Margin = new System.Windows.Forms.Padding(4);
            this.gbCommandLineArgs.Name = "gbCommandLineArgs";
            this.gbCommandLineArgs.Padding = new System.Windows.Forms.Padding(4);
            this.gbCommandLineArgs.Size = new System.Drawing.Size(853, 59);
            this.gbCommandLineArgs.TabIndex = 6;
            this.gbCommandLineArgs.TabStop = false;
            this.gbCommandLineArgs.Text = "Additional command line arguments";
            // 
            // tbUserArgs
            // 
            this.tbUserArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserArgs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbUserArgs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbUserArgs.Location = new System.Drawing.Point(11, 30);
            this.tbUserArgs.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserArgs.Name = "tbUserArgs";
            this.tbUserArgs.Size = new System.Drawing.Size(830, 22);
            this.tbUserArgs.TabIndex = 0;
            this.tbUserArgs.TextChanged += new System.EventHandler(this.tbUserArgs_TextChanged);
            // 
            // gbCodecs
            // 
            this.gbCodecs.Controls.Add(this.pbAudioCodecWarning);
            this.gbCodecs.Controls.Add(this.cboAudioCodec);
            this.gbCodecs.Controls.Add(this.lblAudioCodec);
            this.gbCodecs.Controls.Add(this.cboVideoCodec);
            this.gbCodecs.Controls.Add(this.lblCodec);
            this.gbCodecs.Controls.Add(this.tcFFmpegAudioCodecs);
            this.gbCodecs.Controls.Add(this.tcFFmpegVideoCodecs);
            this.gbCodecs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCodecs.Location = new System.Drawing.Point(3, 110);
            this.gbCodecs.Margin = new System.Windows.Forms.Padding(4);
            this.gbCodecs.Name = "gbCodecs";
            this.gbCodecs.Padding = new System.Windows.Forms.Padding(4);
            this.gbCodecs.Size = new System.Drawing.Size(853, 189);
            this.gbCodecs.TabIndex = 3;
            this.gbCodecs.TabStop = false;
            this.gbCodecs.Text = "Codecs";
            // 
            // pbAudioCodecWarning
            // 
            this.pbAudioCodecWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbAudioCodecWarning.Location = new System.Drawing.Point(733, 27);
            this.pbAudioCodecWarning.Margin = new System.Windows.Forms.Padding(4);
            this.pbAudioCodecWarning.Name = "pbAudioCodecWarning";
            this.pbAudioCodecWarning.Size = new System.Drawing.Size(16, 16);
            this.pbAudioCodecWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAudioCodecWarning.TabIndex = 5;
            this.pbAudioCodecWarning.TabStop = false;
            this.pbAudioCodecWarning.Visible = false;
            // 
            // cboAudioCodec
            // 
            this.cboAudioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAudioCodec.FormattingEnabled = true;
            this.cboAudioCodec.Location = new System.Drawing.Point(587, 25);
            this.cboAudioCodec.Margin = new System.Windows.Forms.Padding(4);
            this.cboAudioCodec.Name = "cboAudioCodec";
            this.cboAudioCodec.Size = new System.Drawing.Size(137, 24);
            this.cboAudioCodec.TabIndex = 3;
            this.cboAudioCodec.SelectedIndexChanged += new System.EventHandler(this.cboAudioCodec_SelectedIndexChanged);
            // 
            // lblAudioCodec
            // 
            this.lblAudioCodec.AutoSize = true;
            this.lblAudioCodec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAudioCodec.Location = new System.Drawing.Point(433, 30);
            this.lblAudioCodec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAudioCodec.Name = "lblAudioCodec";
            this.lblAudioCodec.Size = new System.Drawing.Size(90, 17);
            this.lblAudioCodec.TabIndex = 2;
            this.lblAudioCodec.Text = "Audio codec:";
            // 
            // cboVideoCodec
            // 
            this.cboVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoCodec.FormattingEnabled = true;
            this.cboVideoCodec.Location = new System.Drawing.Point(160, 25);
            this.cboVideoCodec.Margin = new System.Windows.Forms.Padding(4);
            this.cboVideoCodec.Name = "cboVideoCodec";
            this.cboVideoCodec.Size = new System.Drawing.Size(212, 24);
            this.cboVideoCodec.TabIndex = 1;
            this.cboVideoCodec.SelectedIndexChanged += new System.EventHandler(this.cboVideoCodec_SelectedIndexChanged);
            // 
            // lblCodec
            // 
            this.lblCodec.AutoSize = true;
            this.lblCodec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodec.Location = new System.Drawing.Point(11, 30);
            this.lblCodec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodec.Name = "lblCodec";
            this.lblCodec.Size = new System.Drawing.Size(90, 17);
            this.lblCodec.TabIndex = 0;
            this.lblCodec.Text = "Video codec:";
            // 
            // tcFFmpegAudioCodecs
            // 
            this.tcFFmpegAudioCodecs.Controls.Add(this.tpAAC);
            this.tcFFmpegAudioCodecs.Controls.Add(this.tpOpus);
            this.tcFFmpegAudioCodecs.Controls.Add(this.tpVorbis);
            this.tcFFmpegAudioCodecs.Controls.Add(this.tpMP3);
            this.tcFFmpegAudioCodecs.Location = new System.Drawing.Point(437, 69);
            this.tcFFmpegAudioCodecs.Margin = new System.Windows.Forms.Padding(4);
            this.tcFFmpegAudioCodecs.Name = "tcFFmpegAudioCodecs";
            this.tcFFmpegAudioCodecs.SelectedIndex = 0;
            this.tcFFmpegAudioCodecs.Size = new System.Drawing.Size(416, 118);
            this.tcFFmpegAudioCodecs.TabIndex = 4;
            // 
            // tpAAC
            // 
            this.tpAAC.BackColor = System.Drawing.SystemColors.Window;
            this.tpAAC.Controls.Add(this.tbAACBitrate);
            this.tpAAC.Controls.Add(this.lblAACQuality);
            this.tpAAC.Location = new System.Drawing.Point(4, 25);
            this.tpAAC.Margin = new System.Windows.Forms.Padding(4);
            this.tpAAC.Name = "tpAAC";
            this.tpAAC.Padding = new System.Windows.Forms.Padding(4);
            this.tpAAC.Size = new System.Drawing.Size(408, 89);
            this.tpAAC.TabIndex = 3;
            this.tpAAC.Text = "AAC";
            // 
            // tbAACBitrate
            // 
            this.tbAACBitrate.BackColor = System.Drawing.SystemColors.Window;
            this.tbAACBitrate.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbAACBitrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbAACBitrate.LargeChange = 1;
            this.tbAACBitrate.Location = new System.Drawing.Point(141, 4);
            this.tbAACBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.tbAACBitrate.Maximum = 16;
            this.tbAACBitrate.Minimum = 1;
            this.tbAACBitrate.Name = "tbAACBitrate";
            this.tbAACBitrate.Size = new System.Drawing.Size(263, 56);
            this.tbAACBitrate.TabIndex = 1;
            this.tbAACBitrate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAACBitrate.Value = 4;
            this.tbAACBitrate.ValueChanged += new System.EventHandler(this.tbAACBitrate_ValueChanged);
            // 
            // lblAACQuality
            // 
            this.lblAACQuality.AutoSize = true;
            this.lblAACQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAACQuality.Location = new System.Drawing.Point(21, 20);
            this.lblAACQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAACQuality.Name = "lblAACQuality";
            this.lblAACQuality.Size = new System.Drawing.Size(53, 17);
            this.lblAACQuality.TabIndex = 0;
            this.lblAACQuality.Text = "Bitrate:";
            // 
            // tpOpus
            // 
            this.tpOpus.Controls.Add(this.tbOpusBitrate);
            this.tpOpus.Controls.Add(this.lblOpusQuality);
            this.tpOpus.Location = new System.Drawing.Point(4, 25);
            this.tpOpus.Margin = new System.Windows.Forms.Padding(4);
            this.tpOpus.Name = "tpOpus";
            this.tpOpus.Padding = new System.Windows.Forms.Padding(4);
            this.tpOpus.Size = new System.Drawing.Size(408, 89);
            this.tpOpus.TabIndex = 4;
            this.tpOpus.Text = "Opus";
            this.tpOpus.UseVisualStyleBackColor = true;
            // 
            // tbOpusBitrate
            // 
            this.tbOpusBitrate.BackColor = System.Drawing.SystemColors.Window;
            this.tbOpusBitrate.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbOpusBitrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbOpusBitrate.LargeChange = 1;
            this.tbOpusBitrate.Location = new System.Drawing.Point(141, 4);
            this.tbOpusBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.tbOpusBitrate.Maximum = 16;
            this.tbOpusBitrate.Minimum = 1;
            this.tbOpusBitrate.Name = "tbOpusBitrate";
            this.tbOpusBitrate.Size = new System.Drawing.Size(263, 56);
            this.tbOpusBitrate.TabIndex = 3;
            this.tbOpusBitrate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbOpusBitrate.Value = 4;
            this.tbOpusBitrate.ValueChanged += new System.EventHandler(this.tbOpusBirate_ValueChanged);
            // 
            // lblOpusQuality
            // 
            this.lblOpusQuality.AutoSize = true;
            this.lblOpusQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOpusQuality.Location = new System.Drawing.Point(21, 20);
            this.lblOpusQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpusQuality.Name = "lblOpusQuality";
            this.lblOpusQuality.Size = new System.Drawing.Size(53, 17);
            this.lblOpusQuality.TabIndex = 2;
            this.lblOpusQuality.Text = "Bitrate:";
            // 
            // tpVorbis
            // 
            this.tpVorbis.BackColor = System.Drawing.SystemColors.Window;
            this.tpVorbis.Controls.Add(this.tbVorbis_qscale);
            this.tpVorbis.Controls.Add(this.lblVorbisQuality);
            this.tpVorbis.Location = new System.Drawing.Point(4, 25);
            this.tpVorbis.Margin = new System.Windows.Forms.Padding(4);
            this.tpVorbis.Name = "tpVorbis";
            this.tpVorbis.Padding = new System.Windows.Forms.Padding(4);
            this.tpVorbis.Size = new System.Drawing.Size(408, 89);
            this.tpVorbis.TabIndex = 0;
            this.tpVorbis.Text = "Vorbis";
            // 
            // tbVorbis_qscale
            // 
            this.tbVorbis_qscale.BackColor = System.Drawing.SystemColors.Window;
            this.tbVorbis_qscale.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbVorbis_qscale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbVorbis_qscale.LargeChange = 1;
            this.tbVorbis_qscale.Location = new System.Drawing.Point(141, 4);
            this.tbVorbis_qscale.Margin = new System.Windows.Forms.Padding(4);
            this.tbVorbis_qscale.Name = "tbVorbis_qscale";
            this.tbVorbis_qscale.Size = new System.Drawing.Size(263, 56);
            this.tbVorbis_qscale.TabIndex = 1;
            this.tbVorbis_qscale.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbVorbis_qscale.Value = 3;
            this.tbVorbis_qscale.ValueChanged += new System.EventHandler(this.tbVorbis_qscale_ValueChanged);
            // 
            // lblVorbisQuality
            // 
            this.lblVorbisQuality.AutoSize = true;
            this.lblVorbisQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVorbisQuality.Location = new System.Drawing.Point(21, 20);
            this.lblVorbisQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVorbisQuality.Name = "lblVorbisQuality";
            this.lblVorbisQuality.Size = new System.Drawing.Size(56, 17);
            this.lblVorbisQuality.TabIndex = 0;
            this.lblVorbisQuality.Text = "Quality:";
            // 
            // tpMP3
            // 
            this.tpMP3.BackColor = System.Drawing.SystemColors.Window;
            this.tpMP3.Controls.Add(this.tbMP3_qscale);
            this.tpMP3.Controls.Add(this.lblMP3Quality);
            this.tpMP3.Location = new System.Drawing.Point(4, 25);
            this.tpMP3.Margin = new System.Windows.Forms.Padding(4);
            this.tpMP3.Name = "tpMP3";
            this.tpMP3.Padding = new System.Windows.Forms.Padding(4);
            this.tpMP3.Size = new System.Drawing.Size(408, 89);
            this.tpMP3.TabIndex = 2;
            this.tpMP3.Text = "MP3";
            // 
            // tbMP3_qscale
            // 
            this.tbMP3_qscale.BackColor = System.Drawing.SystemColors.Window;
            this.tbMP3_qscale.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbMP3_qscale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbMP3_qscale.LargeChange = 1;
            this.tbMP3_qscale.Location = new System.Drawing.Point(141, 4);
            this.tbMP3_qscale.Margin = new System.Windows.Forms.Padding(4);
            this.tbMP3_qscale.Maximum = 9;
            this.tbMP3_qscale.Name = "tbMP3_qscale";
            this.tbMP3_qscale.Size = new System.Drawing.Size(263, 56);
            this.tbMP3_qscale.TabIndex = 1;
            this.tbMP3_qscale.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMP3_qscale.Value = 5;
            this.tbMP3_qscale.ValueChanged += new System.EventHandler(this.tbMP3_qscale_ValueChanged);
            // 
            // lblMP3Quality
            // 
            this.lblMP3Quality.AutoSize = true;
            this.lblMP3Quality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMP3Quality.Location = new System.Drawing.Point(21, 20);
            this.lblMP3Quality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMP3Quality.Name = "lblMP3Quality";
            this.lblMP3Quality.Size = new System.Drawing.Size(56, 17);
            this.lblMP3Quality.TabIndex = 0;
            this.lblMP3Quality.Text = "Quality:";
            // 
            // tcFFmpegVideoCodecs
            // 
            this.tcFFmpegVideoCodecs.Controls.Add(this.tpX264);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tpVpx);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tpXvid);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tpNVENC);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tpGIF);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tbAMF);
            this.tcFFmpegVideoCodecs.Controls.Add(this.tbQSV);
            this.tcFFmpegVideoCodecs.Location = new System.Drawing.Point(11, 69);
            this.tcFFmpegVideoCodecs.Margin = new System.Windows.Forms.Padding(4);
            this.tcFFmpegVideoCodecs.Name = "tcFFmpegVideoCodecs";
            this.tcFFmpegVideoCodecs.SelectedIndex = 0;
            this.tcFFmpegVideoCodecs.Size = new System.Drawing.Size(416, 118);
            this.tcFFmpegVideoCodecs.TabIndex = 3;
            // 
            // tpX264
            // 
            this.tpX264.BackColor = System.Drawing.SystemColors.Window;
            this.tpX264.Controls.Add(this.pbx264PresetWarning);
            this.tpX264.Controls.Add(this.nudx264CRF);
            this.tpX264.Controls.Add(this.lblx264CRF);
            this.tpX264.Controls.Add(this.cbx264Preset);
            this.tpX264.Controls.Add(this.lblx264Preset);
            this.tpX264.Location = new System.Drawing.Point(4, 25);
            this.tpX264.Margin = new System.Windows.Forms.Padding(4);
            this.tpX264.Name = "tpX264";
            this.tpX264.Padding = new System.Windows.Forms.Padding(4);
            this.tpX264.Size = new System.Drawing.Size(408, 89);
            this.tpX264.TabIndex = 1;
            this.tpX264.Text = "x264 / x265";
            // 
            // pbx264PresetWarning
            // 
            this.pbx264PresetWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbx264PresetWarning.Location = new System.Drawing.Point(363, 47);
            this.pbx264PresetWarning.Margin = new System.Windows.Forms.Padding(4);
            this.pbx264PresetWarning.Name = "pbx264PresetWarning";
            this.pbx264PresetWarning.Size = new System.Drawing.Size(16, 16);
            this.pbx264PresetWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx264PresetWarning.TabIndex = 6;
            this.pbx264PresetWarning.TabStop = false;
            this.pbx264PresetWarning.Visible = false;
            // 
            // nudx264CRF
            // 
            this.nudx264CRF.Location = new System.Drawing.Point(192, 15);
            this.nudx264CRF.Margin = new System.Windows.Forms.Padding(4);
            this.nudx264CRF.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.nudx264CRF.Name = "nudx264CRF";
            this.nudx264CRF.Size = new System.Drawing.Size(64, 22);
            this.nudx264CRF.TabIndex = 1;
            this.nudx264CRF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudx264CRF.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudx264CRF.ValueChanged += new System.EventHandler(this.nudx264CRF_ValueChanged);
            // 
            // lblx264CRF
            // 
            this.lblx264CRF.AutoSize = true;
            this.lblx264CRF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblx264CRF.Location = new System.Drawing.Point(21, 20);
            this.lblx264CRF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx264CRF.Name = "lblx264CRF";
            this.lblx264CRF.Size = new System.Drawing.Size(39, 17);
            this.lblx264CRF.TabIndex = 0;
            this.lblx264CRF.Text = "CRF:";
            // 
            // cbx264Preset
            // 
            this.cbx264Preset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx264Preset.FormattingEnabled = true;
            this.cbx264Preset.Location = new System.Drawing.Point(192, 44);
            this.cbx264Preset.Margin = new System.Windows.Forms.Padding(4);
            this.cbx264Preset.Name = "cbx264Preset";
            this.cbx264Preset.Size = new System.Drawing.Size(160, 24);
            this.cbx264Preset.TabIndex = 3;
            this.cbx264Preset.SelectedIndexChanged += new System.EventHandler(this.cbx264Preset_SelectedIndexChanged);
            // 
            // lblx264Preset
            // 
            this.lblx264Preset.AutoSize = true;
            this.lblx264Preset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblx264Preset.Location = new System.Drawing.Point(21, 49);
            this.lblx264Preset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx264Preset.Name = "lblx264Preset";
            this.lblx264Preset.Size = new System.Drawing.Size(53, 17);
            this.lblx264Preset.TabIndex = 2;
            this.lblx264Preset.Text = "Preset:";
            // 
            // tpVpx
            // 
            this.tpVpx.BackColor = System.Drawing.SystemColors.Window;
            this.tpVpx.Controls.Add(this.lblVP8BitrateK);
            this.tpVpx.Controls.Add(this.nudVP8Bitrate);
            this.tpVpx.Controls.Add(this.lblVP8Bitrate);
            this.tpVpx.Location = new System.Drawing.Point(4, 25);
            this.tpVpx.Margin = new System.Windows.Forms.Padding(4);
            this.tpVpx.Name = "tpVpx";
            this.tpVpx.Size = new System.Drawing.Size(408, 89);
            this.tpVpx.TabIndex = 2;
            this.tpVpx.Text = "VP8";
            // 
            // lblVP8BitrateK
            // 
            this.lblVP8BitrateK.AutoSize = true;
            this.lblVP8BitrateK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVP8BitrateK.Location = new System.Drawing.Point(293, 20);
            this.lblVP8BitrateK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVP8BitrateK.Name = "lblVP8BitrateK";
            this.lblVP8BitrateK.Size = new System.Drawing.Size(41, 17);
            this.lblVP8BitrateK.TabIndex = 2;
            this.lblVP8BitrateK.Text = "kbit/s";
            // 
            // nudVP8Bitrate
            // 
            this.nudVP8Bitrate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudVP8Bitrate.Location = new System.Drawing.Point(192, 15);
            this.nudVP8Bitrate.Margin = new System.Windows.Forms.Padding(4);
            this.nudVP8Bitrate.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudVP8Bitrate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudVP8Bitrate.Name = "nudVP8Bitrate";
            this.nudVP8Bitrate.Size = new System.Drawing.Size(96, 22);
            this.nudVP8Bitrate.TabIndex = 1;
            this.nudVP8Bitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudVP8Bitrate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudVP8Bitrate.ValueChanged += new System.EventHandler(this.nudVP8Bitrate_ValueChanged);
            // 
            // lblVP8Bitrate
            // 
            this.lblVP8Bitrate.AutoSize = true;
            this.lblVP8Bitrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVP8Bitrate.Location = new System.Drawing.Point(21, 20);
            this.lblVP8Bitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVP8Bitrate.Name = "lblVP8Bitrate";
            this.lblVP8Bitrate.Size = new System.Drawing.Size(108, 17);
            this.lblVP8Bitrate.TabIndex = 0;
            this.lblVP8Bitrate.Text = "Variable bitrate:";
            // 
            // tpXvid
            // 
            this.tpXvid.BackColor = System.Drawing.SystemColors.Window;
            this.tpXvid.Controls.Add(this.nudXvidQscale);
            this.tpXvid.Controls.Add(this.lblXvidQscale);
            this.tpXvid.Location = new System.Drawing.Point(4, 25);
            this.tpXvid.Margin = new System.Windows.Forms.Padding(4);
            this.tpXvid.Name = "tpXvid";
            this.tpXvid.Size = new System.Drawing.Size(408, 89);
            this.tpXvid.TabIndex = 3;
            this.tpXvid.Text = "Xvid";
            // 
            // nudXvidQscale
            // 
            this.nudXvidQscale.Location = new System.Drawing.Point(192, 15);
            this.nudXvidQscale.Margin = new System.Windows.Forms.Padding(4);
            this.nudXvidQscale.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudXvidQscale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXvidQscale.Name = "nudXvidQscale";
            this.nudXvidQscale.Size = new System.Drawing.Size(64, 22);
            this.nudXvidQscale.TabIndex = 1;
            this.nudXvidQscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudXvidQscale.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudXvidQscale.ValueChanged += new System.EventHandler(this.nudXvidQscale_ValueChanged);
            // 
            // lblXvidQscale
            // 
            this.lblXvidQscale.AutoSize = true;
            this.lblXvidQscale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblXvidQscale.Location = new System.Drawing.Point(21, 20);
            this.lblXvidQscale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXvidQscale.Name = "lblXvidQscale";
            this.lblXvidQscale.Size = new System.Drawing.Size(108, 17);
            this.lblXvidQscale.TabIndex = 0;
            this.lblXvidQscale.Text = "Variable bitrate:";
            // 
            // tpNVENC
            // 
            this.tpNVENC.BackColor = System.Drawing.SystemColors.Window;
            this.tpNVENC.Controls.Add(this.cbNVENCPreset);
            this.tpNVENC.Controls.Add(this.lblNVENCPreset);
            this.tpNVENC.Controls.Add(this.nudNVENCBitrate);
            this.tpNVENC.Controls.Add(this.lblNVENCBitrate);
            this.tpNVENC.Location = new System.Drawing.Point(4, 25);
            this.tpNVENC.Margin = new System.Windows.Forms.Padding(4);
            this.tpNVENC.Name = "tpNVENC";
            this.tpNVENC.Padding = new System.Windows.Forms.Padding(4);
            this.tpNVENC.Size = new System.Drawing.Size(408, 89);
            this.tpNVENC.TabIndex = 5;
            this.tpNVENC.Text = "NVENC";
            // 
            // cbNVENCPreset
            // 
            this.cbNVENCPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNVENCPreset.FormattingEnabled = true;
            this.cbNVENCPreset.Location = new System.Drawing.Point(128, 15);
            this.cbNVENCPreset.Margin = new System.Windows.Forms.Padding(4);
            this.cbNVENCPreset.Name = "cbNVENCPreset";
            this.cbNVENCPreset.Size = new System.Drawing.Size(255, 24);
            this.cbNVENCPreset.TabIndex = 3;
            this.cbNVENCPreset.SelectedIndexChanged += new System.EventHandler(this.cbNVENCPreset_SelectedIndexChanged);
            // 
            // lblNVENCPreset
            // 
            this.lblNVENCPreset.AutoSize = true;
            this.lblNVENCPreset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNVENCPreset.Location = new System.Drawing.Point(21, 20);
            this.lblNVENCPreset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNVENCPreset.Name = "lblNVENCPreset";
            this.lblNVENCPreset.Size = new System.Drawing.Size(53, 17);
            this.lblNVENCPreset.TabIndex = 2;
            this.lblNVENCPreset.Text = "Preset:";
            // 
            // nudNVENCBitrate
            // 
            this.nudNVENCBitrate.Location = new System.Drawing.Point(128, 44);
            this.nudNVENCBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.nudNVENCBitrate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudNVENCBitrate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudNVENCBitrate.Name = "nudNVENCBitrate";
            this.nudNVENCBitrate.Size = new System.Drawing.Size(117, 22);
            this.nudNVENCBitrate.TabIndex = 1;
            this.nudNVENCBitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNVENCBitrate.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudNVENCBitrate.ValueChanged += new System.EventHandler(this.nudNVENCBitrate_ValueChanged);
            // 
            // lblNVENCBitrate
            // 
            this.lblNVENCBitrate.AutoSize = true;
            this.lblNVENCBitrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNVENCBitrate.Location = new System.Drawing.Point(21, 49);
            this.lblNVENCBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNVENCBitrate.Name = "lblNVENCBitrate";
            this.lblNVENCBitrate.Size = new System.Drawing.Size(53, 17);
            this.lblNVENCBitrate.TabIndex = 0;
            this.lblNVENCBitrate.Text = "Bitrate:";
            // 
            // tpGIF
            // 
            this.tpGIF.BackColor = System.Drawing.SystemColors.Window;
            this.tpGIF.Controls.Add(this.cbGIFDither);
            this.tpGIF.Controls.Add(this.lblGIFDither);
            this.tpGIF.Controls.Add(this.cbGIFStatsMode);
            this.tpGIF.Controls.Add(this.lblGIFStatsMode);
            this.tpGIF.Location = new System.Drawing.Point(4, 25);
            this.tpGIF.Margin = new System.Windows.Forms.Padding(4);
            this.tpGIF.Name = "tpGIF";
            this.tpGIF.Padding = new System.Windows.Forms.Padding(4);
            this.tpGIF.Size = new System.Drawing.Size(408, 89);
            this.tpGIF.TabIndex = 4;
            this.tpGIF.Text = "GIF";
            // 
            // cbGIFDither
            // 
            this.cbGIFDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGIFDither.FormattingEnabled = true;
            this.cbGIFDither.Location = new System.Drawing.Point(192, 44);
            this.cbGIFDither.Margin = new System.Windows.Forms.Padding(4);
            this.cbGIFDither.Name = "cbGIFDither";
            this.cbGIFDither.Size = new System.Drawing.Size(137, 24);
            this.cbGIFDither.TabIndex = 3;
            this.cbGIFDither.SelectedIndexChanged += new System.EventHandler(this.cbGIFDither_SelectedIndexChanged);
            // 
            // lblGIFDither
            // 
            this.lblGIFDither.AutoSize = true;
            this.lblGIFDither.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGIFDither.Location = new System.Drawing.Point(21, 49);
            this.lblGIFDither.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGIFDither.Name = "lblGIFDither";
            this.lblGIFDither.Size = new System.Drawing.Size(108, 17);
            this.lblGIFDither.TabIndex = 2;
            this.lblGIFDither.Text = "Dithering mode:";
            // 
            // cbGIFStatsMode
            // 
            this.cbGIFStatsMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGIFStatsMode.FormattingEnabled = true;
            this.cbGIFStatsMode.Location = new System.Drawing.Point(192, 15);
            this.cbGIFStatsMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbGIFStatsMode.Name = "cbGIFStatsMode";
            this.cbGIFStatsMode.Size = new System.Drawing.Size(137, 24);
            this.cbGIFStatsMode.TabIndex = 1;
            this.cbGIFStatsMode.SelectedIndexChanged += new System.EventHandler(this.cbGIFStatsMode_SelectedIndexChanged);
            // 
            // lblGIFStatsMode
            // 
            this.lblGIFStatsMode.AutoSize = true;
            this.lblGIFStatsMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGIFStatsMode.Location = new System.Drawing.Point(21, 20);
            this.lblGIFStatsMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGIFStatsMode.Name = "lblGIFStatsMode";
            this.lblGIFStatsMode.Size = new System.Drawing.Size(95, 17);
            this.lblGIFStatsMode.TabIndex = 0;
            this.lblGIFStatsMode.Text = "Palette mode:";
            // 
            // tbAMF
            // 
            this.tbAMF.Controls.Add(this.cbAMFQuality);
            this.tbAMF.Controls.Add(this.lblAMFQuality);
            this.tbAMF.Controls.Add(this.cbAMFUsage);
            this.tbAMF.Controls.Add(this.lblAMFUsage);
            this.tbAMF.Location = new System.Drawing.Point(4, 25);
            this.tbAMF.Margin = new System.Windows.Forms.Padding(4);
            this.tbAMF.Name = "tbAMF";
            this.tbAMF.Padding = new System.Windows.Forms.Padding(4);
            this.tbAMF.Size = new System.Drawing.Size(408, 89);
            this.tbAMF.TabIndex = 6;
            this.tbAMF.Text = "AMF";
            this.tbAMF.UseVisualStyleBackColor = true;
            // 
            // cbAMFQuality
            // 
            this.cbAMFQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAMFQuality.FormattingEnabled = true;
            this.cbAMFQuality.Location = new System.Drawing.Point(127, 49);
            this.cbAMFQuality.Margin = new System.Windows.Forms.Padding(4);
            this.cbAMFQuality.Name = "cbAMFQuality";
            this.cbAMFQuality.Size = new System.Drawing.Size(255, 24);
            this.cbAMFQuality.TabIndex = 7;
            this.cbAMFQuality.SelectedIndexChanged += new System.EventHandler(this.cbAMFQuality_SelectedIndexChanged);
            // 
            // lblAMFQuality
            // 
            this.lblAMFQuality.AutoSize = true;
            this.lblAMFQuality.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAMFQuality.Location = new System.Drawing.Point(20, 54);
            this.lblAMFQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAMFQuality.Name = "lblAMFQuality";
            this.lblAMFQuality.Size = new System.Drawing.Size(56, 17);
            this.lblAMFQuality.TabIndex = 6;
            this.lblAMFQuality.Text = "Quality:";
            // 
            // cbAMFUsage
            // 
            this.cbAMFUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAMFUsage.FormattingEnabled = true;
            this.cbAMFUsage.Location = new System.Drawing.Point(127, 16);
            this.cbAMFUsage.Margin = new System.Windows.Forms.Padding(4);
            this.cbAMFUsage.Name = "cbAMFUsage";
            this.cbAMFUsage.Size = new System.Drawing.Size(255, 24);
            this.cbAMFUsage.TabIndex = 5;
            this.cbAMFUsage.SelectedIndexChanged += new System.EventHandler(this.cbAMFUsage_SelectedIndexChanged);
            // 
            // lblAMFUsage
            // 
            this.lblAMFUsage.AutoSize = true;
            this.lblAMFUsage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAMFUsage.Location = new System.Drawing.Point(20, 21);
            this.lblAMFUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAMFUsage.Name = "lblAMFUsage";
            this.lblAMFUsage.Size = new System.Drawing.Size(53, 17);
            this.lblAMFUsage.TabIndex = 4;
            this.lblAMFUsage.Text = "Usage:";
            // 
            // tbQSV
            // 
            this.tbQSV.Controls.Add(this.cbQSVPreset);
            this.tbQSV.Controls.Add(this.lblQSVPreset);
            this.tbQSV.Controls.Add(this.nudQSVBitrate);
            this.tbQSV.Controls.Add(this.lblQSVBitrate);
            this.tbQSV.Location = new System.Drawing.Point(4, 25);
            this.tbQSV.Margin = new System.Windows.Forms.Padding(4);
            this.tbQSV.Name = "tbQSV";
            this.tbQSV.Padding = new System.Windows.Forms.Padding(4);
            this.tbQSV.Size = new System.Drawing.Size(408, 89);
            this.tbQSV.TabIndex = 7;
            this.tbQSV.Text = "QuickSync";
            this.tbQSV.UseVisualStyleBackColor = true;
            // 
            // cbQSVPreset
            // 
            this.cbQSVPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQSVPreset.FormattingEnabled = true;
            this.cbQSVPreset.Location = new System.Drawing.Point(128, 16);
            this.cbQSVPreset.Margin = new System.Windows.Forms.Padding(4);
            this.cbQSVPreset.Name = "cbQSVPreset";
            this.cbQSVPreset.Size = new System.Drawing.Size(255, 24);
            this.cbQSVPreset.TabIndex = 7;
            this.cbQSVPreset.SelectedIndexChanged += new System.EventHandler(this.cbQSVPreset_SelectedIndexChanged);
            // 
            // lblQSVPreset
            // 
            this.lblQSVPreset.AutoSize = true;
            this.lblQSVPreset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQSVPreset.Location = new System.Drawing.Point(21, 21);
            this.lblQSVPreset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQSVPreset.Name = "lblQSVPreset";
            this.lblQSVPreset.Size = new System.Drawing.Size(53, 17);
            this.lblQSVPreset.TabIndex = 6;
            this.lblQSVPreset.Text = "Preset:";
            // 
            // nudQSVBitrate
            // 
            this.nudQSVBitrate.Location = new System.Drawing.Point(128, 46);
            this.nudQSVBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.nudQSVBitrate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudQSVBitrate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudQSVBitrate.Name = "nudQSVBitrate";
            this.nudQSVBitrate.Size = new System.Drawing.Size(117, 22);
            this.nudQSVBitrate.TabIndex = 5;
            this.nudQSVBitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudQSVBitrate.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudQSVBitrate.ValueChanged += new System.EventHandler(this.nudQSVBitrate_ValueChanged);
            // 
            // lblQSVBitrate
            // 
            this.lblQSVBitrate.AutoSize = true;
            this.lblQSVBitrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQSVBitrate.Location = new System.Drawing.Point(21, 50);
            this.lblQSVBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQSVBitrate.Name = "lblQSVBitrate";
            this.lblQSVBitrate.Size = new System.Drawing.Size(53, 17);
            this.lblQSVBitrate.TabIndex = 4;
            this.lblQSVBitrate.Text = "Bitrate:";
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.cboAudioSource);
            this.gbSource.Controls.Add(this.lblAudioSource);
            this.gbSource.Controls.Add(this.cboVideoSource);
            this.gbSource.Controls.Add(this.lblVideoSource);
            this.gbSource.Controls.Add(this.btnRefreshSources);
            this.gbSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSource.Location = new System.Drawing.Point(3, 58);
            this.gbSource.Margin = new System.Windows.Forms.Padding(4);
            this.gbSource.Name = "gbSource";
            this.gbSource.Padding = new System.Windows.Forms.Padding(4);
            this.gbSource.Size = new System.Drawing.Size(853, 52);
            this.gbSource.TabIndex = 2;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Sources";
            // 
            // cboAudioSource
            // 
            this.cboAudioSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboAudioSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAudioSource.FormattingEnabled = true;
            this.cboAudioSource.Location = new System.Drawing.Point(495, 19);
            this.cboAudioSource.Margin = new System.Windows.Forms.Padding(4);
            this.cboAudioSource.Name = "cboAudioSource";
            this.cboAudioSource.Size = new System.Drawing.Size(211, 24);
            this.cboAudioSource.TabIndex = 4;
            this.cboAudioSource.SelectedIndexChanged += new System.EventHandler(this.cboAudioSource_SelectedIndexChanged);
            // 
            // lblAudioSource
            // 
            this.lblAudioSource.AutoSize = true;
            this.lblAudioSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAudioSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAudioSource.Location = new System.Drawing.Point(400, 19);
            this.lblAudioSource.Margin = new System.Windows.Forms.Padding(4, 800, 4, 0);
            this.lblAudioSource.Name = "lblAudioSource";
            this.lblAudioSource.Size = new System.Drawing.Size(95, 17);
            this.lblAudioSource.TabIndex = 3;
            this.lblAudioSource.Text = "Audio source:";
            // 
            // cboVideoSource
            // 
            this.cboVideoSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboVideoSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoSource.FormattingEnabled = true;
            this.cboVideoSource.Location = new System.Drawing.Point(176, 19);
            this.cboVideoSource.Margin = new System.Windows.Forms.Padding(4);
            this.cboVideoSource.Name = "cboVideoSource";
            this.cboVideoSource.Size = new System.Drawing.Size(224, 24);
            this.cboVideoSource.TabIndex = 2;
            this.cboVideoSource.SelectedIndexChanged += new System.EventHandler(this.cboVideoSource_SelectedIndexChanged);
            // 
            // lblVideoSource
            // 
            this.lblVideoSource.AutoSize = true;
            this.lblVideoSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVideoSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVideoSource.Location = new System.Drawing.Point(81, 19);
            this.lblVideoSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVideoSource.Name = "lblVideoSource";
            this.lblVideoSource.Size = new System.Drawing.Size(95, 17);
            this.lblVideoSource.TabIndex = 1;
            this.lblVideoSource.Text = "Video source:";
            // 
            // btnRefreshSources
            // 
            this.btnRefreshSources.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefreshSources.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshSources.Location = new System.Drawing.Point(4, 19);
            this.btnRefreshSources.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshSources.Name = "btnRefreshSources";
            this.btnRefreshSources.Size = new System.Drawing.Size(77, 29);
            this.btnRefreshSources.TabIndex = 0;
            this.btnRefreshSources.Text = "Refresh";
            this.btnRefreshSources.UseVisualStyleBackColor = true;
            this.btnRefreshSources.Click += new System.EventHandler(this.btnRefreshSources_Click);
            // 
            // gbFFmpegExe
            // 
            this.gbFFmpegExe.Controls.Add(this.btnDownload);
            this.gbFFmpegExe.Controls.Add(this.ffmpeg_path);
            this.gbFFmpegExe.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFFmpegExe.Location = new System.Drawing.Point(3, 3);
            this.gbFFmpegExe.Margin = new System.Windows.Forms.Padding(4);
            this.gbFFmpegExe.Name = "gbFFmpegExe";
            this.gbFFmpegExe.Padding = new System.Windows.Forms.Padding(4);
            this.gbFFmpegExe.Size = new System.Drawing.Size(853, 55);
            this.gbFFmpegExe.TabIndex = 1;
            this.gbFFmpegExe.TabStop = false;
            this.gbFFmpegExe.Text = "FFmpeg path";
            // 
            // btnDownload
            // 
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDownload.Location = new System.Drawing.Point(732, 19);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(117, 32);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // ffmpeg_path
            // 
            this.ffmpeg_path.AutoSize = true;
            this.ffmpeg_path.Dock = System.Windows.Forms.DockStyle.Left;
            this.ffmpeg_path.Location = new System.Drawing.Point(4, 19);
            this.ffmpeg_path.Name = "ffmpeg_path";
            this.ffmpeg_path.Size = new System.Drawing.Size(46, 17);
            this.ffmpeg_path.TabIndex = 3;
            this.ffmpeg_path.Text = "label1";
            // 
            // LngAdd
            // 
            this.LngAdd.Location = new System.Drawing.Point(557, 152);
            this.LngAdd.Margin = new System.Windows.Forms.Padding(4);
            this.LngAdd.Name = "LngAdd";
            this.LngAdd.Size = new System.Drawing.Size(64, 28);
            this.LngAdd.TabIndex = 11;
            this.LngAdd.Text = "Add";
            this.LngAdd.UseVisualStyleBackColor = true;
            this.LngAdd.Click += new System.EventHandler(this.LngAdd_Click);
            // 
            // LngCode
            // 
            this.LngCode.Location = new System.Drawing.Point(498, 156);
            this.LngCode.Margin = new System.Windows.Forms.Padding(4);
            this.LngCode.MaxLength = 3;
            this.LngCode.Name = "LngCode";
            this.LngCode.Size = new System.Drawing.Size(51, 22);
            this.LngCode.TabIndex = 12;
            this.LngCode.Text = "en";
            this.LngCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hiInkVisible
            // 
            this.hiInkVisible.BackColor = System.Drawing.Color.White;
            this.hiInkVisible.ExternalConflictFlag = false;
            this.hiInkVisible.Hotkey = hotkey1;
            this.hiInkVisible.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiInkVisible.Location = new System.Drawing.Point(453, 249);
            this.hiInkVisible.Margin = new System.Windows.Forms.Padding(4);
            this.hiInkVisible.Name = "hiInkVisible";
            this.hiInkVisible.RequireModifier = false;
            this.hiInkVisible.Size = new System.Drawing.Size(159, 22);
            this.hiInkVisible.TabIndex = 17;
            this.hiInkVisible.Text = "None";
            this.hiInkVisible.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiSnapshot
            // 
            this.hiSnapshot.BackColor = System.Drawing.Color.White;
            this.hiSnapshot.ExternalConflictFlag = false;
            this.hiSnapshot.Hotkey = hotkey2;
            this.hiSnapshot.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiSnapshot.Location = new System.Drawing.Point(453, 282);
            this.hiSnapshot.Margin = new System.Windows.Forms.Padding(4);
            this.hiSnapshot.Name = "hiSnapshot";
            this.hiSnapshot.RequireModifier = false;
            this.hiSnapshot.Size = new System.Drawing.Size(159, 22);
            this.hiSnapshot.TabIndex = 14;
            this.hiSnapshot.Text = "None";
            this.hiSnapshot.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiClear
            // 
            this.hiClear.BackColor = System.Drawing.Color.White;
            this.hiClear.ExternalConflictFlag = false;
            this.hiClear.Hotkey = hotkey3;
            this.hiClear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiClear.Location = new System.Drawing.Point(453, 382);
            this.hiClear.Margin = new System.Windows.Forms.Padding(4);
            this.hiClear.Name = "hiClear";
            this.hiClear.RequireModifier = false;
            this.hiClear.Size = new System.Drawing.Size(159, 22);
            this.hiClear.TabIndex = 15;
            this.hiClear.Text = "None";
            this.hiClear.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiPan
            // 
            this.hiPan.BackColor = System.Drawing.Color.White;
            this.hiPan.ExternalConflictFlag = false;
            this.hiPan.Hotkey = hotkey4;
            this.hiPan.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiPan.Location = new System.Drawing.Point(453, 181);
            this.hiPan.Margin = new System.Windows.Forms.Padding(4);
            this.hiPan.Name = "hiPan";
            this.hiPan.RequireModifier = false;
            this.hiPan.Size = new System.Drawing.Size(159, 22);
            this.hiPan.TabIndex = 11;
            this.hiPan.Text = "None";
            this.hiPan.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiPointer
            // 
            this.hiPointer.BackColor = System.Drawing.Color.White;
            this.hiPointer.ExternalConflictFlag = false;
            this.hiPointer.Hotkey = hotkey5;
            this.hiPointer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiPointer.Location = new System.Drawing.Point(453, 215);
            this.hiPointer.Margin = new System.Windows.Forms.Padding(4);
            this.hiPointer.Name = "hiPointer";
            this.hiPointer.RequireModifier = false;
            this.hiPointer.Size = new System.Drawing.Size(159, 22);
            this.hiPointer.TabIndex = 8;
            this.hiPointer.Text = "None";
            this.hiPointer.Visible = false;
            this.hiPointer.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiRedo
            // 
            this.hiRedo.BackColor = System.Drawing.Color.White;
            this.hiRedo.ExternalConflictFlag = false;
            this.hiRedo.Hotkey = hotkey6;
            this.hiRedo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiRedo.Location = new System.Drawing.Point(453, 348);
            this.hiRedo.Margin = new System.Windows.Forms.Padding(4);
            this.hiRedo.Name = "hiRedo";
            this.hiRedo.RequireModifier = false;
            this.hiRedo.Size = new System.Drawing.Size(159, 22);
            this.hiRedo.TabIndex = 9;
            this.hiRedo.Text = "None";
            this.hiRedo.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiUndo
            // 
            this.hiUndo.BackColor = System.Drawing.Color.White;
            this.hiUndo.ExternalConflictFlag = false;
            this.hiUndo.Hotkey = hotkey7;
            this.hiUndo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiUndo.Location = new System.Drawing.Point(453, 315);
            this.hiUndo.Margin = new System.Windows.Forms.Padding(4);
            this.hiUndo.Name = "hiUndo";
            this.hiUndo.RequireModifier = false;
            this.hiUndo.Size = new System.Drawing.Size(159, 22);
            this.hiUndo.TabIndex = 5;
            this.hiUndo.Text = "None";
            this.hiUndo.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiEraser
            // 
            this.hiEraser.BackColor = System.Drawing.Color.White;
            this.hiEraser.ExternalConflictFlag = false;
            this.hiEraser.Hotkey = hotkey8;
            this.hiEraser.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiEraser.Location = new System.Drawing.Point(453, 148);
            this.hiEraser.Margin = new System.Windows.Forms.Padding(4);
            this.hiEraser.Name = "hiEraser";
            this.hiEraser.RequireModifier = false;
            this.hiEraser.Size = new System.Drawing.Size(159, 22);
            this.hiEraser.TabIndex = 5;
            this.hiEraser.Text = "None";
            this.hiEraser.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // hiGlobal
            // 
            this.hiGlobal.BackColor = System.Drawing.Color.White;
            this.hiGlobal.ExternalConflictFlag = false;
            this.hiGlobal.Hotkey = hotkey9;
            this.hiGlobal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hiGlobal.Location = new System.Drawing.Point(25, 48);
            this.hiGlobal.Margin = new System.Windows.Forms.Padding(4);
            this.hiGlobal.Name = "hiGlobal";
            this.hiGlobal.RequireModifier = true;
            this.hiGlobal.Size = new System.Drawing.Size(159, 22);
            this.hiGlobal.TabIndex = 5;
            this.hiGlobal.Text = "None";
            this.hiGlobal.OnHotkeyChanged += new System.EventHandler(this.hi_OnHotkeyChanged);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(867, 640);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options - gInk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptions_FormClosing);
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolbar_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.Record.ResumeLayout(false);
            this.gbCommandLinePreview.ResumeLayout(false);
            this.gbCommandLinePreview.PerformLayout();
            this.WaterMark.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_opacity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_X)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermark_show)).EndInit();
            this.gbCommandLineArgs.ResumeLayout(false);
            this.gbCommandLineArgs.PerformLayout();
            this.gbCodecs.ResumeLayout(false);
            this.gbCodecs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAudioCodecWarning)).EndInit();
            this.tcFFmpegAudioCodecs.ResumeLayout(false);
            this.tpAAC.ResumeLayout(false);
            this.tpAAC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAACBitrate)).EndInit();
            this.tpOpus.ResumeLayout(false);
            this.tpOpus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpusBitrate)).EndInit();
            this.tpVorbis.ResumeLayout(false);
            this.tpVorbis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVorbis_qscale)).EndInit();
            this.tpMP3.ResumeLayout(false);
            this.tpMP3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMP3_qscale)).EndInit();
            this.tcFFmpegVideoCodecs.ResumeLayout(false);
            this.tpX264.ResumeLayout(false);
            this.tpX264.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx264PresetWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudx264CRF)).EndInit();
            this.tpVpx.ResumeLayout(false);
            this.tpVpx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVP8Bitrate)).EndInit();
            this.tpXvid.ResumeLayout(false);
            this.tpXvid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudXvidQscale)).EndInit();
            this.tpNVENC.ResumeLayout(false);
            this.tpNVENC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNVENCBitrate)).EndInit();
            this.tpGIF.ResumeLayout(false);
            this.tpGIF.PerformLayout();
            this.tbAMF.ResumeLayout(false);
            this.tbAMF.PerformLayout();
            this.tbQSV.ResumeLayout(false);
            this.tbQSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQSVBitrate)).EndInit();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbFFmpegExe.ResumeLayout(false);
            this.gbFFmpegExe.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox cbEraserEnabled;
		private System.Windows.Forms.CheckBox cbPointerEnabled;
		private System.Windows.Forms.CheckBox cbSnapEnabled;
		private System.Windows.Forms.CheckBox cbUndoEnabled;
		private System.Windows.Forms.CheckBox cbClearEnabled;
		private System.Windows.Forms.CheckBox cbWidthEnabled;
		private System.Windows.Forms.CheckBox cbWhiteIcon;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox tbSnapPath;
		private System.Windows.Forms.Label lbSnapshotsavepath;
		private System.Windows.Forms.Button btSnapPath;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbCanvascursor;
		private System.Windows.Forms.ComboBox comboCanvasCursor;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label lbGlobalHotkey;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckBox cbInkVisibleEnabled;
		private System.Windows.Forms.CheckBox cbPanEnabled;
		private System.Windows.Forms.CheckBox cbAllowDragging;
		private HotkeyInputBox hiGlobal;
		private HotkeyInputBox hiEraser;
		private System.Windows.Forms.Label lbHkEraser;
		private HotkeyInputBox hiUndo;
		private System.Windows.Forms.Label lbHkUndo;
		private HotkeyInputBox hiPointer;
		private HotkeyInputBox hiRedo;
		private System.Windows.Forms.Label lbHkPointer;
		private System.Windows.Forms.Label lbHkRedo;
		private HotkeyInputBox hiSnapshot;
		private HotkeyInputBox hiClear;
		private System.Windows.Forms.Label lbHkSnapshot;
		private System.Windows.Forms.Label lbHkClear;
		private HotkeyInputBox hiPan;
		private System.Windows.Forms.Label lbHkPan;
		private HotkeyInputBox hiInkVisible;
		private System.Windows.Forms.Label lbHkInkVisible;
		private System.Windows.Forms.CheckBox cbAllowHotkeyInPointer;
		private System.Windows.Forms.ComboBox comboLanguage;
		private System.Windows.Forms.Label lbLanguage;
		private System.Windows.Forms.TabPage Record;
		private System.Windows.Forms.GroupBox gbFFmpegExe;
		private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label ffmpeg_path;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.ComboBox cboVideoSource;
        private System.Windows.Forms.Label lblVideoSource;
        private System.Windows.Forms.ComboBox cboAudioSource;
        private System.Windows.Forms.Label lblAudioSource;
        private System.Windows.Forms.Button btnRefreshSources;
        private System.Windows.Forms.GroupBox gbCodecs;
        private System.Windows.Forms.PictureBox pbAudioCodecWarning;
        private System.Windows.Forms.ComboBox cboAudioCodec;
        private System.Windows.Forms.Label lblAudioCodec;
        private System.Windows.Forms.ComboBox cboVideoCodec;
        private System.Windows.Forms.Label lblCodec;
        private System.Windows.Forms.TabControl tcFFmpegAudioCodecs;
        private System.Windows.Forms.TabPage tpAAC;
        private System.Windows.Forms.TrackBar tbAACBitrate;
        private System.Windows.Forms.Label lblAACQuality;
        private System.Windows.Forms.TabPage tpOpus;
        private System.Windows.Forms.TrackBar tbOpusBitrate;
        private System.Windows.Forms.Label lblOpusQuality;
        private System.Windows.Forms.TabPage tpVorbis;
        private System.Windows.Forms.TrackBar tbVorbis_qscale;
        private System.Windows.Forms.Label lblVorbisQuality;
        private System.Windows.Forms.TabPage tpMP3;
        private System.Windows.Forms.TrackBar tbMP3_qscale;
        private System.Windows.Forms.Label lblMP3Quality;
        private System.Windows.Forms.TabControl tcFFmpegVideoCodecs;
        private System.Windows.Forms.TabPage tpX264;
        private System.Windows.Forms.PictureBox pbx264PresetWarning;
        private System.Windows.Forms.NumericUpDown nudx264CRF;
        private System.Windows.Forms.Label lblx264CRF;
        private System.Windows.Forms.ComboBox cbx264Preset;
        private System.Windows.Forms.Label lblx264Preset;
        private System.Windows.Forms.TabPage tpVpx;
        private System.Windows.Forms.Label lblVP8BitrateK;
        private System.Windows.Forms.NumericUpDown nudVP8Bitrate;
        private System.Windows.Forms.Label lblVP8Bitrate;
        private System.Windows.Forms.TabPage tpXvid;
        private System.Windows.Forms.NumericUpDown nudXvidQscale;
        private System.Windows.Forms.Label lblXvidQscale;
        private System.Windows.Forms.TabPage tpNVENC;
        private System.Windows.Forms.ComboBox cbNVENCPreset;
        private System.Windows.Forms.Label lblNVENCPreset;
        private System.Windows.Forms.NumericUpDown nudNVENCBitrate;
        private System.Windows.Forms.Label lblNVENCBitrate;
        private System.Windows.Forms.TabPage tpGIF;
        private System.Windows.Forms.ComboBox cbGIFDither;
        private System.Windows.Forms.Label lblGIFDither;
        private System.Windows.Forms.ComboBox cbGIFStatsMode;
        private System.Windows.Forms.Label lblGIFStatsMode;
        private System.Windows.Forms.TabPage tbAMF;
        private System.Windows.Forms.ComboBox cbAMFQuality;
        private System.Windows.Forms.Label lblAMFQuality;
        private System.Windows.Forms.ComboBox cbAMFUsage;
        private System.Windows.Forms.Label lblAMFUsage;
        private System.Windows.Forms.TabPage tbQSV;
        private System.Windows.Forms.ComboBox cbQSVPreset;
        private System.Windows.Forms.Label lblQSVPreset;
        private System.Windows.Forms.NumericUpDown nudQSVBitrate;
        private System.Windows.Forms.Label lblQSVBitrate;
        private System.Windows.Forms.GroupBox gbCommandLinePreview;
        private System.Windows.Forms.TextBox txtCommandLinePreview;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox WaterMark;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label watermark_opacity_text;
        private System.Windows.Forms.TrackBar watermark_opacity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown watermark_Y;
        private System.Windows.Forms.NumericUpDown watermark_X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton watermark_location_right;
        private System.Windows.Forms.RadioButton watermark_location_left;
        private System.Windows.Forms.RadioButton watermark_location_top;
        private System.Windows.Forms.RadioButton watermark_location_bottom;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox watermark_show;
        private System.Windows.Forms.CheckBox watermark_use;
        private System.Windows.Forms.GroupBox gbCommandLineArgs;
        private System.Windows.Forms.TextBox tbUserArgs;
        private System.Windows.Forms.NumericUpDown toolbar_size;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LngCode;
        private System.Windows.Forms.Button LngAdd;
    }
}