using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace TurismoNeuquen.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // Sign the user out and clear the authentication cookie
            await HttpContext.SignOutAsync("UserCookie");

            // Redirect to the login page or homepage
            return RedirectToPage("/UserLogin");
        }
    }
}