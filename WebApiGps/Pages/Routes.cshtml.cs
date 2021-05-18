using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiGps.IServices;
using WebApiGps.Models;

namespace WebApiGps.Pages
{
    public class RoutesModel : PageModel
    {
        //Metodo para acesso a interface localizacao
        private readonly ILocationService locationService;
        public RoutesModel(ILocationService location)
        {
            locationService = location;
        }
        //Lista de localizações       
        public IEnumerable<Location> GetLocations()
        {
            return locationService.GetLocations();
        }

        public IEnumerable<Location> Locations { get; private set; }

        //Retorna localizações
        public void OnGet()
        {
            Locations = GetLocations();

        }
    }
}
