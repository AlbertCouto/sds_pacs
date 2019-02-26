using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepublicSystemClasses
{
    public class ClaseNaveOuter
    {
        UdpClient udpServer;
        UdpClient udpCli = new UdpClient();
        Thread T;
        GenerarMensajes gm = new GenerarMensajes();
        RSA rs = new RSA();
        AccesoBD bd = new AccesoBD();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public Form form { get; set; }
        public void Start()
        {
            Int32 puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortSpaceShipText from SpaceShips where idSpaceShip = 1")).Tables[0].Rows[0][0]);
            udpServer = new UdpClient(puerto);
            T = new Thread(StartServer);
            T.Start();
        }


        public void StartServer()
        {
            while (true)
            {
                IPEndPoint IeP = new IPEndPoint(IPAddress.Any, 0);
                Byte[] BytesIn = udpServer.Receive(ref IeP);
                string returnData = Encoding.ASCII.GetString(BytesIn);

                if (returnData.Length > 0)
                {
                    MostrarMsgLog(returnData, Color.Green);
                }

            }
        }

        public void StartClient()
        {
            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            Int32 puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 3")).Tables[0].Rows[0][0]);
            DataSet ds = new DataSet();
            string mensaje, clave_publica;
            byte[] mensaje_bytes = null;

            ds = bd.PortarPerConsulta("select XMLKey from PlanetKeys where idKey = (select MAX(idKey) from PlanetKeys)");
            clave_publica = ds.Tables[0].Rows[0][0].ToString();
            MessageBox.Show(clave_publica);

            RSA.FromXmlString(clave_publica);

            mensaje = gm.GenerarMensajeInicio();
            mensaje_bytes = rs.RSAEncrypt(Encoding.ASCII.GetBytes(mensaje), RSA.ExportParameters(false));

            IPAddress ipbien = IPAddress.Parse(IP);
            udpCli.Connect(ipbien, puerto);
            udpCli.Send(mensaje_bytes, mensaje_bytes.Length);

        }
        public void StartClientNoE()
        {
            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            Int32 puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 3")).Tables[0].Rows[0][0]);
            DataSet ds = new DataSet();
            string mensaje;
            byte[] mensaje_bytes = null;


            mensaje = gm.GenerarMensajeInicio();
            mensaje_bytes = Encoding.ASCII.GetBytes(mensaje);

            IPAddress ipbien = IPAddress.Parse(IP);
            udpCli.Connect(ipbien, puerto);
            udpCli.Send(mensaje_bytes, mensaje_bytes.Length);

        }

        private void MostrarMsgLog(string msg, Color color)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.GetType() == typeof(RichTextBox))
                {
                    ((RichTextBox)ctrl).Invoke((MethodInvoker)delegate
                    {
                        ((RichTextBox)ctrl).AppendText(msg + "\r\n");
                        ((RichTextBox)ctrl).Select(((RichTextBox)ctrl).Text.Length - msg.Length - 1, msg.Length);
                        ((RichTextBox)ctrl).SelectionColor = color;
                    });
                }
            }
        }
    }
}
