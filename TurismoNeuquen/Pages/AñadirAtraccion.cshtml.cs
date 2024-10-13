using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Pages
{
    public class AñadirAtraccionModel : PageModel
    {
        private readonly DbMemoria _context;

        public List<Atraction> ListOfAtractions { get; set; } = new List<Atraction> { };

        [BindProperty]

        public Atraction NewAtraction { get; set; }

        public AñadirAtraccionModel(DbMemoria context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ListOfAtractions = _context.Atracciones.ToList();
        }

        public IActionResult OnPost() 
        {
            _context.Atracciones.Add(NewAtraction); // LLamar a una funcion que se encargue de añadir un punto a la lista.
            _context.SaveChanges();
            return RedirectToPage();    
        }
    }
}
