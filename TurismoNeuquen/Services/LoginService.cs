using System.Linq;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public class LoginService : ILoginService
    {
        private readonly PoiContext _context;

        public LoginService(PoiContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
            return admin != null;
        }
    }
}