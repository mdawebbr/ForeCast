using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GREM.API.Models;
using System.Web.Http.Cors;
using PlanoEmbarque.API.Models;

namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        Models.ForeCast objEntity = new Models.ForeCast();

        [HttpGet]
        [Route("AllClienteDetails")]
        public IHttpActionResult GetCliente()
        {
            try
            {
                var result = (from tblFC_Cli in objEntity.FC_Cliente
                              join tblFC_MercadoCAP in objEntity.FC_MercadoCAP on tblFC_Cli.MercadoCAPId equals tblFC_MercadoCAP.MercadoCAPId
                              join tblFC_MercadoVF in objEntity.FC_MercadoVF on tblFC_Cli.MercadoVFId equals tblFC_MercadoVF.MercadoVFId
                              join tblFC_LinhaCAP in objEntity.FC_LinhaCAP on tblFC_Cli.LinhaCAPId equals tblFC_LinhaCAP.LinhaCAPId
                              select new
                              {
                                  Id = tblFC_Cli.Id,
                                  Cliente_Id = tblFC_Cli.Cliente_id,
                                  Nome = tblFC_Cli.Nome,
                                  Linha_CAP = tblFC_LinhaCAP.Linha_CAP,
                                  Mercado_CAP = tblFC_MercadoCAP.Mercado_CAP,
                                  Mercado_VF = tblFC_MercadoVF.Mercado_VF,
                                  Cor = tblFC_Cli.Cor,
                                  Modal = tblFC_Cli.Modal,
                                  Pais = tblFC_Cli.Pais,
                                  MercadoCAPId = tblFC_Cli.MercadoCAPId,
                                  MercadoVFId = tblFC_Cli.MercadoVFId,
                                  LinhaCAPId = tblFC_Cli.LinhaCAPId,
                                  Percentual = tblFC_Cli.percentual,
                                  Porcentagem_Protocolo = tblFC_Cli.Porcentagem_Protocolo,
                                  Volume_Protocolo = tblFC_Cli.Volume_Protocolo,
                                  Tonelada_Protocolo = tblFC_Cli.Tonelada_Protocolo

                              }).ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetClienteDetailsById/{ClienteId}")]
        public IHttpActionResult GetClienteById(string ClienteId)
        {
            try
            {
                FC_Cliente objEmp = new FC_Cliente();
                int ID = Convert.ToInt32(ClienteId);
                try
                {
                    objEmp = objEntity.FC_Cliente.Find(ID);
                    if (objEmp == null)
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(objEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("InsertClienteDetails")]
        public IHttpActionResult PostCliente(FC_Cliente data)
        {
            try
            {
                //data.Id = null;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    //data.DateofBirth = data.DateofBirth.HasValue ? data.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    //data.Cliente_id = data.Cliente_id + 1;
                    objEntity.FC_Cliente.Add(data);
                    objEntity.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateClienteDetails")]
        public IHttpActionResult PutFC_Cliente(FC_Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    FC_Cliente objCli = new FC_Cliente();
                    objCli = objEntity.FC_Cliente.Find(cliente.Id);
                    if (objCli != null)
                    {
                        objCli.Id = cliente.Id;
                        objCli.Cliente_id = cliente.Cliente_id;
                        objCli.Nome = cliente.Nome;
                        objCli.Linha_CAP = cliente.Linha_CAP;
                        objCli.Mercado_CAP = cliente.Mercado_CAP;
                        objCli.Mercado_VF = cliente.Mercado_VF;
                        objCli.Cor = cliente.Cor;
                        objCli.Modal = cliente.Modal;
                        objCli.Pais = cliente.Pais;
                        objCli.MercadoCAPId = cliente.MercadoCAPId;
                        objCli.MercadoVFId = cliente.MercadoVFId;
                        objCli.LinhaCAPId = cliente.LinhaCAPId;
                        objCli.percentual = cliente.percentual;
                        objCli.Porcentagem_Protocolo = cliente.Porcentagem_Protocolo;
                        objCli.Volume_Protocolo = cliente.Volume_Protocolo;
                        objCli.Tonelada_Protocolo = cliente.Tonelada_Protocolo;

                        //objEmp.DateofBirth = cliente.DateofBirth.HasValue ? cliente.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    }
                    this.objEntity.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteClienteDetails")]
        public IHttpActionResult DeleteClienteDelete(int id)
        {
            try
            {
                FC_Cliente cliente = objEntity.FC_Cliente.Find(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                objEntity.FC_Cliente.Remove(cliente);
                objEntity.SaveChanges();
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("MercadoCAP")]
        public IQueryable<FC_MercadoCAP> GetMercadoCAP()
        {
            try
            {
                return objEntity.FC_MercadoCAP;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FC_MercadoCAP> MercadoCAPData()
        {
            try
            {
                return objEntity.FC_MercadoCAP.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("MercadoCAP/{MercadoCAPId}/MercadoVF")]
        [HttpGet]
        public List<FC_MercadoVF> MercadoVFData(int MercadoCAPId)
        {
            try
            {
                return objEntity.FC_MercadoVF.Where(s => s.MercadoCAPId == MercadoCAPId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("MercadoVF/{MercadoVFId}/LinhaCAP")]
        [HttpGet]
        public List<FC_LinhaCAP> LinhaCAPData(int MercadoVFId)
        {
            try
            {
                return objEntity.FC_LinhaCAP.Where(s => s.MercadoVFId == MercadoVFId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public IHttpActionResult DeleteRecord(List<FC_Cliente> user)
        {
            string result = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                result = DeleteData(user);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(result);
        }
        private string DeleteData(List<FC_Cliente> users)
        {
            string str = "";
            try
            {
                foreach (var item in users)
                {
                    FC_Cliente objCli = new FC_Cliente();

                    objCli.Cliente_id = item.Cliente_id;
                    objCli.Nome = item.Nome;
                    objCli.Linha_CAP = item.Linha_CAP;
                    objCli.Mercado_CAP = item.Mercado_CAP;
                    objCli.Mercado_VF = item.Mercado_VF;
                    objCli.Cor = item.Cor;
                    objCli.Modal = item.Modal;
                    objCli.Pais = item.Pais;
                    objCli.MercadoCAPId = item.MercadoCAPId;
                    objCli.MercadoVFId = item.MercadoVFId;
                    objCli.LinhaCAPId = item.LinhaCAPId;
                    objCli.percentual = item.percentual;
                    objCli.Porcentagem_Protocolo = item.Porcentagem_Protocolo;
                    objCli.Volume_Protocolo = item.Volume_Protocolo;
                    objCli.Tonelada_Protocolo = item.Tonelada_Protocolo;

                    //objCli.DateofBirth = item.DateofBirth.HasValue ? item.DateofBirth.Value.AddDays(1) : (DateTime?)null;

                    var entry = objEntity.Entry(objCli);

                    if (entry.State == EntityState.Detached) objEntity.FC_Cliente.Attach(objCli);

                    objEntity.FC_Cliente.Remove(objCli);
                }
                int i = objEntity.SaveChanges();
                if (i > 0)
                {
                    str = "Registro foi excluido!";
                }
                else
                {
                    str = "A exclusão dos registros falhou!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }
    }

}
