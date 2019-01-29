using System;
using RepublicSystemClasses;
using System.Windows.Forms;

namespace PlanetForm
{
    public partial class PlanetForm : Form
    {
        ServidorPlanet sp;
        public PlanetForm()
        {
            InitializeComponent();
        }

        private void Btn_encender_Click(object sender, EventArgs e)
        {
            try
            {
                sp = new ServidorPlanet();
                Btn_encender.Enabled = false;
                sp.StartServer();
                
                Btn_Apagar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error al Encender el Servidor.");
            }
        }

        private void Btn_Apagar_Click(object sender, EventArgs e)
        {
            Btn_Apagar.Enabled = false;
            sp.OffServer();
            Btn_encender.Enabled = true;
        }

        private void PlanetForm_Load(object sender, EventArgs e)
        {
            Btn_Apagar.Enabled = false;
        }
    }
}
