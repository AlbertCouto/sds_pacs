using System;
using System.Data;
using System.Windows.Forms;
using RepublicSystemClasses;


namespace IntroNave
{
    public partial class IntroForm : Form
    {
        Form Nave = null;
        public IntroForm()
        {
            InitializeComponent();
        }

        /*
         * FORM PER ESCOLLIR AMB QUIN TIPUS DE PLANETA ENS DIRIGIM
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Nave != null) Nave.Close();
            Nave = new Form();
            if (comboBox1.SelectedItem.ToString() == "InnerRing") Nave = new NaveForm.NaveForm();
            else Nave = new NaveForm.NaveFormOuter();
            Nave.Show();
        }
    }
}
