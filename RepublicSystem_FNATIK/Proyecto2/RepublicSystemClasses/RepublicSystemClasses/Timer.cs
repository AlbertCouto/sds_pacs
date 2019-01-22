using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepublicSystemClasses
{
    public partial class Timer : UserControl
    {
        public Timer()
        {
            InitializeComponent();
        }

        int minutes, seconds;

        private void Timer_Load(object sender, EventArgs e)
        {
            minutes = 3;
            seconds = 0;
            lbl_seconds.Text = seconds.ToString("00");
            lbl_minutes.Text = minutes.ToString("00");
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
        public void StartTimer()
        {
            timer1.Start();
        }
        public void StopTimer()
        {
            timer1.Stop();
        }
    }
}
