using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Pages
{
    public abstract class BaseDetailsPoiModel : PageModel
    {
        protected abstract PointOfInterest GetPointOfInterest(int id);

        public PointOfInterest PointOfInterest { get; set; } = new Attraction();
        public Attraction Attraction { get; set; } = new Attraction();
        public Event Event { get; set; } = new Event();
        public int Type { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the PointOfInterest object
            PointOfInterest = GetPointOfInterest(id);

            // Check if the PointOfInterest was not found
            if (PointOfInterest == null)
            {
                return NotFound();
            }

            // Determine the type of PointOfInterest
            if (PointOfInterest is Attraction attraction)
            {
                Type = 1;
                Attraction = attraction;
                Console.Write(Attraction.Name);
            }
            else if (PointOfInterest is Event eventObj)
            {
                Type = 0;
                Event = eventObj;
            }
            else
            {
                // Handle the case where PointOfInterest is neither an Attraction nor an Event
                return NotFound();
            }

            return Page();
        }

        public string GetOpenDays(string openDaysBinary)
        {
            if (string.IsNullOrEmpty(openDaysBinary))
                return "Not specified";

            var daysOfWeek = new[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            var openDays = new List<string>();

            for (int i = 0; i < openDaysBinary.Length && i < daysOfWeek.Length; i++)
            {
                if (openDaysBinary[i] == '1')
                    openDays.Add(daysOfWeek[i]);
            }

            return string.Join(", ", openDays);
        }
    }
}
