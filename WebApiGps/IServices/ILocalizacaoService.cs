using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGps.Models;

namespace WebApiGps.IServices
{
    interface ILocalizacaoService
    {
        //Retorna lista de localizações
        IEnumerable<Localizacao> GetLocalizacao();
        //Retorna caçamba pelo ID
        Localizacao GetLocalizacaoById(int id);
        //Adiciona nova localizacao
        Localizacao AddLocalizacao(Localizacao localizacao);
        //Atualiza caçamba
        Localizacao UpdateLocalizacao(Localizacao localizacao);
        //Deleta localizacao
        Localizacao DeleteLocalizacao(int id);
    }
}
