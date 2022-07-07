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
    [RoutePrefix("api/Cliente1")]
    public class ClienteController1: ApiHelper
    {
        private IDALCliente _dalCliente;
        public ClienteController1(IDALCliente dalCliente)
        {
            _dalCliente = dalCliente;
        }

        //public ClienteController1()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalCliente.GetAll();
            return Ok(item);
        }
        
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalCliente.Get(id);
            return Ok(item);
        }


       [HttpGet]
        [Route("GetAllMeioTransporte")]
        public IHttpActionResult GetAllMeioTransporte()
        {
            var item = _dalCliente.GetAllMeioTransporte();
            return Ok(item);
        }

        [HttpPost]
        [Route("Remover")]
        
        public IHttpActionResult Remover(Cliente pe)
        {
            try
            {
                if (_dalCliente.ExistePlanoEmbarqueCliente(pe.Cliente_id))
                {
                    return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
                }
                PlanoEmbarque.Entities.Cliente p = _dalCliente.Get(pe.Cliente_id);
                _dalCliente.Remove(pe);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }

            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        public IHttpActionResult Post(Cliente cliente)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(cliente.Nome))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalCliente.Add(cliente);

            return Ok("Sucesso!", "O cliente foi cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(Cliente pe)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pe.Nome))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalCliente.Update(pe);

            return Ok("Sucesso!", "O cliente foi alterado com sucesso");

        }
    }
}
