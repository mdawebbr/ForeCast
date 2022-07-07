using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Http;
using GREM.DAL.Interfaces;
using GREM.API.Util;
using PlanoEmbarque.Entities;
using GREM.API.Models;
using System.Data.Entity;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;


namespace GREM.API.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/ExcelDownloadDapper")]
    public class ExcelDownloadDapperController : ApiHelper
    {
        private IDALCliente _dalCliente;
        public ExcelDownloadDapperController(IDALCliente dalCliente)
        {
            _dalCliente = dalCliente;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalCliente.GetAll();
            return Ok(item);
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

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //static async Task Main(string[] args)
        //{
        //    //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    var file = new FileInfo(@"C:\Demos\YouTubeDemo.xlsx");

        //    var people = GetSetupData();

        //    await SaveExcelFile(people, file);


        //    List<PersonModel> peopleFromExcel = await LoadExcelFile(file);

        //    foreach (var p in peopleFromExcel)
        //    {
        //        Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName}");
        //    }
        //}

        //private static async Task<List<PersonModel>> LoadExcelFile(FileInfo file)
        //{
        //    List<PersonModel> output = new();

        //    //using var package = new ExcelPackage(file);
        //    var package = new ExcelPackage(file);

        //    await package.LoadAsync(file);

        //    var ws = package.Workbook.Worksheets[0];

        //    int row = 3;
        //    int col = 1;

        //    while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
        //    {
        //        PersonModel p = new();
        //        p.Id = int.Parse(ws.Cells[row, col].Value.ToString());
        //        p.FirstName = ws.Cells[row, col + 1].Value.ToString();
        //        p.LastName = ws.Cells[row, col + 2].Value.ToString();
        //        output.Add(p);
        //        row += 1;
        //    }

        //    return output;
        //}

        //private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
        //{
        //    DeleteIfExists(file);

        //    //using var package = new ExcelPackage(file);
        //    var package = new ExcelPackage(file);

        //    var ws = package.Workbook.Worksheets.Add("MainReport");

        //    var range = ws.Cells["A2"].LoadFromCollection(people, true);
        //    range.AutoFitColumns();

        //    // Formats the header
        //    ws.Cells["A1"].Value = "Our Cool Report";
        //    ws.Cells["A1:C1"].Merge = true;
        //    ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //    ws.Row(1).Style.Font.Size = 24;
        //    ws.Row(1).Style.Font.Color.SetColor(Color.Blue);

        //    ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //    ws.Row(2).Style.Font.Bold = true;
        //    ws.Column(3).Width = 20;

        //    await package.SaveAsync();

        //    var memoryStream = package.GetAsByteArray();

        //    //return base.File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", file); //fileName é o nome do teu ficheiro

        //    //return new File(package, "application/vnd.ms-excel", "nomeDoArquivo.xls");

        //}

        //private static void DeleteIfExists(FileInfo file)
        //{
        //    if (file.Exists)
        //    {
        //        file.Delete();
        //    }
        //}

        //private static List<PersonModel> GetSetupData()
        //{
        //    List<PersonModel> output = new()
        //    {
        //        new() { Id = 1, FirstName = "Tim", LastName = "Corey" },
        //        new() { Id = 2, FirstName = "Sue", LastName = "Storm" },
        //        new() { Id = 3, FirstName = "Jane", LastName = "Smith" }
        //    };

        //    return output;
        //}

        ////public void CreateExcelFirstTemplate()
        ////{
        ////    //var fileName = "ExcellData.xlsx";
        ////    var fileName = new FileInfo(@"C:\Demos\YouTubeDemo.xlsx");
        ////    using (var package = new OfficeOpenXml.ExcelPackage(fileName))
        ////    {
        ////        var worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Attempts");
        ////        worksheet = package.Workbook.Worksheets.Add("Assessment Attempts");
        ////        worksheet.Row(1).Height = 20;

        ////        worksheet.TabColor = Color.Gold;
        ////        worksheet.DefaultRowHeight = 12;
        ////        worksheet.Row(1).Height = 20;

        ////        worksheet.Cells[1, 1].Value = "Employee Number";
        ////        worksheet.Cells[1, 2].Value = "Course Code";

        ////        var cells = worksheet.Cells["A1:J1"];
        ////        var rowCounter = 2;
        ////        foreach (var v in userAssessmentsData)
        ////        {
        ////            worksheet.Cells[rowCounter, 1].Value = v.CompanyNumber;
        ////            worksheet.Cells[rowCounter, 2].Value = v.CourseCode;

        ////            rowCounter++;
        ////        }
        ////        worksheet.Column(1).AutoFit();
        ////        worksheet.Column(2).AutoFit();


        ////        package.Workbook.Properties.Title = "Attempts";
        ////        this.HTTP.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        ////        this.HTTPResponse.AddHeader(
        ////                  "content-disposition",
        ////                  string.Format("attachment;  filename={0}", "ExcellData.xlsx"));
        ////        this.HTTPResponse.BinaryWrite(package.GetAsByteArray());
        ////    }


        ////}
        ////public FileActionResult DownloadMyFile()
        ////{
        ////    var filePath = @"C:\ExcelDataTest\ExcellData.xlsx";
        ////    var fileName = "ExcellData.xlsx";
        ////    var mimeType = "application/vnd.ms-excel";
        ////    return File(new FileStream(filePath, FileMode.Open), mimeType, fileName);
        ////}

        //public class PersonModel
        //{
        //    public int Id { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //}



    }
}