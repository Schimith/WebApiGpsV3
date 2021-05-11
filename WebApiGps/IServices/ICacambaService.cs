using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.Models;

namespace WebApiGps.IServices
{
    interface ICacambaService
    {
        //Retorna lista de caçambas
        IEnumerable<Cacamba> GetCacamba();
        //Retorna caçamba pelo ID
        Cacamba GetCacambaById(int id);
        //Adiciona nova caçamba
        Cacamba AddCacamba(Cacamba cacamba);
        //Atualiza caçamba
        Cacamba UpdateCacamba(Cacamba cacamba);
        //Deleta caçamba
        Cacamba DeleteCacamba(int id);
    }
}
