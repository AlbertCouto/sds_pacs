using System;
using RepublicSystemClasses;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PlanetForm
{
    public partial class PlanetForm : Form
    {
        ClasePlaneta cp;
        GenerarFicheros gf = new GenerarFicheros();
        public PlanetForm()
        {
            InitializeComponent();
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = FindForm();
                cp = new ClasePlaneta();
          
                btnEncender.Enabled = false;
                cp.form = frm;
                cp.StartServer();

                btnApagarServer.Enabled = true;
                MostrarMsgLog("Conexión establecida.", Color.Green);
            }
            catch
            {
                MostrarMsgLog("Error de conexión.", Color.Red);
            }
        }


        private void btnApagarServer_Click(object sender, EventArgs e)
        {

            btnApagarServer.Enabled = false;
            cp.OffServer();
            btnEncender.Enabled = true;
        }


        private void PlanetForm_Load(object sender, EventArgs e)
        {
           
            btnApagarServer.Enabled = false;

            gf.GenerarLosFicheros();


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
