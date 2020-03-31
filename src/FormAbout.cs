using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gInk
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
		}

		private void FormAbout_Load(object sender, EventArgs e)
		{
			this.Icon = gInk.Properties.Resources.g_rec1;
			string version = Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
			StringBuilder about = new StringBuilder( "gInkR v" + version + "\r\n");
			about.AppendLine("© 2020 ® - Salih Palamut");
			about.AppendLine("https://github.com/SalihPalamut/gInk");
			about.AppendLine("Special Thanks");
			about.AppendLine("https://www.ffmpeg.org/");
			about.AppendLine("Forked from:");
			about.AppendLine("(c) 2016-2020 Weizhi Nai");
			about.AppendLine("Licensed under MIT");
			about.AppendLine("https://github.com/geovens/gInk");
			about.AppendLine("Credits:");
			about.AppendLine("Some button icons are designed by Freepik.com\r\niconsflow.com");
		    textBox1.Text = about.ToString();
			pictureBox1.Select();
		}
			
		private void textBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		private void textBox1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
