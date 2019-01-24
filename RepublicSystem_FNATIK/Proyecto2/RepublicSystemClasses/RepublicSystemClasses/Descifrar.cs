using System;
using System.IO;
using System.Windows.Forms;

namespace RepublicSystemClasses
{
    public class Descifrar
    {
        ZipUnzipCompare zuc;
        public bool DescifrarFichero()
        {
            //Descomprimir el fichero
            try
            {
                zuc = new ZipUnzipCompare();
                zuc.Descomprimir();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}