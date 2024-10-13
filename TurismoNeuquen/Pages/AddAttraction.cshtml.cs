using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TurismoNeuquen.Pages
{
    public class AddAttractionModel : PageModel
    {
        private readonly DbMemoria _context;

        public List<Attraction> ListOfAtractions { get; set; } = new List<Attraction>();

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string AttractionType { get; set; }

        [BindProperty]
        public DateTime EventDateBegin { get; set; }

        [BindProperty]
        public DateTime EventDateEnd { get; set; }

        [BindProperty]
        public string OpenDays { get; set; } // Comma-separated

        [BindProperty]
        public TimeOnly? OpeningTime { get; set; }

        [BindProperty]
        public TimeOnly? ClosingTime { get; set; }

        [BindProperty]
        public double Latitude { get; set; }  // Add Latitude property

        [BindProperty]
        public double Longitude { get; set; } // Add Longitude property

        public AddAttractionModel(DbMemoria context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ListOfAtractions = _context.Atracciones.ToList();
        }

        public IActionResult OnPost()
        {
            Attraction newAttraction;

            if (AttractionType == "Event")
            {
                newAttraction = new Event(
                    Name,
                    Description,
                    Latitude,
                    Longitude,
                    EventDateBegin,
                    EventDateEnd
                )
                {
                    State = false
                };
            }
            else // PointOfInterest
            {
                var openDaysList = OpenDays?.Split(",").ToList();
                newAttraction = new PointOfInterest(
                    Name,
                    Description,
                    Latitude,
                    Longitude,
                    openDaysList,
                    OpeningTime,
                    ClosingTime
                )
                {
                    State = false
                };
            }

            _context.Atracciones.Add(newAttraction);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
