using GREM.API.Util;
using GREM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GREM.API.Controllers
{
    [RoutePrefix("api/Parametros")]
    public class ParametrosController : ApiHelper
    {
        private IDALParametros _dalParametros;
        public ParametrosController(IDALParametros dalParametros)
        {
            _dalParametros = dalParametros;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_dalParametros.Get(id));
        }

        [HttpPost]
        [Route("UpdateLimiteCaminhao")]
        public IHttpActionResult UpdateLimiteCaminhao(int valor)
        {
            if (valor < 0)
            {
                return Ok("Erro!", "Não é possível salvar o parâmetro com valor negativo!");
            }
            _dalParametros.Update(new PlanoEmbarque.Entities.Parametros()
            {
                Id = 2,
                Chave = "1",
                Valor = valor.ToString()
            });

            return Ok("Sucesso!", "O limite de caminhões por dia foi salvo com sucesso.");
        }

        [HttpPost]
        [Route("UpdateLimiteNavio")]
        public IHttpActionResult UpdateLimiteNavio(int valor)
        {
            if (valor < 0)
            {
                return Ok("Erro!", "Não é possível salvar o parâmetro com valor negativo!");
            }
            _dalParametros.Update(new PlanoEmbarque.Entities.Parametros()
            {
                Id = 1,
                Chave = "2",
                Valor = valor.ToString()
            });

            return Ok("Sucesso!", "O limite de navios por dia foi salvo com sucesso.");
        }

        [HttpPost]
        [Route("UpdateLimiteTrem")]
        public IHttpActionResult UpdateLimiteTrem(int valor)
        {
            if (valor < 0)
            {
                return Ok("Erro!", "Não é possível salvar o parâmetro com valor negativo!");
            }
            _dalParametros.Update(new PlanoEmbarque.Entities.Parametros()
            {
                Id = 1,
                Chave = "3",
                Valor = valor.ToString()
            });

            return Ok("Sucesso!", "O limite de trens por dia foi salvo com sucesso.");
        }

    }
}
