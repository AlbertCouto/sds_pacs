using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace RepublicSystemClasses
{
    public class ZipUnzipCompare
    {
        //Rutas on estan i on aniran els arxius
        //string startPath    = @"C:\Users\admin\Desktop\PACS\PlanetTXT";
        //string zipPath      = @"C:\Users\admin\Desktop\PACS\PACS.zip";
        string extractPath  = @"C:\Users\admin\Desktop\PACS\NaveTXT";
        

        public void Comprimir(string startPath, string zipPath)
        {

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
                try
                {
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                    MessageBox.Show("Archivo listo para enviar");
                }
                catch
                {
                    MessageBox.Show("Error al comprimir ficheros.");
                }
            }
            else
            {
                try
                {
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                    MessageBox.Show("Archivo listo para enviar");
                }
                catch
                {
                    MessageBox.Show("Error al comprimir ficheros.");
                }
            }

        }

        public void Descomprimir(string zipPath)
        {
            DirectoryInfo di = new DirectoryInfo(extractPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        public bool Comparar(string original_file_path, string returned_file_path)
        {
            string original_text, returned_text;
            int hashcode_original, hashcode_returned;
            bool boolean = false;

            original_text = File.ReadAllText(original_file_path);
            returned_text = File.ReadAllText(returned_file_path);

            hashcode_original = original_text.GetHashCode();
            hashcode_returned = returned_text.GetHashCode();

            if (hashcode_original == hashcode_returned)
            {
                boolean = true;
            };
            return boolean;
        }
    }
}