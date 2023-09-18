using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NedrysBullshit
{
    public partial class Form1 : Form
    {
        private bool isPlaying = false;
        SoundPlayer player = new SoundPlayer(Properties.Resources.ahah);

        public Form1()
        {
            if (!File.Exists(Environment.CurrentDirectory + @"\\NedryNinja_Cut.mp4"))
            {
                File.WriteAllBytes(Environment.CurrentDirectory + @"\\NedryNinja_Cut.mp4", Properties.Resources.NedryNinja_Cut);
            }

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeComponent();

            axWindowsMediaPlayer1.URL = Environment.CurrentDirectory + @"\\NedryNinja_Cut.mp4";

            //here the system will automatially create a thread and will keep on 
            axWindowsMediaPlayer1.settings.setMode("loop", true);

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.fullScreen = true;

            this.FormClosing += Form1_FormClosing;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + @"\\NedryNinja_Cut.mp4"))
            {
                File.Delete(Environment.CurrentDirectory + @"\\NedryNinja_Cut.mp4");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            Properties.Resources.ahah.Dispose();

            player.Stop();
            player.Dispose();

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.PlayLooping();
        }
    }
}
