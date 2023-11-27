using CloudinaryDotNet;
using codechemist.Data.IRepository;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace codechemist.Data.Services
{
    public class FIleService : IFIleRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        public FIleService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetFilePath(string filename, string directory)
        {
            return _webHostEnvironment.WebRootPath + directory + filename;
        }




        public async Task<string> UploadImage(IFormFile file)
        {
            string filename = "";
            string directory = "/Uploads/Images/";

            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;


            string filepath = GetFilePath(filename, directory);




            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            string hostUrl = "https://localhost:7040/";
            string ImageUrl = hostUrl + "/Uploads/Images/" + filename;
            return ImageUrl;


        }

        public async Task<string> UploadVideo(IFormFile file)
        {
            string filename = "";
            string directory = "/Uploads/Videos/";

            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;

            string filepath = GetFilePath(filename, directory);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            string hostUrl = "https://localhost:7040/";
            string ImageUrl = hostUrl + "/Uploads/Videos/" + filename;

            return ImageUrl;
        }

        public async Task<string> UploadPDF(IFormFile file)
        {
            string filename = "";
            string directory = "/Uploads/PDFs/";

            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;

            string filepath = GetFilePath(filename, directory);


            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            string hostUrl = "https://localhost:7040/";
            string ImageUrl = hostUrl + "/Uploads/PDFs/" + filename;
            return ImageUrl;

        }

        public async Task RemoveFile(string fileURL, string directory)
        {


            GetFilePath(fileURL, directory);
            string fileName = Path.GetFileName(new Uri(fileURL).LocalPath);
            var filepath = _webHostEnvironment.WebRootPath + directory + fileName;

            if (File.Exists(filepath))
            {
                File.Delete(filepath);

            }

        }


    }
}