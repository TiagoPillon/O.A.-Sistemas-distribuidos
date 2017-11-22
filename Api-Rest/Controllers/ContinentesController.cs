using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWebAPI.Services.Models;

namespace TesteWebAPI.Services.Controllers
{
    public class ContinentesController : ApiController
    {
        public IEnumerable<BalancoComercialPorContinente> Get(int ano)
        {
            if (ano == 2012)
                return SimulacaoBalanco2012.ObterBalancoContinentes();
            else if (ano == 2013)
                return SimulacaoBalanco2013.ObterBalancoContinentes();
            else
                throw new ArgumentException("O ano-base informado é inválido.");
        }
    }
}