using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Web.Pages
{
	public class LocationsModel : PageModel
    {
        public IEnumerable<string>? Locations { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "SWC Bank - Locations";

            Locations = new[]
            {
                "Albuquerque Branch,\n" +
                "    86 Cromwell Path\n" +
                "Albuquerque, NM 75309",
            };
        }
    }
}
