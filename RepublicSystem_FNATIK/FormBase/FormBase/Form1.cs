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

        int quick = 7200;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            quick--;
            timeLabel.Text = quick / 60 / 60 + " : " + ((quick % 60) >= 10 ? (quick % 60).ToString() : "0" + (quick % 60));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            timer1 = new Timer();
            timer1.Interval = 1; // para intervalos de 1 segundo
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }
    }
}
