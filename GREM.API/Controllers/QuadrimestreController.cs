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

namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Quadrimestre")]
    public class QuadrimestreController : ApiHelper
    {
        private IDALQuadrimestre _dalQuadrimestre;
        public QuadrimestreController(IDALQuadrimestre dalQuadrimestre)
        {
            _dalQuadrimestre = dalQuadrimestre;
        }

        //public ClienteController()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalQuadrimestre.GetAll();
            return Ok(item);
        }

        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalQuadrimestre.Get(id);
            return Ok(item);
        }


       [HttpGet]
        [Route("GetAllMeioTransporte")]
        public IHttpActionResult GetAllMeioTransporte()
        {
            var item = _dalQuadrimestre.GetAllMeioTransporte();
            return Ok(item);
        }

        [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(Quadrimestre qm)
        {
            try
            {
                if(_dalQuadrimestre.ExistePlanoEmbarqueCliente(qm.Id))
                {
                    return Ok("Erro!", "Este trimestre não pode ser removido porque possui registros de Carga de Forecast.");
                }
                PlanoEmbarque.Entities.Quadrimestre p = _dalQuadrimestre.Get(qm.Id);
                _dalQuadrimestre.Remove(p);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }


            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        public IHttpActionResult Post(Quadrimestre qm)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(qm.Chave))
            {
                listaErros.Add("O campo Chave é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalQuadrimestre.Add(qm);

            return Ok("Sucesso!", "O trimestre foi cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(Quadrimestre qm)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(qm.Chave))
            {
                listaErros.Add("O campo Chave é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalQuadrimestre.Update(qm);

            return Ok("Sucesso!", "O trimestre foi alterado com sucesso");

        }
    }
}
