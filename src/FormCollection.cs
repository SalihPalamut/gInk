﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
//using System.Windows.Input;
using Microsoft.Ink;

namespace gInk
{
    public partial class FormCollection : Form
    {
        public Root Root;
        public InkOverlay IC;
        gInkOptions gInkOptions;
        public Button[] btPen;
        public Bitmap image_exit, image_clear, image_undo, image_snap, image_penwidth;
        public Bitmap image_dock, image_dockback;
        public Bitmap image_pencil, image_highlighter, image_pencil_act, image_highlighter_act;
        public Bitmap image_pointer, image_pointer_act, image_rectange,image_rec,image_rec_s;
        public Bitmap[] image_pen;
        public Bitmap[] image_pen_act;
        public Bitmap image_eraser_act, image_eraser;
        public Bitmap image_pan_act, image_pan;
        public Bitmap image_visible_not, image_visible;
        public System.Windows.Forms.Cursor cursorred, cursorsnap;
        public System.Windows.Forms.Cursor cursortip;

        public int ButtonsEntering = 0;  // -1 = exiting
        public int gpButtonsLeft, gpButtonsTop, gpButtonsWidth, gpButtonsHeight; // the default location, fixed

        public bool gpPenWidth_MouseOn = false;

        public int PrimaryLeft, PrimaryTop;

        // http://www.csharp411.com/hide-form-from-alttab/
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public FormCollection(Root root)
        {
            Root = root;
            InitializeComponent();
            gInkOptions = new gInkOptions();
            root.RecordTick += Record_Tick;
            PrimaryLeft = Screen.PrimaryScreen.Bounds.Left - SystemInformation.VirtualScreen.Left;
            PrimaryTop = Screen.PrimaryScreen.Bounds.Top - SystemInformation.VirtualScreen.Top;
            gpButtons.Height = (int)(Screen.PrimaryScreen.Bounds.Height * gInkOptions.ToolbarSize);
            double size_fact = 0.85,top_fact=0.08;
            int set_height = (int)(gpButtons.Height * size_fact);
            int set_top= (int)(gpButtons.Height * top_fact);
            btClear.Height = set_height;
            btClear.Width = btClear.Height;
            btClear.Top = set_top;

            btDock.Height = set_height;
            btDock.Width = btDock.Height / 2;
            btDock.Top = set_top;

            btEraser.Height = set_height;
            btEraser.Width = btEraser.Height;
            btEraser.Top = set_top;

            btInkVisible.Height = set_height;
            btInkVisible.Width = btInkVisible.Height;
            btInkVisible.Top = set_top;

            btPan.Height = set_height;
            btPan.Width = btPan.Height;
            btPan.Top = set_top;

            btPointer.Height = set_height;
            btPointer.Width = btPointer.Height;
            btPointer.Top = set_top;

            btSnap.Height = set_height;
            btSnap.Width = btSnap.Height;
            btSnap.Top = set_top;

            btStop.Height = set_height;
            btStop.Width = btStop.Height;
            btStop.Top = set_top;

            btUndo.Height = set_height;
            btUndo.Width = btUndo.Height;
            btUndo.Top = set_top;

            btPenWidth.Height = set_height;
            btPenWidth.Width = btPenWidth.Height;
            btPenWidth.Top = set_top;

            btPen = new Button[gInkOptions.MaxPenCount];

            int cumulatedleft = (int)(btDock.Width * 2.5), inc_L = (int)(set_height * 1.1);
            for (int b = 0; b < gInkOptions.MaxPenCount; b++)
            {
                btPen[b] = new Button();
                btPen[b].Width = set_height;
                btPen[b].Height = set_height;
                btPen[b].Top = set_top;
                btPen[b].FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
                btPen[b].FlatAppearance.BorderSize = 3;
                btPen[b].FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(250, 50, 50);
                btPen[b].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btPen[b].ForeColor = System.Drawing.Color.Transparent;
                //btPen[b].Name = "btPen" + b.ToString();
                btPen[b].UseVisualStyleBackColor = false;
                btPen[b].Click += new System.EventHandler(this.btColor_Click);
                btPen[b].BackColor = gInkOptions.PenAttr[b].Color;
                btPen[b].FlatAppearance.MouseDownBackColor = gInkOptions.PenAttr[b].Color;
                btPen[b].FlatAppearance.MouseOverBackColor = gInkOptions.PenAttr[b].Color;
                if (b == 3) btPen[b].Name = "Select";
                if (b == 6) btPen[b].Name = "Record";
                this.toolTip.SetToolTip(this.btPen[b], Root.Local.ButtonNamePen[b]);

                btPen[b].MouseDown += gpButtons_MouseDown;
                btPen[b].MouseMove += gpButtons_MouseMove;
                btPen[b].MouseUp += gpButtons_MouseUp;

                gpButtons.Controls.Add(btPen[b]);

                if (gInkOptions.PenEnabled[b])
                {
                    btPen[b].Visible = true;
                    btPen[b].Left = cumulatedleft;
                    cumulatedleft += inc_L;
                }
                else
                {
                    btPen[b].Visible = false;
                }
            }
            cumulatedleft += inc_L;
            if (gInkOptions.EraserEnabled)
            {
                btEraser.Visible = true;
                btEraser.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btEraser.Visible = false;
            }
            if (gInkOptions.PanEnabled)
            {
                btPan.Visible = true;
                btPan.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btPan.Visible = false;
            }
            if (gInkOptions.PointerEnabled)
            {
                btPointer.Visible = true;
                btPointer.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btPointer.Visible = false;
            }
            cumulatedleft += inc_L;
            if (gInkOptions.PenWidthEnabled)
            {
                btPenWidth.Visible = true;
                btPenWidth.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btPenWidth.Visible = false;
            }
            if (gInkOptions.InkVisibleEnabled)
            {
                btInkVisible.Visible = true;
                btInkVisible.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btInkVisible.Visible = false;
            }
            if (gInkOptions.SnapEnabled)
            {
                btSnap.Visible = true;
                btSnap.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btSnap.Visible = false;
            }
            if (gInkOptions.UndoEnabled)
            {
                btUndo.Visible = true;
                btUndo.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btUndo.Visible = false;
            }
            if (gInkOptions.ClearEnabled)
            {
                btClear.Visible = true;
                btClear.Left = cumulatedleft;
                cumulatedleft += inc_L;
            }
            else
            {
                btClear.Visible = false;
            }
            cumulatedleft += (int)(btDock.Width * 1.5);
            btStop.Left = cumulatedleft;
            gpButtons.Width = btStop.Right + btDock.Width;


            this.Left = SystemInformation.VirtualScreen.Left;
            this.Top = SystemInformation.VirtualScreen.Top;
            //int targetbottom = 0;
            //foreach (Screen screen in Screen.AllScreens)
            //{
            //	if (screen.WorkingArea.Bottom > targetbottom)
            //		targetbottom = screen.WorkingArea.Bottom;
            //}
            //int virwidth = SystemInformation.VirtualScreen.Width;
            //this.Width = virwidth;
            //this.Height = targetbottom - this.Top;
            this.Width = SystemInformation.VirtualScreen.Width;
            this.Height = SystemInformation.VirtualScreen.Height - 2;
            this.DoubleBuffered = true;

            gpButtonsWidth = gpButtons.Width;
            gpButtonsHeight = gpButtons.Height;
            if (true || gInkOptions.AllowDraggingToolbar)
            {
                gpButtonsLeft = Root.gpButtonsLeft;
                gpButtonsTop = Root.gpButtonsTop;
                if
                (
                    !(IsInsideVisibleScreen(gpButtonsLeft, gpButtonsTop) &&
                    IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth, gpButtonsTop) &&
                    IsInsideVisibleScreen(gpButtonsLeft, gpButtonsTop + gpButtonsHeight) &&
                    IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth, gpButtonsTop + gpButtonsHeight))
                    ||
                    (gpButtonsLeft == 0 && gpButtonsTop == 0)
                )
                {
                    gpButtonsLeft = Screen.PrimaryScreen.WorkingArea.Right - gpButtons.Width + PrimaryLeft;
                    gpButtonsTop = Screen.PrimaryScreen.WorkingArea.Bottom - gpButtons.Height - 15 + PrimaryTop;
                }
            }
            else
            {
                gpButtonsLeft = Screen.PrimaryScreen.WorkingArea.Right - gpButtons.Width + PrimaryLeft;
                gpButtonsTop = Screen.PrimaryScreen.WorkingArea.Bottom - gpButtons.Height - 15 + PrimaryTop;
            }

