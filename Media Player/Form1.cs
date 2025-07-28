using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Player
{
    public partial class MediaPlayer : Form
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private string[] paths;
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] files = ofd.SafeFileNames;
                paths = ofd.FileNames; // Assign to class-level variable

                track_list.Items.Clear(); // Clear previous items
                foreach (string file in files)
                {
                    track_list.Items.Add(file);
                }
            }
        }
        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex >= 0 && paths != null && track_list.SelectedIndex < paths.Length)
            {
                Player.URL = paths[track_list.SelectedIndex];
                Player.Ctlcontrols.play();
                lbl_msg.Text = "Playing";
                timer1.Start();
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = trackBar1.Value;
            lbl_vloume.Text = trackBar1.Value.ToString();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.play();
            lbl_msg.Text = "Playing";
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();
            lbl_msg.Text = "Pause ...";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.stop();
            lbl_msg.Text = "Stop ...";
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex<track_list.Items.Count - 1)
            {
                track_list.SelectedIndex = track_list.SelectedIndex + 1;
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex < track_list.Items.Count + 1)
            {
                track_list.SelectedIndex = track_list.SelectedIndex - 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)Player.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)Player.Ctlcontrols.currentPosition;
            }
            lbl_track_start.Text = Player.Ctlcontrols.currentPositionString;
            lbl_track_end.Text = Player.Ctlcontrols.currentItem.durationString.ToString();

        }

        private void lbl_vloume_Click(object sender, EventArgs e)
        {


        }
    }
}
