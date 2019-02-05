using System;
using System.Net.NetworkInformation;
using System.Net;
using RepublicSystemClasses;

namespace RepublicSystemClasses
{
    public class Conexiones_NavePlaneta
    {
        AccesoBD bd = new AccesoBD();
        ZipUnzipCompare zuc = new ZipUnzipCompare();
        Ping ping = new Ping();
        ClaseNave cliente = new ClaseNave();
        Concatenar con = new Concatenar();
        Desencriptar dc = new Desencriptar();
        public bool Ping()
        {
            try
            {
                PingReply pingStatus = ping.Send(IPAddress.Parse("8.8.8.8"));
                PingReply pingStatus2 = ping.Send(IPAddress.Parse((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3").Tables[0].Rows[0][0]).ToString()));
                return (pingStatus.Status == IPStatus.Success) && (pingStatus2.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
        }
        public bool EnviarCodigo()
        {
            try
            {
                cliente.puerto = Convert.ToInt32(bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1").Tables[0].Rows[0][0]);
                cliente.Start_Client();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GestionarFicheros(string ruta)
        {
            string ruta_directorio_ficheros_numeros = "C:\\Users\\admin\\Desktop\\PACS\\NaveTXT";
            string ruta_fichero_numeros_concatenados = "C:\\Users\\admin\\Desktop\\PACS\\PACS.txt";
            string ruta_fichero_letras_concatenadas = "C:\\Users\\admin\\Desktop\\PACS\\PACSSOL.txt";
            try
            {
                zuc.Descomprimir(ruta);
                con.ConcatenaFicheros(ruta_directorio_ficheros_numeros, ruta_fichero_numeros_concatenados);
                dc.DesencriptarFichero(ruta_fichero_numeros_concatenados, ruta_fichero_letras_concatenadas);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
