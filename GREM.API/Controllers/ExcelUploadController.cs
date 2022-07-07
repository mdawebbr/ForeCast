using ExcelDataReader;
using GREM.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PlanoEmbarque.API.Models;


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Excel")]
    public class ExcelUploadController : ApiController
    {
        [Route("UploadPlanoEmbarque")]
        [HttpPost]
        public string ExcelUpload()
        {
            try
            {
                string message = "";
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;

                HttpPostedFile Inputfile = null;

                Inputfile = httpRequest.Files[0];

                using (Models.ForeCast objEntity = new Models.ForeCast())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        HttpPostedFile file = httpRequest.Files[0];
                        Stream stream = file.InputStream;

                        IExcelDataReader reader = null;

                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        else
                        {
                            message = "Esse tipo de arquivo não é suportado";
                        }

                        DataSet excelRecords = reader.AsDataSet();
                        reader.Close();

                        var finalRecords = excelRecords.Tables[0];

                        for (int i = 0; i < finalRecords.Rows.Count; i++)
                        {
                            FC_PlanoEmbarque objUser = new FC_PlanoEmbarque();

                            objUser.Dia = Convert.ToInt32(finalRecords.Rows[i][0]);
                            objUser.Mes = Convert.ToInt32(finalRecords.Rows[i][1]);
                            objUser.Ano = Convert.ToInt32(finalRecords.Rows[i][2]);
                            objUser.Valor = Convert.ToInt32(finalRecords.Rows[i][3]);
                            objUser.PEA_Ano = Convert.ToInt32(finalRecords.Rows[i][4]);
                            objUser.MeioTransporte_Id = Convert.ToInt32(finalRecords.Rows[i][5]);
                            objUser.Cliente_Id = Convert.ToInt32(finalRecords.Rows[i][6]);
                            objUser.Pacote = finalRecords.Rows[i][7].ToString();
                            //objUser.DataEmbarque = Convert.ToDateTime(finalRecords.Rows[i][8]);
                            //objUser.Quadrimestre = finalRecords.Rows[i][9].ToString();
                            //objUser.Contador = Convert.ToInt32(finalRecords.Rows[i][10]);

                            objEntity.FC_PlanoEmbarque.Add(objUser);

                        }

                        int output = objEntity.SaveChanges();

                        if (output > 0)
                        {
                            message = "Arquivo Excel processado com sucesso!";
                        }
                        else
                        {
                            message = "Arquivo Excel não foi carregado!";
                        }

                    }

                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                return message;
            }

            catch (Exception)
            {
                throw;
            }
        }

        [Route("PlanoEmbarqueDetails")]
        [HttpGet]
        public List<FC_PlanoEmbarque> BindPlanoEmbarque()
        {

            //FK_FC_MeioTransporte eliminar do codigo!!!

            List<FC_PlanoEmbarque> lstUser = new List<FC_PlanoEmbarque>();
            using (Models.ForeCast objEntity = new Models.ForeCast())
            {
                lstUser = objEntity.FC_PlanoEmbarque.ToList();
            }
            return lstUser;
        }

        [Route("UploadBreakDown")]
        [HttpPost]
        public string BreakDownUpload()
        {
            try
            {
                string message = "";
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;

                HttpPostedFile Inputfile = null;

                Inputfile = httpRequest.Files[0];

                using (Models.ForeCast objEntity = new Models.ForeCast())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        HttpPostedFile file = httpRequest.Files[0];
                        Stream stream = file.InputStream;

                        IExcelDataReader reader = null;

                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        else
                        {
                            message = "Esse tipo de arquivo não é suportado";
                        }

                        DataSet excelRecords = reader.AsDataSet();
                        reader.Close();

                        var finalRecords = excelRecords.Tables[0];

                        for (int i = 0; i < finalRecords.Rows.Count; i++)
                        {
                            FC_BreakDown objUser = new FC_BreakDown();

                            objUser.Grau = finalRecords.Rows[i][0].ToString();
                            objUser.Espessura = Convert.ToDouble(finalRecords.Rows[i][1]);
                            objUser.Largura = Convert.ToDouble(finalRecords.Rows[i][2]);
                            objUser.Comprimento = Convert.ToDouble(finalRecords.Rows[i][3]);
                            objUser.Volumen = Convert.ToDouble(finalRecords.Rows[i][4]);
                            objUser.PACOTE = finalRecords.Rows[i][5].ToString();
                            objUser.DATA = Convert.ToDateTime(finalRecords.Rows[i][6]);
                            objUser.F8 = finalRecords.Rows[i][7].ToString();

                            objEntity.FC_BreakDown.Add(objUser);

                        }

                        int output = objEntity.SaveChanges();

                        if (output > 0)
                        {
                            message = "Arquivo Excel processado com sucesso!";
                        }
                        else
                        {
                            message = "Arquivo Excel não foi carregado!";
                        }

                    }

                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                return message;
            }

            catch (Exception)
            {
                throw;
            }
        }

        [Route("BreakDownDetails")]
        [HttpGet]
        public List<FC_BreakDown> BindBreakDown()
        {

            //FK_FC_MeioTransporte eliminar do codigo!!!

            List<FC_BreakDown> lstUser = new List<FC_BreakDown>();
            using (Models.ForeCast objEntity = new Models.ForeCast())
            {
                lstUser = objEntity.FC_BreakDown.ToList();
            }
            return lstUser;
        }

        [Route("UploadPlanoSemanal")]
        [HttpPost]
        public string PlanoSemanalUpload()
        {
            try
            {
                string message = "";
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;

                HttpPostedFile Inputfile = null;

                Inputfile = httpRequest.Files[0];

                using (Models.ForeCast objEntity = new Models.ForeCast())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        HttpPostedFile file = httpRequest.Files[0];
                        Stream stream = file.InputStream;

                        IExcelDataReader reader = null;

                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        else
                        {
                            message = "Esse tipo de arquivo não é suportado";
                        }

                        DataSet excelRecords = reader.AsDataSet();
                        reader.Close();

                        var finalRecords = excelRecords.Tables[0];

                        for (int i = 0; i < finalRecords.Rows.Count; i++)
                        {
                            FC_PlanoSemanal objUser = new FC_PlanoSemanal();

                            objUser.Grau = finalRecords.Rows[i][0].ToString();
                            objUser.Espessura = Convert.ToDouble(finalRecords.Rows[i][1]);
                            objUser.Volume = Convert.ToDouble(finalRecords.Rows[i][2]);
                            objUser.PACOTE = finalRecords.Rows[i][3].ToString();
                            objUser.DATA = Convert.ToDateTime(finalRecords.Rows[i][4]);

                            objEntity.FC_PlanoSemanal.Add(objUser);

                        }

                        int output = objEntity.SaveChanges();

                        if (output > 0)
                        {
                            message = "Arquivo Excel processado com sucesso!";
                        }
                        else
                        {
                            message = "Arquivo Excel não foi carregado!";
                        }

                    }

                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                return message;
            }

            catch (Exception)
            {
                throw;
            }
        }

        [Route("PlanoSemanalDetails")]
        [HttpGet]
        public List<FC_PlanoSemanal> BindPlanoSemanal()
        {

            //FK_FC_MeioTransporte eliminar do codigo!!!

            List<FC_PlanoSemanal> lstUser = new List<FC_PlanoSemanal>();
            using (Models.ForeCast objEntity = new Models.ForeCast())
            {
                lstUser = objEntity.FC_PlanoSemanal.ToList();
            }
            return lstUser;
        }


    }
}