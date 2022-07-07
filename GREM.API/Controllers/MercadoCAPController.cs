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
    [RoutePrefix("api/Mercadocap")]
    public class MercadoCAPController : ApiController
    {
        //AngulerDBEntities objEntity = new AngulerDBEntities();

        Models.ForeCast objEntity = new Models.ForeCast();

        [HttpGet]
        [Route("AllMercadocapDetails")]
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
                var result = (from tblMercadoCAP in objEntity.FC_MercadoCAP
                              select new
                              {
                                  //LinhaCAPId = tblLinhaCAP.LinhaCAPId,
                                  //Linha_CAP = tblLinhaCAP.Linha_CAP,
                                  //LastName = tblEmp.LastName,
                                  //DateofBirth = tblEmp.DateofBirth,
                                  //EmailId = tblEmp.EmailId,
                                  //Gender = tblEmp.Gender,
                                  MercadoCAPId = tblMercadoCAP.MercadoCAPId,
                                  //MercadoVFId = tblLinhaCAP.MercadoVFId,
                                  //Cityid = tblEmp.Cityid,
                                  //Address = tblEmp.Address,
                                  //Pincode = tblEmp.Pincode,
                                  Mercado_CAP = tblMercadoCAP.Mercado_CAP,
                                  //MercadoVF = tblMercadoVF.Mercado_VF,
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
        [Route("GetMercadocapDetailsById/{mercadocapId}")]
        public IHttpActionResult GetEmaployeeById(string mercadocapId)
        {
            try
            {
                //tblEmployeeMaster objEmp = new tblEmployeeMaster();
                
                FC_MercadoCAP objEmp = new FC_MercadoCAP();

                int ID = Convert.ToInt32(mercadocapId);
                try
                {
                    objEmp = objEntity.FC_MercadoCAP.Find(ID);
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
        [Route("InsertMercadocapDetails")]
        public IHttpActionResult PostEmaployee(FC_MercadoCAP data)
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
                    objEntity.FC_MercadoCAP.Add(data);
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
        [Route("UpdateMercadocapDetails")]
        public IHttpActionResult PutEmaployeeMaster(FC_MercadoCAP employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    FC_MercadoCAP objEmp = new FC_MercadoCAP();
                    objEmp = objEntity.FC_MercadoCAP.Find(employee.MercadoCAPId);
                    if (objEmp != null)
                    {
                        objEmp.Mercado_CAP = employee.Mercado_CAP;
                        //objEmp.LastName = employee.LastName;
                        //objEmp.Address = employee.Address;
                        //objEmp.EmailId = employee.EmailId;
                        //objEmp.DateofBirth = employee.DateofBirth.HasValue ? employee.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                        //objEmp.Gender = employee.Gender;
                        objEmp.MercadoCAPId = employee.MercadoCAPId;
                        //objEmp.MercadoVFId = employee.MercadoVFId;
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
        [Route("DeleteMercadocapDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            try
            {
                FC_MercadoCAP emaployee = objEntity.FC_MercadoCAP.Find(id);
                if (emaployee == null)
                {
                    return NotFound();
                }
                objEntity.FC_MercadoCAP.Remove(emaployee);
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
                //return objEntity.FC_LinhaCAP.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("DeleteRecord")]
        public IHttpActionResult DeleteRecord(List<FC_MercadoCAP> user)
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
        private string DeleteData(List<FC_MercadoCAP> users)
        {
            string str = "";
            try
            {
                foreach (var item in users)
                {
                    FC_MercadoCAP objEmp = new FC_MercadoCAP();
                    objEmp.MercadoCAPId = item.MercadoCAPId;
                    objEmp.Mercado_CAP = item.Mercado_CAP;
                    //objEmp.LastName = item.LastName;
                    //objEmp.Address = item.Address;
                    //objEmp.EmailId = item.EmailId;
                    //objEmp.DateofBirth = item.DateofBirth.HasValue ? item.DateofBirth.Value.AddDays(1) : (DateTime?)null;
                    //objEmp.Gender = item.Gender;
                    //objEmp.MercadoCAPId = item.MercadoCAPId;
                    //objEmp.MercadoVFId = item.MercadoVFId;
                    //objEmp.LinhaCAPId = item.LinhaCAPId;
                    //objEmp.Pincode = item.Pincode;

                    var entry = objEntity.Entry(objEmp);
                    if (entry.State == EntityState.Detached) objEntity.FC_MercadoCAP.Attach(objEmp);
                    
                    objEntity.FC_MercadoCAP.Remove(objEmp);
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
