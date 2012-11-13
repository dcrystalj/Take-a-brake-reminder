using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication2
{
    public partial class Timer : Form
    {
        public Timer()
        {
            InitializeComponent();
            textBox3.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Začni"))
            {
                textBox3.Text = "0";
                timer1.Start();
                button1.Text = "Pavza";
            }
            else if (button1.Text.Equals("Pavza"))
            {
                textBox3.Text = "0";
                timer1.Start();
                button1.Text = "Začni";
            }
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text =  Convert.ToString(Convert.ToInt32(textBox3.Text)+1);
            if (button1.Text.Equals("Pavza"))
            {
                if (textBox3.Text.Equals(textBox1.Text))
                {
                    textBox3.Text = "0";
                    timer1.Start();
                    button1.Text = "Začni";
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(15, "Pavzica", "Čas za pavzo", ToolTipIcon.Warning);
                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    simpleSound.Play();
                }
            }
            else
            {
                if (textBox3.Text.Equals(textBox2.Text))
                {
                    timer1.Stop();
                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    notifyIcon1.ShowBalloonTip(25, "Pavzica", "Get on work man!", ToolTipIcon.Info);
                    simpleSound.Play();
                }
            }
        }
    }
}
