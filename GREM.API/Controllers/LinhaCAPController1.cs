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

//==================================
//Inclusões
//PlanoEmbarque.Entities - Estrutura de Classes
//PlanoEmbarque.API/Controller - API
//GREM.DAL - Queris SQL
//GREM.Dal/Interface - Intercace da API
//==================================


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/LinhaCAP")]
    public class LinhaCAPController : ApiHelper
    {
        private IDALLinhaCAP _dalLinhaCAP;
        public LinhaCAPController(IDALLinhaCAP dalLinhaCAP)
        {
            _dalLinhaCAP = dalLinhaCAP;
        }

        //public ClienteController()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalLinhaCAP.GetAll();
            return Ok(item);
        }
        
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalLinhaCAP.Get(id);
            return Ok(item);
        }


         [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(LinhaCAP pe)
        {
            try
            {
                //if(_dalLinhaCAP.ExistePlanoEmbarqueCliente(pe.Id))
                //{
                //    return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
                //}
                //PlanoEmbarque.Entities.Cliente p = _dalLinhaCAP.Get(pe.Id);
                _dalLinhaCAP.Remove(pe);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }


            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        public IHttpActionResult Post(LinhaCAP linhacap)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(linhacap.Linha_CAP))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalLinhaCAP.Add(linhacap);

            return Ok("Sucesso!", "O cliente foi cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(LinhaCAP pe)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pe.Linha_CAP))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalLinhaCAP.Update(pe);

            return Ok("Sucesso!", "O cliente foi alterado com sucesso");

        }
    }
}
