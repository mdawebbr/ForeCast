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
//RegisterDependency.Container.RegisterDependency.cs
//GREM.DAL - Queris SQL
//GREM.Dal/Interface - Intercace da API
//==================================


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/MercadoVF")]
    public class MercadoVFDapperController : ApiHelper
    {
        private IDALMercadoVF _dalMercadoVF;
        public MercadoVFDapperController(IDALMercadoVF dalMercadoVF)
        {
            _dalMercadoVF = dalMercadoVF;
        }

        //public ClienteController()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalMercadoVF.GetAll();
            return Ok(item);
        }
        
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalMercadoVF.Get(id);
            return Ok(item);
        }


         [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(MercadoVF pe)
        {
            try
            {
                //if(_dalLinhaCAP.ExistePlanoEmbarqueCliente(pe.Id))
                //{
                //    return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
                //}
                //PlanoEmbarque.Entities.Cliente p = _dalLinhaCAP.Get(pe.Id);
                _dalMercadoVF.Remove(pe);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }


            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        public IHttpActionResult Post(MercadoVF mercadovf)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(mercadovf.Mercado_VF))
            {
                listaErros.Add("O campo Nome é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalMercadoVF.Add(mercadovf);

            return Ok("Sucesso!", "Cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(MercadoVF pe)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pe.Mercado_VF))
            {
                listaErros.Add("O campo Nome é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalMercadoVF.Update(pe);

            return Ok("Sucesso!", "Alterado com sucesso");

        }
    }
}
