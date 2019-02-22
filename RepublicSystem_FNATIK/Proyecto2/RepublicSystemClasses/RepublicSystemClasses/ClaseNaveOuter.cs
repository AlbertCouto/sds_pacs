using System;
using System.Collections.Generic;
using System.Data;
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
        UdpClient udpServer = new UdpClient(9423);
        UdpClient udpCli = new UdpClient();
        Thread T;
        GenerarMensajes gm = new GenerarMensajes();
        RSA rs = new RSA();
        AccesoBD bd = new AccesoBD();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public void Start()
        {
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
                    StartClientNoE();
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
    }
}