            gpButtons.Left = gpButtonsLeft + gpButtons.Width;
            gpButtons.Top = gpButtonsTop;
            gpPenWidth.Left = gpButtonsLeft + btPenWidth.Left - gpPenWidth.Width / 2 + btPenWidth.Width / 2;
            gpPenWidth.Top = gpButtonsTop - gpPenWidth.Height - 10;

            pboxPenWidthIndicator.Top = 0;
            pboxPenWidthIndicator.Left = (int)Math.Sqrt(Root.GlobalPenWidth * 30);
            gpPenWidth.Controls.Add(pboxPenWidthIndicator);




            IC = new InkOverlay(this.Handle);
            IC.CollectionMode = CollectionMode.InkOnly;
            IC.AutoRedraw = false;
            IC.DynamicRendering = false;
            IC.EraserMode = InkOverlayEraserMode.StrokeErase;
            IC.CursorInRange += IC_CursorInRange;
            IC.MouseDown += IC_MouseDown;
            IC.MouseMove += IC_MouseMove;
            IC.MouseUp += IC_MouseUp;
            IC.CursorDown += IC_CursorDown;
            IC.Stroke += IC_Stroke;
            IC.DefaultDrawingAttributes.Width = 80;
            IC.DefaultDrawingAttributes.Transparency = 30;
            IC.DefaultDrawingAttributes.AntiAliased = true;

            cursorred = new System.Windows.Forms.Cursor(gInk.Properties.Resources.cursorred.Handle);
            //IC.Cursor = cursorred;
            IC.Enabled = true;

