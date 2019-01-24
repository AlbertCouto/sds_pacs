using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace RepublicSystemClasses
{
    public class ComprimirDescomprimirComparar
    {
        
        //Rutas on estan i on aniran els arxius
        //string startPath = @"C:\Users\admin\Desktop\start";
        //string zipPath = @"C:\Users\admin\Desktop\result.zip";
        //string zipPathCompr = @"C:\Users\admin\Desktop\result.zip";
        //string extractPath = @"C:\Users\admin\Desktop\extract";

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