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
        Form frm;
        public PlanetForm()
        {
            toolStrip1.GripMargin = null;
            InitializeComponent();
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            try
            {
                frm = FindForm();
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
            frm = FindForm();
            gf.frm = frm;
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

        private void btnEncender_MouseHover(object sender, EventArgs e)
        {
            //btnEncender.Image = @"C:\Users\admin\Documents\GitHub\sds_pacs\RepublicSystem_FNATIK\Proyecto2\PlanetForm\PlanetForm\Resources\gray_button.png";
        }
    }
}
