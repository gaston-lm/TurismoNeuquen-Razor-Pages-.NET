namespace TurismoNeuquen.Services
{
    public interface ILoginService
    {
        bool ValidateCredentials(string username, string password);
    }
}