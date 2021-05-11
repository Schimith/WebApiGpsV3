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
    //Contexto /api/localizacao
    [ApiController]
    [Route("api/localizacao")]
    public class LocalizacaoController : ControllerBase
    {
        //Metodo para acesso a interface localizacao
        private readonly ILocalizacaoService localizacaoService;
        public LocalizacaoController(ILocalizacaoService localizacao)
        {
            localizacaoService = localizacao;
        }
        //Metodo para o contexto raiz /api/localizacao
        [HttpGet]
        [Route("")]
        public IEnumerable<Localizacao> GetLocalizacaos()
        {
            return localizacaoService.GetLocalizacaos();
        }
        //Metodo para o contexto /api/localizacao/add
        [HttpPost]
        [Route("add")]
        public Localizacao AddLocalizacao(Localizacao localizacao)
        {
            return localizacaoService.AddLocalizacao(localizacao);
        }
        //Metodo para o contexto /api/localizacao/edit
        [HttpPut]
        [Route("edit")]
        public Localizacao EditLocalizacao(Localizacao localizacao)
        {
            return localizacaoService.UpdateLocalizacao(localizacao);
        }
        //Metodo para o contexto /api/localizacao/delete?id=chaveprimaria
        [HttpDelete]
        [Route("delete")]
        public Localizacao DeleteLocalizacao(int id)
        {
            return localizacaoService.DeleteLocalizacao(id);
        }
        //Metodo para o contexto /api/localizacao/get?id=chaveprimaria
        [HttpGet]
        [Route("get")]
        public Localizacao GetLocalizacaoId(int id)
        {
            return localizacaoService.GetLocalizacaoById(id);
        }
    }
}
