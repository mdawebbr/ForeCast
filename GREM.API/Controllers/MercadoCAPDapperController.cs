using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using GREM.DAL.Interfaces;
using GREM.API.Util;
using PlanoEmbarque.Entities;
using System.IO;
using GREM.DAL;
using GREM.API.Filters;
using System.Globalization;

//==============================================================
//Inclusões
// 1 - PlanoEmbarque.API/Controller - API
// 2 - PlanoEmbarque.Entities - Estrutura de Classes
// 3 - GREM.DAL - Queris SQL
// 4 - GREM.Dal/Interface - Intercace da API
// 5 - PlanoEmbarque.API/Container - Registro de Depenmdencias
//==============================================================


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/MercadoCAP")]
    public class MercadoCAPDapperController : ApiHelper
    {
        private IDALMercadoCAP _dalMercadoCAP;
        public MercadoCAPDapperController(IDALMercadoCAP dalMercadoCAP)
        {
            _dalMercadoCAP = dalMercadoCAP;
        }

        //public MercadoCAPDapperController()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalMercadoCAP.GetAll();
            return Ok(item);
        }
        
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalMercadoCAP.Get(id);
            return Ok(item);
        }


         [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(MercadoCAP pe)
        {
            try
            {
                //if(_dalMercadoCAP.ExistePlanoEmbarqueCliente(pe.Id))
                //{
                //    return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
                //}
                //PlanoEmbarque.Entities.Cliente p = _dalMercadoCAP.Get(pe.Id);
                _dalMercadoCAP.Remove(pe);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }


            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        public IHttpActionResult Post(MercadoCAP Mercadocap)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(Mercadocap.Mercado_CAP))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalMercadoCAP.Add(Mercadocap);

            return Ok("Sucesso!", "O cliente foi cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(MercadoCAP pe)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pe.Mercado_CAP))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalMercadoCAP.Update(pe);

            return Ok("Sucesso!", "O cliente foi alterado com sucesso");

        }
    }
}
