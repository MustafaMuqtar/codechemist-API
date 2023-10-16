using CloudinaryDotNet.Actions;

namespace codechemist.Data.IRepository
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile formFile);
        Task<VideoUploadResult> AddAudioAsync(IFormFile formFile);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
