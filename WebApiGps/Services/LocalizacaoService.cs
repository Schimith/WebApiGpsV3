using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.IServices;
using WebApiGps.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiGps.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        //Metodo para acesso ao sgbd
        EMPRESAContext dbContext;
        public LocalizacaoService(EMPRESAContext _db)
        {
            dbContext = _db;
        }
        //Metodo para retornar as localizações
        public IEnumerable<Localizacao> GetLocalizacaos()
        {
            var localizacao = dbContext.Localizacaos.ToList();
            return localizacao;
        }
        //Metodo para adicionar nova localizacao
        public Localizacao AddLocalizacao(Localizacao localizacao)
        {
            if (localizacao != null)
            {
                dbContext.Localizacaos.Add(localizacao);
                dbContext.SaveChanges();
                return localizacao;
            }
            return null;
        }
        //Metodo para atualizar localizacao
        public Localizacao UpdateLocalizacao(Localizacao localizacao)
        {
            dbContext.Entry(localizacao).State = EntityState.Modified;
            dbContext.SaveChanges();
            return localizacao;
        }
        //Metodo para deletar localizacao
        public Localizacao DeleteLocalizacao(int id)
        {
            var localizacao = dbContext.Localizacaos.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(localizacao).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return localizacao;
        }
        //Metodo para retornar localizacao pelo id
        public Localizacao GetLocalizacaoById(int id)
        {
            var localizacao = dbContext.Localizacaos.FirstOrDefault(x => x.Id == id);
            return localizacao;
        }
    }
}
