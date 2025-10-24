using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };

        const int maxSize = 2_097_152; 

        public string? Upload(IFormFile file, string folderName)
        {

           var extention =  Path.GetExtension(file.FileName); 

            if(!allowedExtensions.Contains(extention))
            {
                return null;
            }
            if(file.Length > maxSize || file.Length == 0)
            {
                return null;
            }



            // var folderPath =$"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}"  ;

            var folderPath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);

            
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderPath, fileName);

            using FileStream fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);

            return fileName;

        }








        public bool Delete(string filePath)
        {

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;


        }







    }








}
