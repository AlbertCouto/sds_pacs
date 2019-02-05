using System;
using RepublicSystemClasses;
using System.Windows.Forms;
using System.Drawing;

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
                MostrarMsgLog("Conexión establecida", Color.Green);
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

        private void MostrarMsgLog(string msg, Color color)
        {
            //if (console_Log.InvokeRequired)
            //{
            //    console_Log.Invoke((MethodInvoker)delegate
            //    {
                    console_Log.AppendText(msg + "\r\n");
                    console_Log.Select(console_Log.Text.Length - msg.Length - 1, msg.Length);
                    console_Log.SelectionColor = color;
            //    });
            //}
        }
    }
}
