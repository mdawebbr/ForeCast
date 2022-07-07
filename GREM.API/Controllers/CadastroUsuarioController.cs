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
    [RoutePrefix("api/Linhacap")]
    public class LinhaCAPController : ApiController
    {
        //AngulerDBEntities objEntity = new AngulerDBEntities();

        Models.ForeCast objEntity = new Models.ForeCast();

        [HttpGet]
        [Route("AllLinhacapDetails")]
        public IHttpActionResult GetEmaployee()
        {
            //AngulerDBEntities para ForeCast 
            //tblEmployeeMaster para FC_LinhaCAP
            //CountryMasters    para FC_MercadoCAP
            //StateMasters      para FC_MercadoVF
            //CityMasters       para FC_LinhaCAP

            //tblEmp            para tblLinhaCAP
            //tblCountry        para tblMercadoCAP
            //tblState          para tblMercadoVF
            //tblCity           para tblLinhaCAP

            //Country           para MercadoCAP
            //State             para MercadoVF
            //City              para LinhaCAP

            //EmpId             para LinhaCAPId
            //FirstName         para Linha_CAP

            //CoutryId          para MercadoCAPId
            //CountryName       para Mercado_CAP

            //StateId           para MercadoVFId
            //StateName         para Mercado_VF

            try
            {
                var result = (from tblLinhaCAP in objEntity.FC_LinhaCAP
                              join tblMercadoCAP in objEntity.FC_MercadoCAP on tblLinhaCAP.MercadoCAPId equals tblMercadoCAP.MercadoCAPId
                              join tblMercadoVF in objEntity.FC_MercadoVF on tblLinhaCAP.MercadoVFId equals tblMercadoVF.MercadoVFId
                              //join tblCity in objEntity.CityMasters on tblEmp.Cityid equals tblCity.Cityid
                              select new
                              {
                                  LinhaCAPId = tblLinhaCAP.LinhaCAPId,
                                  Linha_CAP = tblLinhaCAP.Linha_CAP,
                                  //LastName = tblEmp.LastName,
                                  //DateofBirth = tblEmp.DateofBirth,
                                  //EmailId = tblEmp.EmailId,
                                  //Gender = tblEmp.Gender,
                                  MercadoCAPId = tblLinhaCAP.MercadoCAPId,
                                  MercadoVFId = tblLinhaCAP.MercadoVFId,
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
        [Route("GetLinhacapDetailsById/{linhacapId}")]
        public IHttpActionResult GetEmaployeeById(string linhacapId)
        {
            try
            {
                //tblEmployeeMaster objEmp = new tblEmployeeMaster();
                
                FC_LinhaCAP objEmp = new FC_LinhaCAP();

                int ID = Convert.ToInt32(linhacapId);
                try
                {
                    objEmp = objEntity.FC_LinhaCAP.Find(ID);
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
        [Route("InsertLinhacapDetails")]
        public IHttpActionResult PostEmaployee(FC_LinhaCAP data)
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
                    objEntity.FC_LinhaCAP.Add(data);
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
        [Route("UpdateLinhacapDetails")]
        public IHttpActionResult PutEmaployeeMaster(FC_LinhaCAP employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    FC_LinhaCAP objEmp = new FC_LinhaCAP();
                    objEmp = objEntity.FC_LinhaCAP.Find(employee.LinhaCAPId);
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
        [Route("DeleteLinhacapDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            try
            {
                FC_LinhaCAP emaployee = objEntity.FC_LinhaCAP.Find(id);
                if (emaployee == null)
                {
                    return NotFound();
                }
                objEntity.FC_LinhaCAP.Remove(emaployee);
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

        [Route("MercadoVF/{MercadoVFId}/LinhaCAP")]
        [HttpGet]
        public List<FC_LinhaCAP> CityData(int MercadoVFId)
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
        public IHttpActionResult DeleteRecord(List<FC_LinhaCAP> user)
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
        private string DeleteData(List<FC_LinhaCAP> users)
        {
            string str = "";
            try
            {
                foreach (var item in users)
                {
                    FC_LinhaCAP objEmp = new FC_LinhaCAP();
                    objEmp.LinhaCAPId = item.LinhaCAPId;
                    objEmp.Linha_CAP = item.Linha_CAP;
                    //objEmp.LastName = item.LastName;
                    //objEmp.Address = item.Address;
                    //objEmp.EmailId = item.EmailId;
                    //objEmp.DateofBirth = item.DateofBirth.HasValue ? item.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    //objEmp.Gender = item.Gender;
                    objEmp.MercadoCAPId = item.MercadoCAPId;
                    objEmp.MercadoVFId = item.MercadoVFId;
                    //objEmp.LinhaCAPId = item.LinhaCAPId;
                    //objEmp.Pincode = item.Pincode;

                    var entry = objEntity.Entry(objEmp);
                    if (entry.State == EntityState.Detached) objEntity.FC_LinhaCAP.Attach(objEmp);
                    
                    objEntity.FC_LinhaCAP.Remove(objEmp);
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
