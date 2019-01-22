using System;
using System.Windows.Forms;
using System.IO.Compression;

namespace RepublicSystemClasses
{
    public class ComprimirDescomprimir
    {
        
        //Rutas on estan i on aniran els arxius
        string startPath = @"C:\Users\admin\Desktop\start";
        string zipPath = @"C:\Users\admin\Desktop\result.zip";
        string zipPathCompr = @"C:\Users\admin\Desktop\result.zip";
        string extractPath = @"C:\Users\admin\Desktop\extract";

        public void Comprimir(string startPath, string zipPath)
        {
            try
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }
            catch
            {
                MessageBox.Show("Error al comprimir ficheros.");
            }
        }

        public void Descomprimir(string zipPath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }  
            catch
            {
                MessageBox.Show("Error al descomprimir ficheros.");
            }
        }
    }
}