using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente_Nave.Class1 si = new Cliente_Nave.Class1();
            si.puerto = 5678;
            si.Start_Client();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente_Nave.Class1 si = new Cliente_Nave.Class1();
            si.puerto = 9250;
            si.Start_Client();
        }
    }
}
