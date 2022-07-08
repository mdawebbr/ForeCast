using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GREM.API.Models;
using System.Web.Http.Cors;
using PlanoEmbarque.API.Models;

namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Cadastrousuario")]
    public class CadastroUsuarioController : ApiController
    {
        //AngulerDBEntities objEntity = new AngulerDBEntities();

        Models.ForeCast objEntity = new Models.ForeCast();

        [HttpGet]
        [Route("AllCadastrousuarioDetails")]
        public IHttpActionResult GetEmaployee()
        {
            //AngulerDBEntities para ForeCast 
            //tblEmployeeMaster para FC_CadastroUsuario
            //CountryMasters    para FC_MercadoCAP
            //StateMasters      para FC_MercadoVF
            //CityMasters       para FC_CadastroUIsuario

            //tblEmp            para tblCadastroUsuario
            //tblCountry        para tblMercadoCAP
            //tblState          para tblMercadoVF
            //tblCity           para tblCadastroUsuario

            //Country           para MercadoCAP
            //State             para MercadoVF
            //City              para CadastroUsuario

            //EmpId             para CadastroUsuarioId
            //FirstName         para Linha_CAP

            //CoutryId          para MercadoCAPId
            //CountryName       para Mercado_CAP

            //StateId           para MercadoVFId
            //StateName         para Mercado_VF

            try
            {
                var result = (from tblCadastroUsuario in objEntity.FC_CadastroUsuario
                              join tblMercadoCAP in objEntity.FC_MercadoCAP on tblCadastroUsuario.MercadoCAPId equals tblMercadoCAP.MercadoCAPId
                              join tblMercadoVF in objEntity.FC_MercadoVF on tblCadastroUsuario.MercadoVFId equals tblMercadoVF.MercadoVFId
                              //join tblCity in objEntity.CityMasters on tblEmp.Cityid equals tblCity.Cityid
                              select new
                              {
                                  CadastroUsuarioId = tblCadastroUsuario.CadastroUsuarioId,
                                  Linha_CAP = tblCadastroUsuario.Linha_CAP,
                                  //LastName = tblEmp.LastName,
                                  //DateofBirth = tblEmp.DateofBirth,
                                  //EmailId = tblEmp.EmailId,
                                  //Gender = tblEmp.Gender,
                                  MercadoCAPId = tblCadastroUsuario.MercadoCAPId,
                                  MercadoVFId = tblCadastroUsuario.MercadoVFId,
                                  //Cityid = tblEmp.Cityid,
                                  //Address = tblEmp.Address,
                                  //Pincode = tblEmp.Pincode,
                                  MercadoCAP = tblMercadoCAP.Mercado_CAP,
                                  MercadoVF = tblMercadoVF.Mercado_VF,
                                  //City = tblCity.CityName
                              }).ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetCadastrousuarioDetailsById/{linhacapId}")]
        public IHttpActionResult GetEmaployeeById(string linhacapId)
        {
            try
            {
                //tblEmployeeMaster objEmp = new tblEmployeeMaster();
                
                FC_CadastroUsuario objEmp = new FC_CadastroUsuario();

                int ID = Convert.ToInt32(linhacapId);
                try
                {
                    objEmp = objEntity.FC_CadastroUsuario.Find(ID);
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
        [Route("InsertCadastrousuarioDetails")]
        public IHttpActionResult PostEmaployee(FC_CadastroUsuario data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    //data.DateofBirth = data.DateofBirth.HasValue ? data.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    objEntity.FC_CadastroUsuario.Add(data);
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
        [Route("UpdateCadastrousuarioDetails")]
        public IHttpActionResult PutEmaployeeMaster(FC_CadastroUsuario employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    FC_CadastroUsuario objEmp = new FC_CadastroUsuario();
                    objEmp = objEntity.FC_CadastroUsuario.Find(employee.CadastroUsuarioId);
                    if (objEmp != null)
                    {
                        objEmp.Linha_CAP = employee.Linha_CAP;
                        //objEmp.LastName = employee.LastName;
                        //objEmp.Address = employee.Address;
                        //objEmp.EmailId = employee.EmailId;
                        //objEmp.DateofBirth = employee.DateofBirth.HasValue ? employee.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                        //objEmp.Gender = employee.Gender;
                        objEmp.MercadoCAPId = employee.MercadoCAPId;
                        objEmp.MercadoVFId = employee.MercadoVFId;
                        //objEmp.Cityid = employee.Cityid;
                        //objEmp.Pincode = employee.Pincode;
                    }
                    this.objEntity.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteCadastrousuarioDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            try
            {
                FC_CadastroUsuario emaployee = objEntity.FC_CadastroUsuario.Find(id);
                if (emaployee == null)
                {
                    return NotFound();
                }
                objEntity.FC_CadastroUsuario.Remove(emaployee);
                objEntity.SaveChanges();
                return Ok(emaployee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("MercadoCAP")]
        public IQueryable<FC_MercadoCAP> GetCountry()
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
        public List<FC_MercadoCAP> CountryData()
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
        public List<FC_MercadoVF> StateData(int MercadoCAPID)
        {
            try
            {
                return objEntity.FC_MercadoVF.Where(s => s.MercadoCAPId == MercadoCAPID).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("MercadoVF/{MercadoVFId}/CadastroUsuario")]
        [HttpGet]
        public List<FC_CadastroUsuario> CityData(int MercadoVFId)
        {
            try
            {
                return objEntity.FC_CadastroUsuario.Where(s => s.MercadoVFId == MercadoVFId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public IHttpActionResult DeleteRecord(List<FC_CadastroUsuario> user)
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
        private string DeleteData(List<FC_CadastroUsuario> users)
        {
            string str = "";
            try
            {
                foreach (var item in users)
                {
                    FC_CadastroUsuario objEmp = new FC_CadastroUsuario();
                    objEmp.CadastroUsuarioId = item.CadastroUsuarioId;
                    objEmp.Linha_CAP = item.Linha_CAP;
                    //objEmp.LastName = item.LastName;
                    //objEmp.Address = item.Address;
                    //objEmp.EmailId = item.EmailId;
                    //objEmp.DateofBirth = item.DateofBirth.HasValue ? item.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    //objEmp.Gender = item.Gender;
                    objEmp.MercadoCAPId = item.MercadoCAPId;
                    objEmp.MercadoVFId = item.MercadoVFId;
                    //objEmp.CadastroUsuarioId = item.CadastroUsuarioId;
                    //objEmp.Pincode = item.Pincode;

                    var entry = objEntity.Entry(objEmp);
                    if (entry.State == EntityState.Detached) objEntity.FC_CadastroUsuario.Attach(objEmp);
                    
                    objEntity.FC_CadastroUsuario.Remove(objEmp);
                }
                int i = objEntity.SaveChanges();
                if (i > 0)
                {
                    str = "Registro Deletado";
                }
                else
                {
                    str = "Falha na Exclusão";
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
