using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.Models;

namespace WebApiGps.IServices
{
    public interface ILocationService
    {
        //Retorna lista de localizações
        IEnumerable<Location> GetLocations();
        //Retorna caçamba pelo ID
        Location GetLocationById(int id);
        //Adiciona nova localizacao
        Location AddLocation(Location location);
        //Atualiza localizacao
        Location UpdateLocation(Location location);
        //Deleta localizacao
        Location DeleteLocation(int id);
    }
}
