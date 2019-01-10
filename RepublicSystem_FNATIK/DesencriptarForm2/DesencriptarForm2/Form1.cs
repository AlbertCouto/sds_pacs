using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DescCompr;
using System.Windows.Forms;


namespace DesencriptarForm2
{
    public partial class Form1 : Form
    {
        ComprDescompr comprDescompr = new ComprDescompr();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zipPath = @"C:\Users\admin\Desktop\Desktop.zip";
            string extractPath = @"C:\Users\admin\Desktop";
            comprDescompr.Descomprimir(zipPath, extractPath);
            MessageBox.Show("DESCOMPRIMIT");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
