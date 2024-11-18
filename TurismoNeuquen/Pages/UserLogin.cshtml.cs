using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class UserLoginModel : PageModel
    {
        private readonly ILoginService _loginService;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; private set; }

        public UserLoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult OnPost()
        {
            if (_loginService.ValidateUserCredentials(Username, Password))
            {
                var userId = _loginService.GetUserId(Username, Password); // Retrieve the user ID for the username

                var claims = new List<Claim>
                {
                    new Claim("UserId", userId), // Add User ID as a custom claim
                    new Claim("Username", Username) // Add User ID as a custom claim
                };

                var identity = new ClaimsIdentity(claims, "UserCookie");
                var principal = new ClaimsPrincipal(identity);

                // Sign in using the second cookie authentication scheme
                HttpContext.SignInAsync("UserCookie", principal, new AuthenticationProperties
                {
                    IsPersistent = false, // Evita que la cookie sea persistente
                });

                // Redirect to a user dashboard or home page upon successful login
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
