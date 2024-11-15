using Microsoft.EntityFrameworkCore;
using System.Linq;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public class LoginService : ILoginService
    {
        private readonly dataContext _context;

        public LoginService(dataContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
            return admin != null;
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            var admin = _context.Users.FirstOrDefault(a => a.Username == username && a.Password == password);
            return admin != null;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(a => a.Username == username);
        }

        public async Task<bool> RegisterUser(string username, string password)
        {

            // Create new user
            var user = new User
            {
                Username = username,
                Password = password
            };

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true; // Registration successful
        }
    }
}