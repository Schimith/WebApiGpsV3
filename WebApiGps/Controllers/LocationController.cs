using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.IServices;
using WebApiGps.Models;
using WebApiGps.Services;

namespace WebApiGps.Controllers
{
    //Contexto /api/location
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        //Metodo para acesso a interface localizacao
        private readonly ILocationService locationService;
        public LocationController(ILocationService location)
        {
            locationService = location;
        }
        //Metodo para o contexto raiz /api/location
        [HttpGet]
        [Route("")]
        public IEnumerable<Location> GetLocations()
        {
            return locationService.GetLocations();
        }
        //Metodo para o contexto /api/location/add
        [HttpPost]
        [Route("add")]
        public Location AddLocation(Location location)
        {
            return locationService.AddLocation(location);
        }
        //Metodo para o contexto /api/location/edit
        [HttpPut]
        [Route("edit")]
        public Location EditLocation(Location location)
        {
            return locationService.UpdateLocation(location);
        }
        //Metodo para o contexto /api/location/delete?id=chaveprimaria
        [HttpDelete]
        [Route("delete")]
        public Location DeleteLocation(int id)
        {
            return locationService.DeleteLocation(id);
        }
        //Metodo para o contexto /api/location/get?id=chaveprimaria
        [HttpGet]
        [Route("get")]
        public Location GetLocationId(int id)
        {
            return locationService.GetLocationById(id);
        }
    }
}
