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
    [RoutePrefix("api/Mercadovf")]
    public class MercadoVFController : ApiController
    {
        //AngulerDBEntities objEntity = new AngulerDBEntities();

        Models.ForeCast objEntity = new Models.ForeCast();

        [HttpGet]
        [Route("AllMercadovfDetails")]
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
                var result = (from tblMercadoVF in objEntity.FC_MercadoVF
                              join tblMercadoCAP in objEntity.FC_MercadoCAP on tblMercadoVF.MercadoCAPId equals tblMercadoCAP.MercadoCAPId
                              select new
                              {
                                  //LinhaCAPId = tblLinhaCAP.LinhaCAPId,
                                  //Linha_CAP = tblLinhaCAP.Linha_CAP,
                                  //LastName = tblEmp.LastName,
                                  //DateofBirth = tblEmp.DateofBirth,
                                  //EmailId = tblEmp.EmailId,
                                  //Gender = tblEmp.Gender,
                                  MercadoCAPId = tblMercadoVF.MercadoCAPId,
                                  MercadoVFId = tblMercadoVF.MercadoVFId,
                                  //Cityid = tblEmp.Cityid,
                                  //Address = tblEmp.Address,
                                  //Pincode = tblEmp.Pincode,
                                  Mercado_CAP = tblMercadoCAP.Mercado_CAP,
                                  Mercado_VF = tblMercadoVF.Mercado_VF,
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
        [Route("GetMercadovfDetailsById/{mercadovfId}")]
        public IHttpActionResult GetEmaployeeById(string mercadovfId)
        {
            try
            {
                //tblEmployeeMaster objEmp = new tblEmployeeMaster();
                
                FC_MercadoVF objEmp = new FC_MercadoVF();

                int ID = Convert.ToInt32(mercadovfId);
                try
                {
                    objEmp = objEntity.FC_MercadoVF.Find(ID);
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
        [Route("InsertMercadovfDetails")]
        public IHttpActionResult PostEmaployee(FC_MercadoVF data)
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
                    objEntity.FC_MercadoVF.Add(data);
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
        [Route("UpdateMercadovfDetails")]
        public IHttpActionResult PutEmaployeeMaster(FC_MercadoVF employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    FC_MercadoVF objEmp = new FC_MercadoVF();
                    objEmp = objEntity.FC_MercadoVF.Find(employee.MercadoVFId);
                    if (objEmp != null)
                    {
                        objEmp.Mercado_VF = employee.Mercado_VF;
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
        [Route("DeleteMercadovfDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            try
            {
                FC_MercadoVF emaployee = objEntity.FC_MercadoVF.Find(id);
                if (emaployee == null)
                {
                    return NotFound();
                }
                objEntity.FC_MercadoVF.Remove(emaployee);
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

        public List<FC_MercadoVF> CountryData()
        {
            try
            {
                return objEntity.FC_MercadoVF.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("MercadoVF/{MercadoCAPId}/MercadoVF")]
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
        public IHttpActionResult DeleteRecord(List<FC_MercadoVF> user)
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
        private string DeleteData(List<FC_MercadoVF> users)
        {
            string str = "";
            try
            {
                foreach (var item in users)
                {
                    FC_MercadoVF objEmp = new FC_MercadoVF();
                    objEmp.MercadoCAPId = item.MercadoCAPId;
                    objEmp.Mercado_VF = item.Mercado_VF;
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
                    if (entry.State == EntityState.Detached) objEntity.FC_MercadoVF.Attach(objEmp);
                    
                    objEntity.FC_MercadoVF.Remove(objEmp);
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