            image_exit = new Bitmap(btStop.Width, btStop.Height);
            Graphics g = Graphics.FromImage(image_exit);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.exit, 0, 0, btStop.Width, btStop.Height);
            btStop.Image = image_exit;
            image_clear = new Bitmap(btClear.Width, btClear.Height);
            g = Graphics.FromImage(image_clear);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.garbage, 0, 0, btClear.Width, btClear.Height);
            btClear.Image = image_clear;
            image_undo = new Bitmap(btUndo.Width, btUndo.Height);
            g = Graphics.FromImage(image_undo);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.undo, 0, 0, btUndo.Width, btUndo.Height);
            btUndo.Image = image_undo;
            image_eraser_act = new Bitmap(btEraser.Width, btEraser.Height);
            g = Graphics.FromImage(image_eraser_act);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.eraser_act, 0, 0, btEraser.Width, btEraser.Height);
            image_eraser = new Bitmap(btEraser.Width, btEraser.Height);
            g = Graphics.FromImage(image_eraser);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.eraser, 0, 0, btEraser.Width, btEraser.Height);
            btEraser.Image = image_eraser;

            image_pan_act = new Bitmap(btPan.Width, btPan.Height);
            g = Graphics.FromImage(image_pan_act);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pan_act, 0, 0, btPan.Width, btPan.Height);
            image_pan = new Bitmap(btPan.Width, btPan.Height);
            g = Graphics.FromImage(image_pan);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pan, 0, 0, btPan.Width, btPan.Height);
            btPan.Image = image_pan;

            image_visible_not = new Bitmap(btInkVisible.Width, btInkVisible.Height);
            g = Graphics.FromImage(image_visible_not);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.visible_not, 0, 0, btInkVisible.Width, btInkVisible.Height);
            image_visible = new Bitmap(btInkVisible.Width, btInkVisible.Height);
            g = Graphics.FromImage(image_visible);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.visible, 0, 0, btInkVisible.Width, btInkVisible.Height);
            btInkVisible.Image = image_visible;

            image_snap = new Bitmap(btSnap.Width, btSnap.Height);
            g = Graphics.FromImage(image_snap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.snap, 0, 0, btSnap.Width, btSnap.Height);
            btSnap.Image = image_snap;
            image_penwidth = new Bitmap(btPenWidth.Width, btPenWidth.Height);
            g = Graphics.FromImage(image_penwidth);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.penwidth, 0, 0, btPenWidth.Width, btPenWidth.Height);
            btPenWidth.Image = image_penwidth;
            image_dock = new Bitmap(btDock.Width, btDock.Height);
            g = Graphics.FromImage(image_dock);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.dock, 0, 0, btDock.Width, btDock.Height);
            image_dockback = new Bitmap(btDock.Width, btDock.Height);
            g = Graphics.FromImage(image_dockback);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.dockback, 0, 0, btDock.Width, btDock.Height);
            if (Root.Docked)
                btDock.Image = image_dockback;
            else
                btDock.Image = image_dock;

            image_pencil = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_pencil);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pencil, 0, 0, btPen[2].Width, btPen[2].Height);

            image_rec = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_rec);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.rec_b, 0, 0, btPen[2].Width, btPen[2].Height);
            
            image_rec_s = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_rec_s);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.rec_s, 0, 0, btPen[2].Width, btPen[2].Height);



            image_highlighter = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_highlighter);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.highlighter, 0, 0, btPen[2].Width, btPen[2].Height);
            image_pencil_act = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_pencil_act);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pencil_act, 0, 0, btPen[2].Width, btPen[2].Height);
            image_highlighter_act = new Bitmap(btPen[2].Width, btPen[2].Height);
            g = Graphics.FromImage(image_highlighter_act);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.highlighter_act, 0, 0, btPen[2].Width, btPen[2].Height);

            image_pointer = new Bitmap(btPointer.Width, btPointer.Height);
            g = Graphics.FromImage(image_pointer);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pointer, 0, 0, btPointer.Width, btPointer.Height);
            image_pointer_act = new Bitmap(btPointer.Width, btPointer.Height);
            g = Graphics.FromImage(image_pointer_act);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.pointer_act, 0, 0, btPointer.Width, btPointer.Height);



            image_rectange = new Bitmap(25, 25);
            g = Graphics.FromImage(image_rectange);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.penwidth, 0, 0, 25, 25);
            image_rectange = new Bitmap(btPointer.Width, btPointer.Height);
            g = Graphics.FromImage(image_rectange);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(global::gInk.Properties.Resources.penwidth, 0, 0, btPointer.Width, btPointer.Height);


            image_pen = new Bitmap[gInkOptions.MaxPenCount];
            image_pen_act = new Bitmap[gInkOptions.MaxPenCount];
            for (int b = 0; b < gInkOptions.MaxPenCount; b++)
            {
                if (b == 6)
                {
                    image_pen[b] = image_rec;
                    image_pen_act[b] = image_rec_s;
                    continue;
                }
                if (gInkOptions.PenAttr[b].Transparency >= 100)
                {
                    image_pen[b] = image_highlighter;
                    image_pen_act[b] = image_highlighter_act;
                }
                else
                {
                    image_pen[b] = image_pencil;
                    image_pen_act[b] = image_pencil_act;
                }
            }

            LastTickTime = DateTime.Parse("1987-01-01");
            tiSlide.Enabled = true;

            ToTransparent();
            ToTopMost();

            this.toolTip.SetToolTip(this.btDock, Root.Local.ButtonNameDock);
            this.toolTip.SetToolTip(this.btPenWidth, Root.Local.ButtonNamePenwidth);
            this.toolTip.SetToolTip(this.btEraser, Root.Local.ButtonNameErasor);
            this.toolTip.SetToolTip(this.btPan, Root.Local.ButtonNamePan);
            this.toolTip.SetToolTip(this.btPointer, Root.Local.ButtonNameMousePointer);
            this.toolTip.SetToolTip(this.btInkVisible, Root.Local.ButtonNameInkVisible);
            this.toolTip.SetToolTip(this.btSnap, Root.Local.ButtonNameSnapshot);
            this.toolTip.SetToolTip(this.btUndo, Root.Local.ButtonNameUndo);
            this.toolTip.SetToolTip(this.btClear, Root.Local.ButtonNameClear);
            this.toolTip.SetToolTip(this.btStop, Root.Local.ButtonNameExit);
        }

        private void IC_Stroke(object sender, InkCollectorStrokeEventArgs e)
        {
            SaveUndoStrokes();
        }

        private void SaveUndoStrokes()
        {
            Root.RedoDepth = 0;
            if (Root.UndoDepth < Root.UndoStrokes.GetLength(0) - 1)
                Root.UndoDepth++;

            Root.UndoP++;
            if (Root.UndoP >= Root.UndoStrokes.GetLength(0))
                Root.UndoP = 0;

            if (Root.UndoStrokes[Root.UndoP] == null)
                Root.UndoStrokes[Root.UndoP] = new Ink();
            Root.UndoStrokes[Root.UndoP].DeleteStrokes();
            if (IC.Ink.Strokes.Count > 0)
                Root.UndoStrokes[Root.UndoP].AddStrokesAtRectangle(IC.Ink.Strokes, IC.Ink.Strokes.GetBoundingBox());
        }

        private void IC_CursorDown(object sender, InkCollectorCursorDownEventArgs e)
        {
            if (!Root.InkVisible && Root.Snapping <= 0)
            {
                Root.SetInkVisible(true);
            }

            Root.FormDisplay.ClearCanvus(Root.FormDisplay.gOneStrokeCanvus);
            Root.FormDisplay.DrawStrokes(Root.FormDisplay.gOneStrokeCanvus);
            Root.FormDisplay.DrawButtons(Root.FormDisplay.gOneStrokeCanvus, false);
        }

        private void IC_MouseDown(object sender, CancelMouseEventArgs e)
        {
            if (Root.gpPenWidthVisible)
            {
                Root.gpPenWidthVisible = false;
                Root.UponSubPanelUpdate = true;
            }

            Root.FingerInAction = true;
            if (Root.Snapping == 1)
            {
                Root.SnappingX = e.X;
                Root.SnappingY = e.Y;
                Root.SnappingRect = new Rectangle(e.X, e.Y, 0, 0);
                Root.Snapping = 2;
            }

            if (!Root.InkVisible && Root.Snapping <= 0)
            {
                Root.SetInkVisible(true);
            }

            LasteXY.X = e.X;
            LasteXY.Y = e.Y;
            IC.Renderer.PixelToInkSpace(Root.FormDisplay.gOneStrokeCanvus, ref LasteXY);
        }

        public Point LasteXY;
        private void IC_MouseMove(object sender, CancelMouseEventArgs e)
        {
            if (LasteXY.X == 0 && LasteXY.Y == 0)
            {
                LasteXY.X = e.X;
                LasteXY.Y = e.Y;
                IC.Renderer.PixelToInkSpace(Root.FormDisplay.gOneStrokeCanvus, ref LasteXY);
            }
            Point currentxy = new Point(e.X, e.Y);
            IC.Renderer.PixelToInkSpace(Root.FormDisplay.gOneStrokeCanvus, ref currentxy);

            if (Root.Snapping == 2)
            {
                int left = Math.Min(Root.SnappingX, e.X);
                int top = Math.Min(Root.SnappingY, e.Y);
                int width = Math.Abs(Root.SnappingX - e.X);
                int height = Math.Abs(Root.SnappingY - e.Y);
                Root.SnappingRect = new Rectangle(left, top, width, height);

                if (LasteXY != currentxy)
                    Root.MouseMovedUnderSnapshotDragging = true;
            }
            else if (Root.PanMode && Root.FingerInAction)
            {
                Root.Pan(currentxy.X - LasteXY.X, currentxy.Y - LasteXY.Y);
            }

            LasteXY = currentxy;
        }

        private void IC_MouseUp(object sender, CancelMouseEventArgs e)
        {
            Root.FingerInAction = false;
            if (Root.Snapping == 2)
            {
                int left = Math.Min(Root.SnappingX, e.X);
                int top = Math.Min(Root.SnappingY, e.Y);
                int width = Math.Abs(Root.SnappingX - e.X);
                int height = Math.Abs(Root.SnappingY - e.Y);
                if (width < 5 || height < 5)
                {
                    left = 0;
                    top = 0;
                    width = this.Width;
                    height = this.Height;
                }
                Root.SnappingRect = new Rectangle(left + this.Left, top + this.Top, width, height);
                Root.UponTakingSnap = true;
                ExitSnapping();
            }
            else if (Root.PanMode)
            {
                SaveUndoStrokes();
            }
            else
            {
                Root.UponAllDrawingUpdate = true;
            }
        }

        private void IC_CursorInRange(object sender, InkCollectorCursorInRangeEventArgs e)
        {
            if (e.Cursor.Inverted && Root.CurrentPen != -1)
            {
                EnterEraserMode(true);
                /*
				// temperary eraser icon light
				if (btEraser.Image == image_eraser)
				{
					btEraser.Image = image_eraser_act;
					Root.FormDisplay.DrawButtons(true);
					Root.FormDisplay.UpdateFormDisplay();
				}
				*/
            }
            else if (!e.Cursor.Inverted && Root.CurrentPen != -1)
            {
                EnterEraserMode(false);
                /*
				if (btEraser.Image == image_eraser_act)
				{
					btEraser.Image = image_eraser;
					Root.FormDisplay.DrawButtons(true);
					Root.FormDisplay.UpdateFormDisplay();
				}
				*/
            }
        }

        public void ToTransparent()
        {
            UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
            SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
        }

        public void ToTopMost()
        {
            SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0020);
        }

        public void ToThrough()
        {
            UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
            //SetWindowPos(this.Handle, (IntPtr)0, 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0004 | 0x0010 | 0x0020);
            //SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
            SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000 | 0x00000020);
            //SetWindowPos(this.Handle, (IntPtr)(1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);
        }

        public void ToUnThrough()
        {
            UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, (uint)(dwExStyle & ~0x00080000 & ~0x0020));
            SetWindowLong(this.Handle, -20, (uint)(dwExStyle & ~0x0020));
            //SetWindowPos(this.Handle, (IntPtr)(-2), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);

            //dwExStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
            //SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
            //SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0020);
        }

        public void EnterEraserMode(bool enter)
        {
            int exceptiontick = 0;
            bool exc;
            do
            {
                exceptiontick++;
                exc = false;
                try
                {
                    if (enter)
                    {
                        IC.EditingMode = InkOverlayEditingMode.Delete;
                        Root.EraserMode = true;
                    }
                    else
                    {
                        IC.EditingMode = InkOverlayEditingMode.Ink;
                        Root.EraserMode = false;
                    }
                }
                catch
                {
                    Thread.Sleep(50);
                    exc = true;
                }
            }
            while (exc && exceptiontick < 3);
        }

        public void SelectPen(int pen)
        {
            // -3=pan, -2=pointer, -1=erasor, 0+=pens
            if (pen == -3)
            {
                for (int b = 0; b < gInkOptions.MaxPenCount; b++)
                    btPen[b].Image = image_pen[b];
                btEraser.Image = image_eraser;
                btPointer.Image = image_pointer;
                btPan.Image = image_pan_act;
                EnterEraserMode(false);
                Root.UnPointer();
                Root.PanMode = true;

                IC.SetWindowInputRectangle(new Rectangle(0, 0, 1, 1));
            }
            else if (pen == -2)
            {
                for (int b = 0; b < gInkOptions.MaxPenCount; b++)
                    btPen[b].Image = image_pen[b];
                btEraser.Image = image_eraser;
                btPointer.Image = image_pointer_act;
                btPan.Image = image_pan;
                EnterEraserMode(false);
                Root.Pointer();
                Root.PanMode = false;
            }
            else if (pen == -1)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;

                for (int b = 0; b < gInkOptions.MaxPenCount; b++)
                    btPen[b].Image = image_pen[b];
                btEraser.Image = image_eraser_act;
                btPointer.Image = image_pointer;
                btPan.Image = image_pan;
                EnterEraserMode(true);
                Root.UnPointer();
                Root.PanMode = false;

                if (gInkOptions.CanvasCursor == 0)
                {
                    cursorred = new System.Windows.Forms.Cursor(gInk.Properties.Resources.cursorred.Handle);
                    IC.Cursor = cursorred;
                }
                else if (gInkOptions.CanvasCursor == 1)
                    SetPenTipCursor();

                IC.SetWindowInputRectangle(new Rectangle(0, 0, this.Width, this.Height));
            }
            else if (pen >= 0)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;

                IC.DefaultDrawingAttributes = gInkOptions.PenAttr[pen].Clone();
                /*if (Root.PenWidthEnabled)
                {
                    IC.DefaultDrawingAttributes.Width = Root.GlobalPenWidth;
                }*/
                for (int b = 0; b < gInkOptions.MaxPenCount; b++)
                    btPen[b].Image = image_pen[b];
                btPen[pen].Image = image_pen_act[pen];
                btEraser.Image = image_eraser;
                btPointer.Image = image_pointer;
                btPan.Image = image_pan;
                EnterEraserMode(false);
                Root.UnPointer();
                Root.PanMode = false;

                if (gInkOptions.CanvasCursor == 0)
                {
                    cursorred = new System.Windows.Forms.Cursor(gInk.Properties.Resources.cursorred.Handle);
                    IC.Cursor = cursorred;
                }
                else if (gInkOptions.CanvasCursor == 1)
                    SetPenTipCursor();

                IC.SetWindowInputRectangle(new Rectangle(0, 0, this.Width, this.Height));
            }
            Root.CurrentPen = pen;
            if (Root.gpPenWidthVisible)
            {
                Root.gpPenWidthVisible = false;
                Root.UponSubPanelUpdate = true;
            }
            else
                Root.UponButtonsUpdate |= 0x2;

            if (pen != -2)
                Root.LastPen = pen;
        }

        public void RetreatAndExit()
        {
            ToThrough();
            Root.ClearInk();
            SaveUndoStrokes();
            gInkOptions.Save();
            Root.gpPenWidthVisible = false;

            LastTickTime = DateTime.Now;
            ButtonsEntering = -9;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void btDock_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            LastTickTime = DateTime.Now;
            if (!Root.Docked)
            {
                Root.Dock();
            }
            else
            {
                Root.UnDock();
            }
        }

        public void btPointer_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            SelectPen(-2);
        }


        private void btPenWidth_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            if (Root.PointerMode)
                return;

            Root.gpPenWidthVisible = !Root.gpPenWidthVisible;
            if (Root.gpPenWidthVisible)
                Root.UponButtonsUpdate |= 0x2;
            else
                Root.UponSubPanelUpdate = true;
        }

        public void btSnap_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            if (Root.Snapping > 0)
                return;

            cursorsnap = new System.Windows.Forms.Cursor(gInk.Properties.Resources.cursorsnap.Handle);
            this.Cursor = cursorsnap;

            Root.gpPenWidthVisible = false;

            IC.SetWindowInputRectangle(new Rectangle(0, 0, 1, 1));
            Root.SnappingX = -1;
            Root.SnappingY = -1;
            Root.SnappingRect = new Rectangle(0, 0, 0, 0);
            Root.Snapping = 1;
            ButtonsEntering = -2;
            Root.UnPointer();
        }

        public void ExitSnapping()
        {
            IC.SetWindowInputRectangle(new Rectangle(0, 0, this.Width, this.Height));
            Root.SnappingX = -1;
            Root.SnappingY = -1;
            Root.Snapping = -60;
            ButtonsEntering = 1;
            Root.SelectPen(Root.CurrentPen);

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public void btStop_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            RetreatAndExit();
        }

        DateTime LastTickTime;
        bool[] LastPenStatus = new bool[10];
        bool LastEraserStatus = false;
        bool LastVisibleStatus = false;
        bool LastPointerStatus = false;
        bool LastPanStatus = false;
        bool LastUndoStatus = false;
        bool LastRedoStatus = false;
        bool LastSnapStatus = false;
        bool LastClearStatus = false;

        private void gpPenWidth_MouseDown(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseOn = true;
        }

        private void gpPenWidth_MouseMove(object sender, MouseEventArgs e)
        {
            if (gpPenWidth_MouseOn)
            {
                if (e.X < 10 || gpPenWidth.Width - e.X < 10)
                    return;

                Root.GlobalPenWidth = e.X * e.X / 30;
                pboxPenWidthIndicator.Left = e.X - pboxPenWidthIndicator.Width / 2;
                IC.DefaultDrawingAttributes.Width = Root.GlobalPenWidth;
                Root.UponButtonsUpdate |= 0x2;
                gInkOptions.PenAttr[Root.LastPen].Width = Root.GlobalPenWidth;
            }
        }

        private void gpPenWidth_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X >= 10 && gpPenWidth.Width - e.X >= 10)
            {
                Root.GlobalPenWidth = e.X * e.X / 30;
                pboxPenWidthIndicator.Left = e.X - pboxPenWidthIndicator.Width / 2;
                IC.DefaultDrawingAttributes.Width = Root.GlobalPenWidth;
                gInkOptions.PenAttr[Root.LastPen].Width = Root.GlobalPenWidth;
            }

            if (gInkOptions.CanvasCursor == 1)
                SetPenTipCursor();

            Root.gpPenWidthVisible = false;
            Root.UponSubPanelUpdate = true;
            gpPenWidth_MouseOn = false;
        }

        private void pboxPenWidthIndicator_MouseDown(object sender, MouseEventArgs e)
        {
            gpPenWidth_MouseOn = true;
        }

        private void pboxPenWidthIndicator_MouseMove(object sender, MouseEventArgs e)
        {
            if (gpPenWidth_MouseOn)
            {
                int x = e.X + pboxPenWidthIndicator.Left;
                if (x < 10 || gpPenWidth.Width - x < 10)
                    return;

                Root.GlobalPenWidth = x * x / 30;
                pboxPenWidthIndicator.Left = x - pboxPenWidthIndicator.Width / 2;
                IC.DefaultDrawingAttributes.Width = Root.GlobalPenWidth;
                Root.UponButtonsUpdate |= 0x2;
            }
        }

        private void pboxPenWidthIndicator_MouseUp(object sender, MouseEventArgs e)
        {
            if (gInkOptions.CanvasCursor == 1)
                SetPenTipCursor();

            Root.gpPenWidthVisible = false;
            Root.UponSubPanelUpdate = true;
            gpPenWidth_MouseOn = false;
        }

        private void SetPenTipCursor()
        {
            Bitmap bitmaptip = (Bitmap)(gInk.Properties.Resources._null).Clone();
            Graphics g = Graphics.FromImage(bitmaptip);
            DrawingAttributes dda = IC.DefaultDrawingAttributes;
            Brush cbrush;
            Point widt;
            if (!Root.EraserMode)
            {
                cbrush = new SolidBrush(IC.DefaultDrawingAttributes.Color);
                //Brush cbrush = new SolidBrush(Color.FromArgb(255 - dda.Transparency, dda.Color.R, dda.Color.G, dda.Color.B));
                widt = new Point((int)IC.DefaultDrawingAttributes.Width, 0);
            }
            else
            {
                cbrush = new SolidBrush(Color.Black);
                widt = new Point(60, 0);
            }
            IC.Renderer.InkSpaceToPixel(IC.Handle, ref widt);

            IntPtr screenDc = GetDC(IntPtr.Zero);
            const int VERTRES = 10;
            const int DESKTOPVERTRES = 117;
            int LogicalScreenHeight = GetDeviceCaps(screenDc, VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(screenDc, DESKTOPVERTRES);
            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            ReleaseDC(IntPtr.Zero, screenDc);

            int dia = Math.Max((int)(widt.X * ScreenScalingFactor), 2);
            g.FillEllipse(cbrush, 64 - dia / 2, 64 - dia / 2, dia, dia);
            if (dia <= 5)
            {
                Pen cpen = new Pen(Color.FromArgb(50, 128, 128, 128), 2);
                dia += 6;
                g.DrawEllipse(cpen, 64 - dia / 2, 64 - dia / 2, dia, dia);
            }
            IC.Cursor = new System.Windows.Forms.Cursor(bitmaptip.GetHicon());

        }

        short LastESCStatus = 0;
        private void tiSlide_Tick(object sender, EventArgs e)
        {
            // ignore the first tick
            if (LastTickTime.Year == 1987)
            {
                LastTickTime = DateTime.Now;
                return;
            }

            int aimedleft = gpButtonsLeft;
            if (ButtonsEntering == -9)
            {
                aimedleft = gpButtonsLeft + gpButtonsWidth;
            }
            else if (ButtonsEntering < 0)
            {
                if (Root.Snapping > 0)
                    aimedleft = gpButtonsLeft + gpButtonsWidth + 0;
                else if (Root.Docked)
                    aimedleft = gpButtonsLeft + gpButtonsWidth - btDock.Right;
            }
            else if (ButtonsEntering > 0)
            {
                if (Root.Docked)
                    aimedleft = gpButtonsLeft + gpButtonsWidth - btDock.Right;
                else
                    aimedleft = gpButtonsLeft;
            }
            else if (ButtonsEntering == 0)
            {
                aimedleft = gpButtons.Left; // stay at current location
            }

            if (gpButtons.Left > aimedleft)
            {
                float dleft = gpButtons.Left - aimedleft;
                dleft /= 70;
                if (dleft > 8) dleft = 8;
                dleft *= (float)(DateTime.Now - LastTickTime).TotalMilliseconds;
                if (dleft > 120) dleft = 230;
                if (dleft < 1) dleft = 1;
                gpButtons.Left -= (int)dleft;
                LastTickTime = DateTime.Now;
                if (gpButtons.Left < aimedleft)
                {
                    gpButtons.Left = aimedleft;
                }
                gpButtons.Width = Math.Max(gpButtonsWidth - (gpButtons.Left - gpButtonsLeft), btDock.Width);
                Root.UponButtonsUpdate |= 0x1;
            }
            else if (gpButtons.Left < aimedleft)
            {
                float dleft = aimedleft - gpButtons.Left;
                dleft /= 70;
                if (dleft > 8) dleft = 8;
                // fast exiting when not docked
                if (ButtonsEntering == -9 && !Root.Docked)
                    dleft = 8;
                dleft *= (float)(DateTime.Now - LastTickTime).TotalMilliseconds;
                if (dleft > 120) dleft = 120;
                if (dleft < 1) dleft = 1;
                // fast exiting when docked
                if (ButtonsEntering == -9 && dleft == 1)
                    dleft = 2;
                gpButtons.Left += (int)dleft;
                LastTickTime = DateTime.Now;
                if (gpButtons.Left > aimedleft)
                {
                    gpButtons.Left = aimedleft;
                }
                gpButtons.Width = Math.Max(gpButtonsWidth - (gpButtons.Left - gpButtonsLeft), btDock.Width);
                Root.UponButtonsUpdate |= 0x1;
                Root.UponButtonsUpdate |= 0x4;
            }

            if (ButtonsEntering == -9 && gpButtons.Left == aimedleft)
            {
                tiSlide.Enabled = false;
                Root.StopInk();
                return;
            }
            else if (ButtonsEntering < 0)
            {
                Root.UponAllDrawingUpdate = true;
                Root.UponButtonsUpdate = 0;
            }
            if (gpButtons.Left == aimedleft)
            {
                ButtonsEntering = 0;
            }



            if (!Root.PointerMode && !this.TopMost)
                ToTopMost();

            // gpPenWidth status

            if (Root.gpPenWidthVisible != gpPenWidth.Visible)
                gpPenWidth.Visible = Root.gpPenWidthVisible;

            // hotkeys

            const int VK_LCONTROL = 0xA2;
            const int VK_RCONTROL = 0xA3;
            const int VK_LSHIFT = 0xA0;
            const int VK_RSHIFT = 0xA1;
            const int VK_LMENU = 0xA4;
            const int VK_RMENU = 0xA5;
            const int VK_LWIN = 0x5B;
            const int VK_RWIN = 0x5C;
            bool pressed;

            if (!Root.PointerMode)
            {
                // ESC key : Exit
                short retVal;
                retVal = GetKeyState(27);
                if ((retVal & 0x8000) == 0x8000)
                {
                    if ((LastESCStatus & 0x8000) == 0x0000)
                    {
                        if (Root.Snapping > 0)
                        {
                            ExitSnapping();
                        }
                        else if (Root.gpPenWidthVisible)
                        {
                            Root.gpPenWidthVisible = false;
                            Root.UponSubPanelUpdate = true;
                        }
                        else if (Root.Snapping == 0)
                            RetreatAndExit();
                    }
                }
                LastESCStatus = retVal;
            }


            if (!Root.FingerInAction && (!Root.PointerMode || gInkOptions.AllowHotkeyInPointerMode) && Root.Snapping <= 0)
            {
                bool control = ((short)(GetKeyState(VK_LCONTROL) | GetKeyState(VK_RCONTROL)) & 0x8000) == 0x8000;
                bool alt = ((short)(GetKeyState(VK_LMENU) | GetKeyState(VK_RMENU)) & 0x8000) == 0x8000;
                bool shift = ((short)(GetKeyState(VK_LSHIFT) | GetKeyState(VK_RSHIFT)) & 0x8000) == 0x8000;
                bool win = ((short)(GetKeyState(VK_LWIN) | GetKeyState(VK_RWIN)) & 0x8000) == 0x8000;

                for (int p = 0; p < gInkOptions.MaxPenCount; p++)
                {
                    pressed = (GetKeyState(gInkOptions.Hotkey_Pens[p].Key) & 0x8000) == 0x8000;
                    if (pressed && !LastPenStatus[p] && gInkOptions.Hotkey_Pens[p].ModifierMatch(control, alt, shift, win))
                    {
                        if (btPen[p].Name == "Select" || btPen[p].Name == "Record")
                            btColor_Click(btPen[p], null);
                        else
                        SelectPen(p);
                    }
                    LastPenStatus[p] = pressed;
                }

                pressed = (GetKeyState(gInkOptions.Hotkey_Eraser.Key) & 0x8000) == 0x8000;
                if (pressed && !LastEraserStatus && gInkOptions.Hotkey_Eraser.ModifierMatch(control, alt, shift, win))
                {
                    SelectPen(-1);
                }
                LastEraserStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_InkVisible.Key) & 0x8000) == 0x8000;
                if (pressed && !LastVisibleStatus && gInkOptions.Hotkey_InkVisible.ModifierMatch(control, alt, shift, win))
                {
                    btInkVisible_Click(null, null);
                }
                LastVisibleStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Undo.Key) & 0x8000) == 0x8000;
                if (pressed && !LastUndoStatus && gInkOptions.Hotkey_Undo.ModifierMatch(control, alt, shift, win))
                {
                    if (!Root.InkVisible)
                        Root.SetInkVisible(true);

                    Root.UndoInk();
                }
                LastUndoStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Redo.Key) & 0x8000) == 0x8000;
                if (pressed && !LastRedoStatus && gInkOptions.Hotkey_Redo.ModifierMatch(control, alt, shift, win))
                {
                    Root.RedoInk();
                }
                LastRedoStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Pointer.Key) & 0x8000) == 0x8000;
                if (pressed && !LastPointerStatus && gInkOptions.Hotkey_Pointer.ModifierMatch(control, alt, shift, win))
                {
                    SelectPen(-2);
                }
                LastPointerStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Pan.Key) & 0x8000) == 0x8000;
                if (pressed && !LastPanStatus && gInkOptions.Hotkey_Pan.ModifierMatch(control, alt, shift, win))
                {
                    SelectPen(-3);
                }
                LastPanStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Clear.Key) & 0x8000) == 0x8000;
                if (pressed && !LastClearStatus && gInkOptions.Hotkey_Clear.ModifierMatch(control, alt, shift, win))
                {
                    btClear_Click(null, null);
                }
                LastClearStatus = pressed;

                pressed = (GetKeyState(gInkOptions.Hotkey_Snap.Key) & 0x8000) == 0x8000;
                if (pressed && !LastSnapStatus && gInkOptions.Hotkey_Snap.ModifierMatch(control, alt, shift, win))
                {
                    btSnap_Click(null, null);
                }
                LastSnapStatus = pressed;
            }

            if (Root.Snapping < 0)
                Root.Snapping++;
        }

        private bool IsInsideVisibleScreen(int x, int y)
        {
            x -= PrimaryLeft;
            y -= PrimaryTop;
            //foreach (Screen s in Screen.AllScreens)
            //	Console.WriteLine(s.Bounds);
            //Console.WriteLine(x.ToString() + ", " + y.ToString());

            foreach (Screen s in Screen.AllScreens)
                if (s.Bounds.Contains(x, y))
                    return true;
            return false;
        }

        int IsMovingToolbar = 0;
        Point HitMovingToolbareXY = new Point();

        private void gpPenWidth_Paint(object sender, PaintEventArgs e)
        {

        }

        bool ToolbarMoved = false;
        private void gpButtons_MouseDown(object sender, MouseEventArgs e)
        {
            if (!gInkOptions.AllowDraggingToolbar)
                return;
            if (ButtonsEntering != 0)
                return;

            ToolbarMoved = false;
            IsMovingToolbar = 1;
            HitMovingToolbareXY.X = e.X;
            HitMovingToolbareXY.Y = e.Y;
        }

        private void gpButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gpButtons_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMovingToolbar == 1)
            {
                if (Math.Abs(e.X - HitMovingToolbareXY.X) > 20 || Math.Abs(e.Y - HitMovingToolbareXY.Y) > 20)
                    IsMovingToolbar = 2;
            }
            if (IsMovingToolbar == 2)
            {
                if (e.X != HitMovingToolbareXY.X || e.Y != HitMovingToolbareXY.Y)
                {
                    /*
					gpButtonsLeft += e.X - HitMovingToolbareXY.X;
					gpButtonsTop += e.Y - HitMovingToolbareXY.Y;
					
					if (gpButtonsLeft + gpButtonsWidth > SystemInformation.VirtualScreen.Right)
						gpButtonsLeft = SystemInformation.VirtualScreen.Right - gpButtonsWidth;
					if (gpButtonsLeft < SystemInformation.VirtualScreen.Left)
						gpButtonsLeft = SystemInformation.VirtualScreen.Left;
					if (gpButtonsTop + gpButtonsHeight > SystemInformation.VirtualScreen.Bottom)
						gpButtonsTop = SystemInformation.VirtualScreen.Bottom - gpButtonsHeight;
					if (gpButtonsTop < SystemInformation.VirtualScreen.Top)
						gpButtonsTop = SystemInformation.VirtualScreen.Top;
					*/
                    int newleft = gpButtonsLeft + e.X - HitMovingToolbareXY.X;
                    int newtop = gpButtonsTop + e.Y - HitMovingToolbareXY.Y;

                    bool continuemoving;
                    bool toolbarmovedthisframe = false;
                    int dleft = 0, dtop = 0;
                    if
                    (
                        IsInsideVisibleScreen(newleft, newtop) &&
                        IsInsideVisibleScreen(newleft + gpButtonsWidth, newtop) &&
                        IsInsideVisibleScreen(newleft, newtop + gpButtonsHeight) &&
                        IsInsideVisibleScreen(newleft + gpButtonsWidth, newtop + gpButtonsHeight)
                    )
                    {
                        continuemoving = true;
                        ToolbarMoved = true;
                        toolbarmovedthisframe = true;
                        dleft = newleft - gpButtonsLeft;
                        dtop = newtop - gpButtonsTop;
                    }
                    else
                    {
                        do
                        {
                            if (dleft != newleft - gpButtonsLeft)
                                dleft += Math.Sign(newleft - gpButtonsLeft);
                            else
                                break;
                            if
                            (
                                IsInsideVisibleScreen(gpButtonsLeft + dleft, gpButtonsTop + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth + dleft, gpButtonsTop + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + dleft, gpButtonsTop + gpButtonsHeight + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth + dleft, gpButtonsTop + gpButtonsHeight + dtop)
                            )
                            {
                                continuemoving = true;
                                ToolbarMoved = true;
                                toolbarmovedthisframe = true;
                            }
                            else
                            {
                                continuemoving = false;
                                dleft -= Math.Sign(newleft - gpButtonsLeft);
                            }
                        }
                        while (continuemoving);
                        do
                        {
                            if (dtop != newtop - gpButtonsTop)
                                dtop += Math.Sign(newtop - gpButtonsTop);
                            else
                                break;
                            if
                            (
                                IsInsideVisibleScreen(gpButtonsLeft + dleft, gpButtonsTop + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth + dleft, gpButtonsTop + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + dleft, gpButtonsTop + gpButtonsHeight + dtop) &&
                                IsInsideVisibleScreen(gpButtonsLeft + gpButtonsWidth + dleft, gpButtonsTop + gpButtonsHeight + dtop)
                            )
                            {
                                continuemoving = true;
                                ToolbarMoved = true;
                                toolbarmovedthisframe = true;
                            }
                            else
                            {
                                continuemoving = false;
                                dtop -= Math.Sign(newtop - gpButtonsTop);
                            }
                        }
                        while (continuemoving);
                    }

                    if (toolbarmovedthisframe)
                    {
                        gpButtonsLeft += dleft;
                        gpButtonsTop += dtop;
                        Root.gpButtonsLeft = gpButtonsLeft;
                        Root.gpButtonsTop = gpButtonsTop;
                        if (Root.Docked)
                            gpButtons.Left = gpButtonsLeft + gpButtonsWidth - btDock.Right;
                        else
                            gpButtons.Left = gpButtonsLeft;
                        gpPenWidth.Left = gpButtonsLeft + btPenWidth.Left - gpPenWidth.Width / 2 + btPenWidth.Width / 2;
                        gpPenWidth.Top = gpButtonsTop - gpPenWidth.Height - 10;
                        gpButtons.Top = gpButtonsTop;
                        Root.UponAllDrawingUpdate = true;
                    }
                }
            }
        }

        private void gpButtons_MouseUp(object sender, MouseEventArgs e)
        {
            IsMovingToolbar = 0;
        }

        private void btInkVisible_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            Root.SetInkVisible(!Root.InkVisible);
        }

        public void btClear_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            Root.ClearInk();
            SaveUndoStrokes();
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            if (!Root.InkVisible)
                Root.SetInkVisible(true);

            Root.UndoInk();
        }
        bool a = true;
        private void Record_Tick(object o, EventArgs e)
        {
           
                if (btPen[6].Name == "Record")
            {
                btPen[6].BackgroundImage = a ? image_rec : image_rec_s;
                a = !a;
                 
            }
        }
        public void btColor_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            for (int b = 0; b < gInkOptions.MaxPenCount; b++)
                if ((Button)sender == btPen[b])
                {
                    if (btPen[b].Name == "Record")
                    {
                        Root.OnRecord(null, null);
                        return;
                    }
                    if (btPen[b].Name == "Select")
                    {
                        //!Select Cursor
                        SelectPen(-2);
                        //!Create Color picker
                        ThemeColorPickerWindow PenColor = new ThemeColorPickerWindow(System.Windows.Forms.FormBorderStyle.FixedToolWindow, ThemeColorPickerWindow.Action.CloseWindow, ThemeColorPickerWindow.Action.CloseWindow);
                        int top = gpButtons.Top;
                        if (top > PenColor.Height)
                            top -= PenColor.Height;
                        PenColor.Location = new Point(gpButtons.Left, top);
                        PenColor.ActionAfterColorSelected = ThemeColorPickerWindow.Action.HideWindow;
                        PenColor.Color = gInkOptions.PenAttr[3].Color;
                        PenColor.ShowDialog();
                        //!Change Color
                        ((Button)sender).BackColor = PenColor.Color;
                        gInkOptions.PenAttr[3].Color = PenColor.Color;
                        PenColor.Close();
                    }
                    

                            SelectPen(b);
                }
        }

        public void btEraser_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            SelectPen(-1);
        }


        private void btPan_Click(object sender, EventArgs e)
        {
            if (ToolbarMoved)
            {
                ToolbarMoved = false;
                return;
            }

            SelectPen(-3);
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);
        [DllImport("user32.dll")]
        public extern static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
    }
}
