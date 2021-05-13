using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.IServices;
using WebApiGps.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiGps.Services
{
    public class LocationService : ILocationService
    {
        //Metodo para acesso ao sgbd
        EMPRESAContext dbContext;
        public LocationService(EMPRESAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar as localizações
        public IEnumerable<Location> GetLocations()
        {
            var location = dbContext.Locations.ToList();
            return location;
        }
        //Metodo para adicionar nova localizacao
        public Location AddLocation(Location location)
        {
            if (location != null)
            {
                dbContext.Locations.Add(location);
                dbContext.SaveChanges();
                return location;
            }
            return null;
        }
        //Metodo para atualizar localizacao
        public Location UpdateLocation(Location location)
        {
            dbContext.Entry(location).State = EntityState.Modified;
            dbContext.SaveChanges();
            return location;
        }
        //Metodo para deletar localizacao
        public Location DeleteLocation(int id)
        {
            var location = dbContext.Locations.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(location).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return location;
        }
        //Metodo para retornar localizacao pelo id
        public Location GetLocationById(int id)
        {
            var location = dbContext.Locations.FirstOrDefault(x => x.Id == id);
            return location;
        }

    }
}
