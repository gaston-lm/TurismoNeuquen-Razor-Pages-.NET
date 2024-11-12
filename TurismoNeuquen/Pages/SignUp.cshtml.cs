using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ILoginService _loginService;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; private set; }

        public SignUpModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return Page();
            }

            // Await the UserExistsAsync method
            if (await _loginService.UserExists(Username))
            {
                ErrorMessage = "Username already exists.";
                return Page();
            }

            // Await the RegisterUserAsync method
            bool isRegistered = await _loginService.RegisterUser(Username, Password);
            if (isRegistered)
            {
                return RedirectToPage("/UserLogin");
            }
            else
            {
                ErrorMessage = "An error occurred during registration. Please try again.";
                return Page();
            }
        }
    }
}