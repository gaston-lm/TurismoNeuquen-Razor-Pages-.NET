namespace TurismoNeuqen.Services
{

    public interface IUploadImage
    {
        Task<string> UploadFile(IFormFile file);
    }
}