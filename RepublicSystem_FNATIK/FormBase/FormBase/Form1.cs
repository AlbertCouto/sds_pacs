using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBase
{
    public partial class Form1 : Form
    {

        int minutes, seconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;

            if (seconds < 0)
            {
                minutes--;
                seconds = 59;

            }

            if (minutes < 0)
            {
                timer1.Stop();
                minutes = 0;
                seconds = 0;
            }


            lbl_minutes.Text = minutes.ToString("00");

            if (seconds == 60)
            {
                lbl_seconds.Text = "00";

            }
            else
            {
                lbl_seconds.Text = seconds.ToString("00");
            }

        }

        private void btn_stopTimer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            timer1.Start();
            
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            reload();
        }

        private void reload()
        {
            minutes = 3;
            seconds = 0;
            lbl_seconds.Text = seconds.ToString("00");
            lbl_minutes.Text = minutes.ToString("00");
        }
    }
}
