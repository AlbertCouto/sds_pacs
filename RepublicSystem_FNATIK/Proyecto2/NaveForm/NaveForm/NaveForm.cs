using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using RepublicSystemClasses;

namespace NaveForm
{
    public partial class NaveForm : Form
    {
        private static AccesoBD bd = new AccesoBD();
        private static Conexiones_NavePlaneta cnp = new Conexiones_NavePlaneta();
        Thread th1;
        Thread th2;
        Thread th3;
        ClaseNave cn = new ClaseNave();

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
            Form frm = FindForm();
            cn.form = frm;
            th1 = new Thread(ConectarConPlaneta);
            th1.Start();

        }
        private void ConectarConPlaneta()
        {
            MostrarMsgLog("Conectando...", Color.White);
            if (cnp.Ping()) MostrarMsgLog("Conexión a Internet Verificada", Color.Green);
            else MostrarMsgLog("Error de conexión", Color.Red);
        }

        //Enviar Mensaje al Planeta
        private void btn_Mensaje_Click(object sender, EventArgs e)
        {
            th2 = new Thread(EnviarCodigoPlaneta);
            th2.Start();
        }
        private void EnviarCodigoPlaneta()
        {
            if (btn_Mensaje.InvokeRequired)
            {
                btn_Mensaje.Invoke((MethodInvoker)delegate
                {
                    btn_Mensaje.Enabled = false;
                });
            }
            MostrarMsgLog("Enviando Código...", Color.White);
            if (cnp.EnviarCodigo()) MostrarMsgLog("Código Enviado", Color.Green);
            else MostrarMsgLog("Error al enviar el código", Color.Red);
            if (btn_Mensaje.InvokeRequired)
            {
                btn_Mensaje.Invoke((MethodInvoker)delegate
                {
                    btn_Mensaje.Enabled = true;
                });
            }
        }

        //Devolver Fichero
        private void btn_DevolverFicheroClick(object sender, EventArgs e)
        {
            th3 = new Thread(DevolverFicheroPlaneta);
            th3.Start();
        }
        private void DevolverFicheroPlaneta()
        {
            string ruta_inicial = "C:\\Users\\admin\\Desktop\\PACS.ZIP";
            MostrarMsgLog("Enviando Fichero al Planeta...", Color.White);
            if (cnp.GestionarFicheros(ruta_inicial))
                MostrarMsgLog("Fichero devuelto correctamente", Color.Green);
            else MostrarMsgLog("Error al devolver el fichero", Color.Red);
        }

        //LOAD
        private void NaveForm_Load(object sender, EventArgs e)
        {
        }

        //Mostrar Mensaje
        private void MostrarMsgLog(string msg, Color color)
        {
            if(console_Log.InvokeRequired)
            {
                console_Log.Invoke((MethodInvoker)delegate
                {
                    console_Log.AppendText(msg + "\r\n");
                    console_Log.Select(console_Log.Text.Length - msg.Length - 1, msg.Length);
                    console_Log.SelectionColor = color;
                });
            }
        }
    }
}