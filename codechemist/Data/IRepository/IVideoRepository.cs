namespace codechemist.Data.IRepository
{
    public interface IVideoRepository
    {
        Task<string> WriteFile(IFormFile file);
    }
}
