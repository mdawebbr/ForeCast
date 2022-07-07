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
using static PlanoEmbarque.Entities.Ngmultselect;

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
    [RoutePrefix("api/Ngmultselect")]
    public class NgmultselectController : ApiHelper
    {
        private IDALNgmultselect _dalNgmultselect;
        public NgmultselectController(IDALNgmultselect dalNgmultselect)
        {
            _dalNgmultselect = dalNgmultselect;
        }

        //public ClienteController()
        //{
        //}

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalNgmultselect.GetAll();
            return Ok(item);
        }

        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalNgmultselect.Get(id);
            return Ok(item);
        }


        [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(Ngmultselect pe)
        {
            try
            {
                //if(_dalMercadoCAP.ExistePlanoEmbarqueCliente(pe.Id))
                //{
                //    return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
                //}
                //PlanoEmbarque.Entities.Cliente p = _dalMercadoCAP.Get(pe.Id);
                _dalNgmultselect.Remove(pe);
            }
            catch (Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }


            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }

        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(Ngmultselect pe)
        {
            var listaErros = new List<string>();

            if (pe.Cliente_Id == 0)
            {
                listaErros.Add("O Cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalNgmultselect.Update(pe);

            return Ok("Sucesso!", "O Cliente, Ano, Mes foi alterado com sucesso");

        }

        [HttpPost]
        public IHttpActionResult Post(NgmultselectAdd pe)
        {
            var listaErros = new List<string>();

            if (pe.Cliente_id == null)
            {
                listaErros.Add("O campo Cliente é obrigatório.");
            }
            else
            {
                if (pe.Cliente_id.Count == 0)
                {
                    listaErros.Add("O campo Cliente é obrigatório.");
                }
            }

            //if (pe.transporte_id == 0)
            //    listaErros.Add("O campo Meio de Transporte é obrigatório.");

            //if (pe.Dias == null)
            //{
            //    listaErros.Add("O campo Dias é obrigatório.");
            //}
            //else
            //{
            //    if (pe.Dias.Count == 0)
            //        listaErros.Add("O campo Dias é obrigatório.");
            //}

            if (pe.Meses == null)
            {
                listaErros.Add("O campo Meses é obrigatório.");
            }
            else
            {
                if (pe.Meses.Count == 0)
                    listaErros.Add("O campo Meses é obrigatório.");
            }

            //if (pe.peaAno == 0)
            //    listaErros.Add("O campo PEA/Ano é obrigatório.");

            //if (pe.Valor == 0.0)
            //    listaErros.Add("O campo Valor é obrigatório.");


            if (listaErros.Count > 0)
            {
                return Ok("Erro", string.Join("<br />", listaErros));
            }

            int ano = pe.Ano;
            string Nome = pe.Nome_Cliente;

            var listaErrosAoAdicionar = new List<string>();
            var teveSucessoAoAdicionar = false;

            foreach (var m in pe.Meses)
            {
                //if (m < 7)
                //    ano = pe.Ano; //.peaAno + 1;

                //int qtdDiasMes = System.DateTime.DaysInMonth(ano, m);

                //foreach (var d in pe.Dias)
                //{
                    //if (d <= qtdDiasMes)
                    //{
                        foreach (var cliente in pe.Cliente_id)
                        {
                            PlanoEmbarque.Entities.Ngmultselect p = new PlanoEmbarque.Entities.Ngmultselect();
                            
                            p.Cliente_Id = cliente;
                            p.Nome_Cliente = Nome;
                            //p.Dia = d;
                            //p.MeioTransporte_Id = pe.transporte_id;
                            p.Meses = m;
                            p.Ano = ano;
                            //p.PEA_Ano = pe.peaAno;
                            //p.Valor = pe.Valor;


                            //if (_dalNgmultselect.PassouLimiteDia(p))
                            //{
                            //    DateTime dt = new DateTime(p.Ano, p.Mes, p.Dia);
                            //    listaErrosAoAdicionar.Add($"<i class=\"fa fa-times\" style=\"color: #B22222;\" aria-hidden=\"true\"></i> A data {dt.Date.ToString("dd /MM/yyyy")} atingiu o limite por transporte.");
                            //}
                            //else
                            //{
                                _dalNgmultselect.Add(p);
                                teveSucessoAoAdicionar = true;
                            //}
                        }
                    //}
                //}
            }

            if (listaErrosAoAdicionar.Count > 0 && teveSucessoAoAdicionar == true)
            {
                var mensagemRetorno = "Identificamos os erros abaixo: <br /><br />" + string.Join("<br />", listaErrosAoAdicionar);
                mensagemRetorno = mensagemRetorno + " <br /><br /> " + "<i class=\"fa fa-check\" style=\"color: #228B22;\" aria-hidden=\"true\"></i>  Os demais registros foram cadastrados com sucesso.";
                return Ok("Atenção!", mensagemRetorno);
            }
            else if (listaErrosAoAdicionar.Count > 0 && teveSucessoAoAdicionar == false)
            {
                var mensagemRetorno = "Identificamos os erros abaixo: <br /><br />" + string.Join("<br />", listaErrosAoAdicionar);
                return Ok("Erro!", mensagemRetorno);
            }
            else if (listaErrosAoAdicionar.Count == 0 && teveSucessoAoAdicionar == true)
            {
                return Ok("Sucesso!", "A carga de forecast foi cadastrada com sucesso");
            }

            return Ok("Sucesso!", "A carga de forecast foi cadastrada com sucesso");

        }
    }
}
