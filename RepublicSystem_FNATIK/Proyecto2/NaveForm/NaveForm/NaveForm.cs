using System;
using System.Drawing;
using System.Windows.Forms;
using RepublicSystemClasses;

namespace NaveForm
{
    public partial class NaveForm : Form
    {
        bool conectado_planeta = false;
        public NaveForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Visible = true;
            timer1.StartTimer();
        }

        //Conectar Con Planeta (PING)
        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            console_Log.AppendText("Conectando..." + "\r\n");
            try
            {
                ClienteNave cliente = new ClienteNave();
                //btn_Conectar.Enabled = false;
                cliente.puerto = 9250;
                cliente.Start_Client();

                MostrarMsgLog("Conexión verificada", Color.Green);
                btn_Archivo.Enabled = true;
                conectado_planeta = true;
            }
            catch
            {
                MostrarMsgLog("Error al conectar con el planeta", Color.Red);
                btn_Conectar.Enabled = true;
                conectado_planeta = false;
            }
        }
        private void MostrarMsgLog(string msg, Color color)
        {
            console_Log.AppendText(msg + "\r\n");
            
            console_Log.Select(console_Log.Text.Length-msg.Length-1, msg.Length);
            console_Log.SelectionColor = color;
        }

        //Enviar Mensaje al Planeta
        private void btn_Mensaje_Click(object sender, EventArgs e)
        {

        }

        //Devolver Fichero
        private void btn_Archivo_Click(object sender, EventArgs e)
        {

        }

        //LOAD
        private void NaveForm_Load(object sender, EventArgs e)
        {
            btn_Archivo.Enabled = false;
        }
    }
}
