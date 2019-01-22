using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepublicSystemClasses;

namespace NaveForm
{
    public partial class NaveForm : Form
    {
        public NaveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            string directorio;
            if (fbd.ShowDialog() == DialogResult.OK)
                directorio = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Visible = true;
            timer1.StartTimer();
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
           
            console_Log.AppendText("Conectando..." + "\r\n");
            try
            {
                btn_Conectar.Enabled = false;
                ClienteNave cliente = new ClienteNave();
                cliente.puerto = 9250;
                cliente.Start_Client();
                string conectado = "Conexión verificada";
                
                console_Log.AppendText(conectado + "\r\n");
                console_Log.Select(console_Log.Text.IndexOf(conectado), conectado.Length);
                console_Log.SelectionColor = Color.Green;
               
            }
            catch
            {
                string error = "Error al conectar con el planeta";
                console_Log.AppendText(error + "\r\n");
                console_Log.Select(console_Log.Text.IndexOf(error), error.Length);
                console_Log.SelectionColor = Color.Red;
                btn_Conectar.Enabled = true;
            }

        }

        private void btn_Mensaje_Click(object sender, EventArgs e)
        {
       

        }
    }
}
