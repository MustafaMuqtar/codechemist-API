namespace codechemist.Data.IRepository
{
    public interface IFIleRepository
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> UploadVideo(IFormFile file);
        Task<string> UploadPDF(IFormFile file);
        Task RemoveFile(string filename, string directory);



    }
}
