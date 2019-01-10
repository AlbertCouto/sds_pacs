using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescCompr
{
    public class ComprDescompr
    {
        //Ruta on estan els arxius
        string startPath;
        //startPath = @"C:\Users\admin\Desktop\start";

        //Ruta on va el zip + nom del zip (Tant si existeix com si no)
        string zipPath;
        //zipPath = @"C:\Users\admin\Desktop\result.zip";

        //Ruta on està el ZIP comprimit
        string zipPathCompr;

        //Ruta on es descomprimeix el zip
        string extractPath;



        public void Comprimir(string startPath, string zipPath)
        {
            if (!System.IO.File.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }
        }


        public void Descomprimir(string zipPath, string extractPath)
        {

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            
        }
    }
}
