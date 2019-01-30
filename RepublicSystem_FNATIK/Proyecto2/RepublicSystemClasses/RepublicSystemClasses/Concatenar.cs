using System;
using System.IO;

namespace RepublicSystemClasses
{
    public class Concatenar
    {
        public void ConcatenaFicheros(string Directorio, string ArchivoFinal)
        {
            string[] inputFilePaths = Directory.GetFiles(Directorio);
            if (File.Exists(ArchivoFinal)) File.Delete(ArchivoFinal);

            using (var outputStream = File.Create(ArchivoFinal))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }
                }
            }
        }
    }
}
