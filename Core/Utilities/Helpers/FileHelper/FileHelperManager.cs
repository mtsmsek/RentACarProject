using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager 
    {
        public static void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                Console.WriteLine("Aradığınız resim veri tabanında bulunamadı.");
            }
        }

        public static string Update(IFormFile formFile, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return Upload(formFile);
        }

        public static string Upload(IFormFile formFile)
        {
          
                string imageExtension = Path.GetExtension(formFile.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string imagePath = $"wwwroot/images/{imageName}";

                using (FileStream fileStream = File.Create(imagePath))
                {

                    formFile.CopyTo(fileStream);

                }
                return imagePath;
            
          


        }
    }
}
