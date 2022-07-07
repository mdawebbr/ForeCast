using Codingvila_ReadExcel_API.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
 
namespace Codingvila_ReadExcel_API.Controllers
{
    [RoutePrefix("Api/Excel")]
    public class ReadExcelController : ApiController
    {
        [Route("ReadFile")]
        [HttpPost]
        public string ReadFile()
        {
            try
            {
                #region Variable Declaration
                string message = "";
                HttpResponseMessage ResponseMessage = null;
                var httpRequest = HttpContext.Current.Request;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                #endregion
 
                #region Save Student Detail From Excel
                using (dbCodingvilaEntities objEntity = new dbCodingvilaEntities())
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        Inputfile = httpRequest.Files[0];
                        FileStream = Inputfile.InputStream;
 
                        if (Inputfile != null && FileStream != null)
                        {
                            if (Inputfile.FileName.EndsWith(".xls"))
                                reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                            else if (Inputfile.FileName.EndsWith(".xlsx"))
                                reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                            else
                                message = "The file format is not supported.";
 
                            dsexcelRecords = reader.AsDataSet();
                            reader.Close();
 
                            if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                            {
                                DataTable dtStudentRecords = dsexcelRecords.Tables[0];
                                for (int i = 0; i < dtStudentRecords.Rows.Count; i++)
                                {
                                    Student objStudent = new Student();
                                    objStudent.RollNo = Convert.ToInt32(dtStudentRecords.Rows[i][0]);
                                    objStudent.EnrollmentNo = Convert.ToString(dtStudentRecords.Rows[i][1]);
                                    objStudent.Name = Convert.ToString(dtStudentRecords.Rows[i][2]);
                                    objStudent.Branch = Convert.ToString(dtStudentRecords.Rows[i][3]);
                                    objStudent.University = Convert.ToString(dtStudentRecords.Rows[i][4]);
                                    objEntity.Students.Add(objStudent);
                                }
 
                                int output = objEntity.SaveChanges();
                                if (output > 0)
                                    message = "The Excel file has been successfully uploaded.";
                                else
                                    message = "Something Went Wrong!, The Excel file uploaded has fiald.";
                            }
                            else
                                message = "Selected file is empty.";
                        }
                        else
                            message = "Invalid File.";
                    }
                    else
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return message;
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}