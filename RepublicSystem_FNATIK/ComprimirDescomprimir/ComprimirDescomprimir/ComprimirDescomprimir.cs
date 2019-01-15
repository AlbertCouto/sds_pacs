using System;
using System.Windows.Forms;
using System.IO.Compression;

namespace ComprimirDescomprimir
{
    public class ComprimirDescomprimir
    {
        //Ruta on estan els arxius
        string startPath = @"C:\Users\admin\Desktop\start";

        //Ruta on va el zip + nom del zip (Tant si existeix com si no)
        string zipPath = @"C:\Users\admin\Desktop\result.zip";

        //Ruta on està el ZIP comprimit
        string zipPathCompr = @"C:\Users\admin\Desktop\result.zip";

        //Ruta on es descomprimeix el zip
        string extractPath = @"C:\Users\admin\Desktop\extract";



        public void Comprimir(string startPath, string zipPath)
        {
            //if (!System.IO.File.Exists(zipPath))
            //{
                try
                {
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                }
                catch
                {
                    MessageBox.Show("Error al comprimir ficheros.");
                }
            //}
        }

        public void Descomprimir(string zipPath, string extractPath)
        {
            if (System.IO.File.Exists(zipPathCompr))
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
    }
}
