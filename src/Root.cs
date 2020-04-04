using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Ink;
using System.Threading.Tasks;

namespace gInk
{
    public class TestMessageFilter : IMessageFilter
    {
        public Root Root;

        public TestMessageFilter(Root root)
        {
            Root = root;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                //int modifier = (int)m.LParam & 0xFFFF;       // The modifier of the hotkey that was pressed.
                //int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (Root.FormCollection == null && Root.FormDisplay == null)
                    Root.StartInk();
                else if (Root.PointerMode)
                {
                    //Root.UnPointer();
                    Root.SelectPen(Root.LastPen);
                }
                else
                {
                    //Root.Pointer();
                    Root.SelectPen(-2);
                }
            }
            return false;
        }
    }

    public class Root
    {
        gInkOptions gInkOptions;
        public Language Language;
        public int gpButtonsLeft, gpButtonsTop;

        // advanced options
        public string CloseOnSnap = "blankonly";
        public bool AlwaysHideToolbar = false;

        public bool AutoScroll;

        public bool EraserMode = false;
        public bool Docked = false;

        public bool PointerMode = false;
        public bool FingerInAction = false;  // true when mouse down, either drawing or snapping or whatever
        public int Snapping = 0;  // <=0: not snapping, 1: waiting finger, 2:dragging
        public int SnappingX = -1, SnappingY = -1;
        public Rectangle SnappingRect;
        public int UponButtonsUpdate = 0;
        public bool UponTakingSnap = false;
        public bool UponBalloonSnap = false;
        public bool UponSubPanelUpdate = false;
        public bool UponAllDrawingUpdate = false;
        public bool MouseMovedUnderSnapshotDragging = false; // used to pause re-drawing when mouse is not moving during dragging to take a screenshot

        public bool PanMode = false;
        public bool InkVisible = true;

        public Ink[] UndoStrokes;
        //public Ink UponUndoStrokes;
        public int UndoP;
        public int UndoDepth, RedoDepth;

        public NotifyIcon trayIcon;
        public ContextMenu trayMenu;
        public FormCollection FormCollection;
        public FormDisplay FormDisplay;
        public FormButtonHitter FormButtonHitter;
        public FormOptions FormOptions;

        public int CurrentPen = 1;  // defaut pen
        public int LastPen = 1;
        public int GlobalPenWidth = 80;
        public bool gpPenWidthVisible = false;
        public string SnapshotFileFullPath = ""; // used to record the last snapshot file name, to select it when the balloon is clicked

        public Root()
        {
            ///Load setting using files in folder
            string Settigs = Directory.GetCurrentDirectory() + "\\Settings";
            if (!Directory.Exists(Settigs))
                Directory.CreateDirectory(Settigs);
            Settigs = Directory.GetCurrentDirectory() + "\\Languages";
            if (!Directory.Exists(Settigs))
                Directory.CreateDirectory(Settigs);

            gInkOptions = new gInkOptions();
            if (gInkOptions.PenAttr[0] == null)
                SetDefaultPens();
            if (gInkOptions.Hotkey_Global == null)
                SetDefaultConfig();
            if (gInkOptions.Hotkey_Pens[0] == null)
                for (int p = 0; p < gInkOptions.MaxPenCount; p++)
                    gInkOptions.Hotkey_Pens[p] = new Hotkey();

            gInkOptions.Save();

            Language = new Language(gInkOptions.Language);

            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add(Language.RecordStart, OnRecord);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Language.MenuEntryAbout + "...", OnAbout);
            trayMenu.MenuItems.Add(Language.MenuEntryOptions + "...", OnOptions);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Language.MenuEntryExit, OnExit);

            Size size = SystemInformation.SmallIconSize;
            trayIcon = new NotifyIcon();
            trayIcon.Text = "gRec";
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            trayIcon.MouseClick += TrayIcon_Click;
            trayIcon.BalloonTipText = Language.NotificationSnapshot;
            trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;
            //trayIcon.BalloonTipClosed += delegate { isRecord = false; } ;
            trayIcon.Icon = global::gInk.Properties.Resources.g_rec1;

            SetHotkey();

            TestMessageFilter mf = new TestMessageFilter(this);
            Application.AddMessageFilter(mf);

            FormCollection = null;
            FormDisplay = null;
        }
        public bool isRecord = false;
        string recordPath = "";
        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            //string snapbasepath = SnapshotBasePath;
            //snapbasepath = Environment.ExpandEnvironmentVariables(snapbasepath);
            //System.Diagnostics.Process.Start(snapbasepath);

            string fullpath = (isRecord && recordPath.Length > 4) ? recordPath : Path.GetFullPath(SnapshotFileFullPath);
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", fullpath));
            isRecord = false;
        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (FormDisplay == null && FormCollection == null)
                {
                    StartInk();
                }
                else if (Docked)
                    UnDock();
            }
        }

        public void StartInk()
        {
            if (FormDisplay != null || FormCollection != null)
                return;

            //Docked = false;
            FormDisplay = new FormDisplay(this);
            FormCollection = new FormCollection(this);
            FormButtonHitter = new FormButtonHitter(this);
            if (CurrentPen < 0)
                CurrentPen = 0;
            if (!gInkOptions.PenEnabled[CurrentPen])
            {
                CurrentPen = 0;
                while (CurrentPen < gInkOptions.MaxPenCount && !gInkOptions.PenEnabled[CurrentPen])
                    CurrentPen++;
                if (CurrentPen == gInkOptions.MaxPenCount)
                    CurrentPen = -2;
            }
            SelectPen(CurrentPen);
            SetInkVisible(true);
            FormCollection.ButtonsEntering = 1;
            FormDisplay.Show();
            FormCollection.Show();
            FormDisplay.DrawButtons(true);

            if (UndoStrokes == null)
            {
                UndoStrokes = new Ink[8];
                UndoStrokes[0] = FormCollection.IC.Ink.Clone();
                UndoDepth = 0;
                UndoP = 0;
            }

            //UponUndoStrokes = FormCollection.IC.Ink.Clone();
        }
        public void StopInk()
        {
            FormCollection.Close();
            FormDisplay.Close();
            FormButtonHitter.Close();
            //FormCollection.Dispose();
            //FormDisplay.Dispose();
            GC.Collect();
            FormCollection = null;
            FormDisplay = null;

            if (UponBalloonSnap)
            {
                ShowBalloonSnapshot();
                UponBalloonSnap = false;
            }
        }

        public void ClearInk()
        {
            FormCollection.IC.Ink.DeleteStrokes();
            FormDisplay.ClearCanvus();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void ShowBalloonSnapshot()
        {
            trayIcon.ShowBalloonTip(3000);
        }

        public void UndoInk()
        {
            if (UndoDepth <= 0)
                return;

            UndoP--;
            if (UndoP < 0)
                UndoP = UndoStrokes.GetLength(0) - 1;
            UndoDepth--;
            RedoDepth++;
            FormCollection.IC.Ink.DeleteStrokes();
            if (UndoStrokes[UndoP].Strokes.Count > 0)
                FormCollection.IC.Ink.AddStrokesAtRectangle(UndoStrokes[UndoP].Strokes, UndoStrokes[UndoP].Strokes.GetBoundingBox());

            FormDisplay.ClearCanvus();
            FormDisplay.DrawStrokes();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void Pan(int x, int y)
        {
            if (x == 0 && y == 0)
                return;

            FormCollection.IC.Ink.Strokes.Move(x, y);

            FormDisplay.ClearCanvus();
            FormDisplay.DrawStrokes();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void SetInkVisible(bool visible)
        {
            InkVisible = visible;
            if (visible)
                FormCollection.btInkVisible.Image = FormCollection.image_visible;
            else
                FormCollection.btInkVisible.Image = FormCollection.image_visible_not;

            FormDisplay.ClearCanvus();
            FormDisplay.DrawStrokes();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void RedoInk()
        {
            if (RedoDepth <= 0)
                return;

            UndoDepth++;
            RedoDepth--;
            UndoP++;
            if (UndoP >= UndoStrokes.GetLength(0))
                UndoP = 0;
            FormCollection.IC.Ink.DeleteStrokes();
            if (UndoStrokes[UndoP].Strokes.Count > 0)
                FormCollection.IC.Ink.AddStrokesAtRectangle(UndoStrokes[UndoP].Strokes, UndoStrokes[UndoP].Strokes.GetBoundingBox());

            FormDisplay.ClearCanvus();
            FormDisplay.DrawStrokes();
            FormDisplay.DrawButtons(true);
            FormDisplay.UpdateFormDisplay(true);
        }

        public void Dock()
        {
            if (FormDisplay == null || FormCollection == null)
                return;

            Docked = true;
            gpPenWidthVisible = false;
            FormCollection.btDock.Image = FormCollection.image_dockback;
            FormCollection.ButtonsEntering = -1;
            UponButtonsUpdate |= 0x2;
        }

        public void UnDock()
        {
            if (FormDisplay == null || FormCollection == null)
                return;

            Docked = false;
            FormCollection.btDock.Image = FormCollection.image_dock;
            FormCollection.ButtonsEntering = 1;
            UponButtonsUpdate |= 0x2;
        }

        public void Pointer()
        {
            if (PointerMode)
                return;

            PointerMode = true;
            FormCollection.ToThrough();
            FormButtonHitter.Show();
        }

        public void UnPointer()
        {
            if (!PointerMode)
                return;

            PointerMode = false;
            FormCollection.ToUnThrough();
            FormCollection.ToTopMost();
            FormCollection.Activate();

            FormButtonHitter.Hide();
        }

        public void SelectPen(int pen)
        {
            FormCollection.SelectPen(pen);
        }

        public void SetDefaultPens()
        {
            for (int i = 0; i < gInkOptions.MaxPenCount; i++)
            {
                gInkOptions.PenEnabled[i] = (i < 7);
                gInkOptions.PenAttr[i] = new DrawingAttributes();
            }

            gInkOptions.PenAttr[0].Color = Color.FromArgb(255, 0, 0);
            gInkOptions.PenAttr[0].Width = 80;
            gInkOptions.PenAttr[0].Transparency = 0;

            gInkOptions.PenAttr[1].Color = Color.FromArgb(0, 255, 0);
            gInkOptions.PenAttr[1].Width = 80;
            gInkOptions.PenAttr[1].Transparency = 0;

            gInkOptions.PenAttr[2].Color = Color.FromArgb(0, 0, 255);
            gInkOptions.PenAttr[2].Width = 80;
            gInkOptions.PenAttr[2].Transparency = 0;

            gInkOptions.PenAttr[3].Color = Color.FromArgb(0, 0, 0);
            gInkOptions.PenAttr[3].Width = 80;
            gInkOptions.PenAttr[3].Transparency = 0;

            gInkOptions.PenAttr[4].Color = Color.FromArgb(120, 175, 70);
            gInkOptions.PenAttr[4].Width = 250;
            gInkOptions.PenAttr[4].Transparency = 127;

            gInkOptions.PenAttr[5].Color = Color.FromArgb(235, 125, 15);
            gInkOptions.PenAttr[5].Width = 500;
            gInkOptions.PenAttr[5].Transparency = 175;

            gInkOptions.PenAttr[6].Color = Color.FromArgb(230, 230, 230);
            gInkOptions.PenAttr[6].Width = 80;
            gInkOptions.PenAttr[6].Transparency = 0;

            gInkOptions.PenAttr[7].Color = Color.FromArgb(250, 140, 200);
            gInkOptions.PenAttr[7].Width = 80;
            gInkOptions.PenAttr[7].Transparency = 0;

            gInkOptions.PenAttr[8].Color = Color.FromArgb(25, 180, 175);
            gInkOptions.PenAttr[8].Width = 80;
            gInkOptions.PenAttr[8].Transparency = 0;

            gInkOptions.PenAttr[9].Color = Color.FromArgb(145, 70, 160);
            gInkOptions.PenAttr[9].Width = 500;
            gInkOptions.PenAttr[9].Transparency = 175;

        }

        public void SetDefaultConfig()
        {
            gInkOptions.Hotkey_Global.Control = true;
            gInkOptions.Hotkey_Global.Alt = true;
            gInkOptions.Hotkey_Global.Shift = false;
            gInkOptions.Hotkey_Global.Win = false;
            gInkOptions.Hotkey_Global.Key = 'G';

        }
        private void OnAbout(object sender, EventArgs e)
        {
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }
        FFmpeg rec = new FFmpeg();
        public EventHandler RecordTick;
        public async void OnRecord(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer b = new System.Windows.Forms.Timer();
            b.Interval = 250;

            b.Tick += RecordTick;

            if (rec.IsProcessRunning)
            {
                rec.Stop_Record();
                b.Stop();
                rec.Saved += (o, a) =>
                {
                    recordPath = o.ToString();
                    if (recordPath.Length > 3)
                    {
                        isRecord = true;
                        trayIcon.ShowBalloonTip(300);
                    }
                };
                trayMenu.MenuItems[0].Text = Language.RecordStart;
            }
            else
            {
                b.Start();
                trayMenu.MenuItems[0].Text = Language.RecordStop;
                await Task.Run(() =>
                {
                    FFmpegOptions opt = new FFmpegOptions();
                    rec.Record(opt.GetFFmpegArgs());
                });
            }
        }

        private void OnOptions(object sender, EventArgs e)
        {

            FormOptions = new FormOptions(this);
            FormOptions.Show();
        }

        public void SetHotkey()
        {
            int modifier = 0;
            if (gInkOptions.Hotkey_Global.Control) modifier |= 0x2;
            if (gInkOptions.Hotkey_Global.Alt) modifier |= 0x1;
            if (gInkOptions.Hotkey_Global.Shift) modifier |= 0x4;
            if (gInkOptions.Hotkey_Global.Win) modifier |= 0x8;
            if (modifier != 0)
                RegisterHotKey(IntPtr.Zero, 0, modifier, gInkOptions.Hotkey_Global.Key);
        }

        public void UnsetHotkey()
        {
            int modifier = 0;
            if (gInkOptions.Hotkey_Global.Control) modifier |= 0x2;
            if (gInkOptions.Hotkey_Global.Alt) modifier |= 0x1;
            if (gInkOptions.Hotkey_Global.Shift) modifier |= 0x4;
            if (gInkOptions.Hotkey_Global.Win) modifier |= 0x8;
            if (modifier != 0)
                UnregisterHotKey(IntPtr.Zero, 0);
        }

        public void ChangeLanguage(string code)
        {
            gInkOptions.Language = code;
            Language = new Language(gInkOptions.Language);

            trayMenu.MenuItems.Clear();
            trayMenu.MenuItems.Add(Language.RecordStart, OnRecord);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Language.MenuEntryAbout + "...", OnAbout);
            trayMenu.MenuItems.Add(Language.MenuEntryOptions + "...", OnOptions);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Language.MenuEntryExit, OnExit);
        }

        private void OnExit(object sender, EventArgs e)
        {
            UnsetHotkey();

            trayIcon.Dispose();
            Application.Exit();
        }

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
    }
}

