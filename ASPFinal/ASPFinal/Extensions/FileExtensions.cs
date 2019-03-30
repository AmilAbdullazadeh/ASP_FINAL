using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ASPFinal.Extensions
{
    public static class FileExtensions
    {
        public static bool CheckImageType(HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" ||
                    file.ContentType == "image/png" || file.ContentType == "image/gif";
        }

        public static string SaveImage(string folderPath, HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);

            string newFilePath = Path.Combine(folderPath, filename);

            file.SaveAs(newFilePath);

            return filename;
        }

        public static bool DeleteImage(string folderPath, string filename)
        {
            string fullFilePath = Path.Combine(folderPath, filename);

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
                return true;
            }

            return false;
        }
    }
}