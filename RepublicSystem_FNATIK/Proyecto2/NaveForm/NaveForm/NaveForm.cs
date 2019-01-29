﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using RepublicSystemClasses;
using System.Net;

namespace NaveForm
{
    public partial class NaveForm : Form
    {
        private static AccesoBD bd = new AccesoBD();
        private static ClienteNave cliente = new ClienteNave();
        private static bool conexion_ok;
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
            if (Ping())
            {
                conexion_ok = true;
                MostrarMsgLog("Conexión a Internet Verificada", Color.Green);
            }
            else
            {
                MostrarMsgLog("Error de conexión a Internet", Color.Red);
                conexion_ok = false;
            }
        }
        private bool Ping()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(IPAddress.Parse("8.8.8.8"));
                PingReply pingStatus2 = ping.Send(IPAddress.Parse(((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString()));
                return (pingStatus.Status == IPStatus.Success) && (pingStatus2.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
        }
        //Enviar Mensaje al Planeta
        private void btn_Mensaje_Click(object sender, EventArgs e)
        {
            if (conexion_ok)
            {
                try
                {
                    btn_Mensaje.Enabled = false;
                    cliente.puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
                    cliente.Start_Client();

                    MostrarMsgLog("Mensaje Enviado", Color.Green);
                    btn_Mensaje.Enabled = true;
                }
                catch
                {
                    MostrarMsgLog("Error al enviar el mensaje", Color.Red);
                }
            }
            else MessageBox.Show("Debe Verificar Conexión");
        }
        //Devolver Fichero
        private void btn_DevolverFichero_Click_1(object sender, EventArgs e)
        {
            if (conexion_ok)
            {
                Descifrar d = new Descifrar();
                if (!d.DescifrarFichero())
                {
                    MessageBox.Show("Error al Descifrar el Fichero");
                    return;
                }
                MostrarMsgLog("Ficheros TXT Generados", Color.Green);


            }
            else MessageBox.Show("Debe Verificar Conexión");
        }
        //LOAD
        private void NaveForm_Load(object sender, EventArgs e)
        {
            conexion_ok = false;
        }


        private void MostrarMsgLog(string msg, Color color)
        {
            console_Log.AppendText(msg + "\r\n");

            console_Log.Select(console_Log.Text.Length - msg.Length - 1, msg.Length);
            console_Log.SelectionColor = color;
        }
    }
}