using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HASHCODE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int hashcode = textBox1.Text.GetHashCode();
            //textBox2.Text = hashcode.ToString();
            string path = @"C:\Users\admin\Desktop\descomprimido1.txt";
            string texto;
            texto = File.ReadAllText(path);
            textBox2.Text = (texto.GetHashCode()).ToString();

        }
    }
}
