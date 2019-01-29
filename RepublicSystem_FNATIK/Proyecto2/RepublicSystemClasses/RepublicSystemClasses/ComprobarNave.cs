using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RepublicSystemClasses
{    
    public class ComprobarNave
    {
        public string datosEnvio;
        public AccesoBD ab = new AccesoBD();
        public DataSet ds = new DataSet();
            
        public bool Comprobacion(string datosEnvio)
        {
            bool ver = false;
            string codigoNave = datosEnvio.Substring(8, 15);
            string codigoEnvio = datosEnvio.Substring(15);
            string año = datosEnvio.Substring(4,7);
            string mes = datosEnvio.Substring(0,1);
            string dia = datosEnvio.Substring(1,2);
            
            ds = ab.PortarPerConsulta("select * from deliveryData where SpaceShip = '"+ codigoNave +"' AND CODEDELIVERY = '"+ codigoEnvio + "' DELIVERYDATE = '"+ año +"-"+ mes +"-"+ dia +" 00:00:00'");
            int rows = ds.Tables[0].Rows.Count;

            if (rows == 1)
            {
                ver = true;
            }

            return ver;
        }


    }
}
