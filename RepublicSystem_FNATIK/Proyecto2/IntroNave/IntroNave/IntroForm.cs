using System;
using System.Data;
using System.Windows.Forms;
using RepublicSystemClasses;


namespace IntroNave
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    LlenarCombobox();
            //}
            //catch
            //{
            //    MessageBox.Show("No se ha encontrado ningun Planeta");
            //}
        }
        //private void LlenarCombobox()
        //{
        //    button1.Enabled = false;
        //    AccesoBD db = new AccesoBD();
        //    DataTable dt = new DataTable();
        //    string query = "select DescPlanet from Planets";
        //    dt = db.PortarPerConsulta(query).Tables[0];

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        comboBox1.Items.Add(dt.Rows[i][0].ToString());
        //}

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
            Form Nave = new Form();
            if (comboBox1.SelectedItem.ToString() == "InnerRing") Nave = new NaveForm.NaveForm();
            else Nave = new NaveForm.NaveFormOuter();
            Nave.Show();
        }
    }
}
