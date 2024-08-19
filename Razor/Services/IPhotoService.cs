using CloudinaryDotNet.Actions;

namespace Razor.Services;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);

}