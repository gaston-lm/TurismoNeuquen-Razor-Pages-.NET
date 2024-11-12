namespace TurismoNeuquen.Services
{
    public interface ILoginService
    {
        bool ValidateCredentials(string username, string password);

        bool ValidateUserCredentials(string username, string password);

        Task<bool> UserExists(string username);

        Task<bool> RegisterUser(string username, string password);
    }
}