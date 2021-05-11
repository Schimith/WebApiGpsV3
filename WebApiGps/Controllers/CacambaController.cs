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
    //Contexto /api/cacambas
    [ApiController]
    [Route("api/cacambas")]
    public class CacambaController : ControllerBase
    {
        //Metodo para acesso a interface cacamba
        private readonly ICacambaService cacambaService;
        public CacambaController(ICacambaService cacamba)
        {
            cacambaService = cacamba;
        }
        //Metodo para o contexto raiz /api/cacambas
        [HttpGet]
        [Route("")]
        public IEnumerable<Cacamba> GetCacambas()
        {
            return cacambaService.GetCacambas();
        }
        //Metodo para o contexto /api/cacambas/add
        [HttpPost]
        [Route("add")]
        public Cacamba AddCacamba(Cacamba cacamba)
        {
            return cacambaService.AddCacamba(cacamba);
        }
        //Metodo para o contexto /api/cacambas/edit
        [HttpPut]
        [Route("edit")]
        public Cacamba EditCacamba(Cacamba cacamba)
        {
            return cacambaService.UpdateCacamba(cacamba);
        }
        //Metodo para o contexto /api/cacambas/delete?id=chaveprimaria
        [HttpDelete]
        [Route("delete")]
        public Cacamba DeleteCacamba(int id)
        {
            return cacambaService.DeleteCacamba(id);
        }
        //Metodo para o contexto /api/cacambas/get?id=chaveprimaria
        [HttpGet]
        [Route("get")]
        public Cacamba GetCacambaId(int id)
        {
            return cacambaService.GetCacambaById(id);
        }
    }
}
