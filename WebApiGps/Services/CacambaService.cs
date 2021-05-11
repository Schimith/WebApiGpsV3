using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.IServices;
using WebApiGps.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiGps.Services
{
    public class CacambaService : ICacambaService
    {
        //Metodo para acesso ao sgbd
        EMPRESAContext dbContext;
        public CacambaService(EMPRESAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar as caçambas
        public IEnumerable<Cacamba> GetCacambas()
        {
            var cacamba = dbContext.Cacambas.ToList();
            return cacamba;
        }
        //Metodo para adicionar nova caçamba
        public Cacamba AddCacamba(Cacamba cacamba)
        {
            if (cacamba != null)
            {
                dbContext.Cacambas.Add(cacamba);
                dbContext.SaveChanges();
                return cacamba;
            }
            return null;
        }
        //Metodo para atualizar caçamba
        public Cacamba UpdateCacamba(Cacamba cacamba)
        {
            dbContext.Entry(cacamba).State = EntityState.Modified;
            dbContext.SaveChanges();
            return cacamba;
        }
        //Metodo para deletar caçamba
        public Cacamba DeleteCacamba(int id)
        {
            var cacamba = dbContext.Cacambas.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(cacamba).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return cacamba;
        }
        //Metodo para retornar caçamba pelo id
        public Cacamba GetCacambaById(int id)
        {
            var cacamba = dbContext.Cacambas.FirstOrDefault(x => x.Id == id);
            return cacamba;
        }
    }
}
