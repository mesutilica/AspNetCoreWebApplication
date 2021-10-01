using System.IO;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreWebApplication.Utils
{
    public class FileHelper
    {
        public static string FileLoader(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";

            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
                using (var stream = new FileStream(directory, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }

            return fileName;
        }

        public static bool FileTerminator(string fileName, string filePath = "/Img/")
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;

            if (File.Exists(directory)) //File.Exists metodu directory parametresinde gerçek bir dosya var mı yok mu onu kontrol eder
            {
                File.Delete(directory);
                return true;
            }

            return false;
        }

    }
}
