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
        

        public bool Comprimir(string startPath, string zipPath)
        {
            try
            {
                if (File.Exists(zipPath))File.Delete(zipPath);
                ZipFile.CreateFromDirectory(startPath, zipPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Descomprimir(string zipPath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(extractPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Comparar(string original_file_path, string returned_file_path)
        {
            string original_text, returned_text;
            int hashcode_original, hashcode_returned;

            original_text = File.ReadAllText(original_file_path).Trim();
            returned_text = File.ReadAllText(returned_file_path).Trim();

            hashcode_original = original_text.GetHashCode();
            hashcode_returned = returned_text.GetHashCode();

            return original_text.GetHashCode() == returned_text.GetHashCode();
        }
    }
}