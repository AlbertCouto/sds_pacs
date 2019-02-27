using System;
using System.IO;

namespace RepublicSystemClasses
{
    public class Concatenar
    {
        public bool ConcatenaFicheros(string Directorio, string ArchivoFinal)
        {
            try
            {
                string[] inputFilePaths = Directory.GetFiles(Directorio);
                FileStream outputStream;
                FileStream inputStream;

                if (File.Exists(ArchivoFinal)) File.Delete(ArchivoFinal);

                using (outputStream = File.Create(ArchivoFinal))
                {
                    foreach (var inputFilePath in inputFilePaths)
                    {
                        using (inputStream = File.OpenRead(inputFilePath))
                        {
                            // Buffer size can be passed as the second argument.
                            inputStream.CopyTo(outputStream);
                        }
                        inputStream.Close();
                    }
                }
                outputStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
