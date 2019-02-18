using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
using RepublicSystemClasses;

namespace NaveForm
{
    public partial class NaveForm : Form
    {
        string ruta_inicial = "C:\\Users\\admin\\Desktop\\PACS.ZIP";
        private static AccesoBD bd = new AccesoBD();
        Thread th1;
        Thread th2;
        Thread th3;
       
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
            
            th1 = new Thread(ConectarConPlaneta);
            th1.Start();

        }
        private void ConectarConPlaneta()
        {
            Ping ping = new Ping();
            MostrarMsgLog("Conectando...", Color.White);
            try
            {
                PingReply pingStatus = ping.Send(IPAddress.Parse("8.8.8.8"));
                PingReply pingStatus2 = ping.Send(IPAddress.Parse((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3").Tables[0].Rows[0][0]).ToString()));
                string planeta = (bd.PortarPerConsulta("select DescPlanet from Planets where idPlanet = 3").Tables[0].Rows[0][0]).ToString();
                if (pingStatus.Status == IPStatus.Success) MostrarMsgLog("Conexión a Internet Correcta", Color.Green);
                else MostrarMsgLog("No hay conexión a Internet", Color.Red);
                if (pingStatus2.Status == IPStatus.Success) MostrarMsgLog("Conexión con "+planeta+" Correcta", Color.Green);
                else MostrarMsgLog("No hay Conexión con "+planeta, Color.Red);
            }
            catch
            {
                MostrarMsgLog("Error de conexión", Color.Red);
            }
        }

        //Enviar Mensaje al Planeta
        private void btn_Mensaje_Click(object sender, EventArgs e)
        {
            th2 = new Thread(EnviarCodigoPlaneta);
            th2.Start();
        }
        private void EnviarCodigoPlaneta()
        {
            ClaseNave cn = new ClaseNave();
            if (btn_Mensaje.InvokeRequired)
            {
                btn_Mensaje.Invoke((MethodInvoker)delegate
                {
                    btn_Mensaje.Enabled = false;
                });
            }
            MostrarMsgLog("Enviando Código...", Color.White);
            string planeta = (bd.PortarPerConsulta("select DescPlanet from Planets where idPlanet = 3").Tables[0].Rows[0][0]).ToString();

            try
            {
                cn.form = FindForm();
                cn.puerto = Convert.ToInt32(bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1").Tables[0].Rows[0][0]);
                cn.Start_Client();
            }
            catch
            {
                MostrarMsgLog("Error con " + planeta, Color.Red);
            } 

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
            ZipUnzipCompare zuc = new ZipUnzipCompare();
            ClaseNave cn = new ClaseNave();
            Desencriptar dc = new Desencriptar();
            Concatenar con = new Concatenar();
            MostrarMsgLog("Generando Fichero PACSSOL...", Color.White);
            string planeta = (bd.PortarPerConsulta("select DescPlanet from Planets where idPlanet = 3").Tables[0].Rows[0][0]).ToString();
            string ruta_directorio_ficheros_numeros = "C:\\Users\\admin\\Desktop\\PACS\\NaveTXT";
            string ruta_fichero_numeros_concatenados = "C:\\Users\\admin\\Desktop\\PACS\\PACS.txt";
            string ruta_fichero_letras_concatenadas = "C:\\Users\\admin\\Desktop\\PACS\\PACSSOL.txt";
            try
            {
                if (zuc.Descomprimir("C:\\Users\\admin\\Desktop\\PACS.ZIP"))
                    MostrarMsgLog("Fichero PACS Descomprimido", Color.Green);
                else
                {
                    MostrarMsgLog("Error al Descomprimir PACS", Color.Red);
                    throw new Exception();
                }
                if (!con.ConcatenaFicheros(ruta_directorio_ficheros_numeros, ruta_fichero_numeros_concatenados))
                {
                    MostrarMsgLog("Error al Concatenar los ficheros PACS", Color.Red);
                    throw new Exception();
                }
                if (dc.DesencriptarFichero(ruta_fichero_numeros_concatenados, ruta_fichero_letras_concatenadas))
                    MostrarMsgLog("Fichero Desencriptado", Color.Green);
                else
                {
                    MostrarMsgLog("Error al Desencriptar PACS", Color.Red);
                    throw new Exception();
                }
                MostrarMsgLog("Enviando Fichero PACSSOL...", Color.White);
                if (cn.Start_Client_File())
                    MostrarMsgLog("Fichero PACSSOL devuelto correctamente a " + planeta + ", esperando confirmación...", Color.Green);
                else
                {
                    MostrarMsgLog("Error en el envío de PACSSOL", Color.Red);
                    throw new Exception();
                }
            }
            catch
            {
                MostrarMsgLog("Imposible devolver el Fichero a " + planeta, Color.Red);
            }
        }

        //LOAD
        private void NaveForm_Load(object sender, EventArgs e)
        {
            //if (File.Exists(ruta_inicial)) File.Delete(ruta_inicial);
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