using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly ILoginService _loginService;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; private set; }

        public AdminLoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult OnPost()
        {
            if (_loginService.ValidateCredentials(Username, Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim("IsAdmin", "true") // Custom claim to indicate admin
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/Admin"); // Redirect to Admin page upon successful login
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}