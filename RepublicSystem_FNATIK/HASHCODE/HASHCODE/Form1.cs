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
using RepublicSystemClasses;

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
            bool boolean;
            string original, returned;
            original = @"C:\Users\admin\Desktop\descomprimido1.txt";
            returned = @"C:\Users\admin\Desktop\descomprimido2.txt";
            CompararArchivos ca = new CompararArchivos();
            boolean = ca.Comparar(original, returned);

            textBox2.Text = boolean.ToString();

        }
    }
}
