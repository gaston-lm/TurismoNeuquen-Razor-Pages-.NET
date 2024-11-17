namespace TurismoNeuquen.Services
{

    public interface IUploadImageAPIService
    {
        Task<string> UploadFile(IFormFile file);
    }
}