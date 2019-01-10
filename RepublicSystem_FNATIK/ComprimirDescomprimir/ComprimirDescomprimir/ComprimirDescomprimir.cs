using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprimirDescomprimir
{
    class ComprimirDescomprimir
    {
        //Ruta on estan els arxius
        string startPath = @"C:\Users\admin\Desktop\start";

        //Ruta on va el zip + nom del zip (Tant si existeix com si no)
        string zipPath = @"C:\Users\admin\Desktop\result.zip";

        //Ruta on està el ZIP comprimit
        string zipPathCompr = @"C:\Users\admin\Desktop\result.zip";

        //Ruta on es descomprimeix el zip
        string extractPath = @"C:\Users\admin\Desktop\extract";



        private void Comprimir(string startPath, string zipPath)
        {
            if (!System.IO.File.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }
        }


        private void Descomprimir(string zipPath, string extractPath)
        {
            if (System.IO.File.Exists(zipPathCompr))
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
    }
}
