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
using CsvHelper;
using System.Configuration;
using System.Data.SqlClient;
using PlanoEmbarque.API.Util;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Threading.Tasks;
using Ionic.Zip;
using ClosedXML;


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Pronostico")]
    public class PronosticoController : ApiHelper
    {
        private IDALPronostico _dalPronostico;
        public PronosticoController(IDALPronostico dalPronostico)
        {
            _dalPronostico = dalPronostico;
        }

        //public PronosticoController()
        //{
        //}

        [HttpGet]
        [Route("GetCSV")]
        public IHttpActionResult GetCSV()
        {
            //var lista = _dalPronostico.GetCSV(mes, ano, cliente_id, transporte_id).ToList();
            var lista = _dalPronostico.GetCSV().ToList();
            CSVHelper c = new CSVHelper();
            c.WriterCSVPronostico(lista);

            //Web.config
            //< add key = "diretorioCSV" value = "\\\\gremportaldev\\GREM_DEV\\file.csv" />
            //< add key = "diretorioCSV2" value = "\\\\TERBRDSPM02V01\\Downloads\\file.csv" />
            //< add key = "diretorioCSV3" value = "\\\\SRV2012R2-01\\Downloads\\file.csv" />  

            var dataBytes = File.ReadAllBytes(@"C:\Temp\file.csv");

            //var dataBytes = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioCSV"]);
            
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);

            //return new FileResult(dataStream, Request, "file.csv");

            MemoryStream ms = new MemoryStream();
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    writer.AutoFlush = true;
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.HasHeaderRecord = false;
                        csv.WriteRecords(lista);

                        memoryStream.Flush();
                        memoryStream.Position = 0;
                        memoryStream.Dispose();

                        return new FileResult(memoryStream, Request, @"Pronostico.csv");
                    }

                }

            }
        }

        public class FileResult : IHttpActionResult
        {
            MemoryStream bookStuff;
            string PdfFileName;
            HttpRequestMessage httpRequestMessage;
            HttpResponseMessage httpResponseMessage;
            public FileResult(MemoryStream data, HttpRequestMessage request, string filename)
            {
                bookStuff = data;
                httpRequestMessage = request;

                PdfFileName = filename;
            }
            public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
            {
                httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(bookStuff);
                httpResponseMessage.Content = new ByteArrayContent(bookStuff.ToArray());  
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = PdfFileName;
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return Task.FromResult(httpResponseMessage);
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var item = _dalPronostico.GetAll();
            return Ok(item);
        }

        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var item = _dalPronostico.Get(id);
            return Ok(item);
        }


        [HttpGet]
        [Route("GetAllMeioTransporte")]
        public IHttpActionResult GetAllMeioTransporte()
        {
            var item = _dalPronostico.GetAllMeioTransporte();
            return Ok(item);
        }

        //[HttpPost]
        //[Route("Remover")]
        //public IHttpActionResult Remover(Pronostico pe)
        //{
        //    try
        //    {
        //        if (_dalPronostico.ExistePlanoEmbarqueCliente(pe.Customer_Order))
        //        {
        //            return Ok("Erro!", "Este cliente não pode ser removido porque possui registros de Carga de Forecast.");
        //        }
        //        PlanoEmbarque.Entities.Pronostico p = _dalPronostico.Get(pe.Customer_Order);
        //        _dalPronostico.Remove(p);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
        //    }


        //    return Ok("Sucesso!", "O registro foi removido com sucesso!");

        //}

        [HttpPost]
        public IHttpActionResult Post(Pronostico pronostico)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pronostico.Customer_Name))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());

            _dalPronostico.Add(pronostico);

            return Ok("Sucesso!", "O cliente foi cadastrado com sucesso");
        }


        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(Pronostico pe)
        {
            var listaErros = new List<string>();

            if (string.IsNullOrEmpty(pe.Customer_Name))
            {
                listaErros.Add("O campo Nome do cliente é obrigatório.");
            }

            if (listaErros.Count > 0)
                return Ok("Erro!", listaErros.First());


            _dalPronostico.Update(pe);

            return Ok("Sucesso!", "O cliente foi alterado com sucesso");

        }

        [HttpGet]
        [Route("SP")]
        public IHttpActionResult SP(string ano, string mes, int qtd)
        {
            int len = mes.Length;
            if (len == 1)
                mes = "0" + mes;
            

            var item = _dalPronostico.SP(ano+mes, qtd).ToList();
            return Ok(item);



        }


        //private void EnviarArquivosParaUsuario(SLD_Pedido prmObjPedido)
        //{
        //    if (prmObjPedido != null)
        //    {

        //        IQueryable<SLD_Arquivo> lstArquivos = Secao.Query<SLD_Arquivo>().Where(w => w.nmr_idntfcdr_pdd == prmObjPedido);

        //        using (ZipFile zip = new ZipFile())
        //        {
        //            zip.AlternateEncodingUsage = ZipOption.AsNecessary;

        //            foreach (SLD_Arquivo a in lstArquivos)
        //            {
        //                zip.AddEntry(a.nmr_idntfcdr_arqv + "_" + a.nome_arqv, a.arqv);
        //            }

        //            Response.Clear();
        //            Response.BufferOutput = false;
        //            string zipName = String.Format("Lista_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //            Response.ContentType = "application/zip";
        //            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //            zip.Save(Response.OutputStream);
        //            Response.End();

        //        }
        //    }
        //}

        //string attachment = "attachment; filename=Export.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        // Create a form to contain the grid
        //        HtmlForm frm = new HtmlForm();
        //        gv.Parent.Controls.Add(frm);
        //frm.Attributes["runat"] = "server";
        //frm.Controls.Add(gv);
        //frm.RenderControl(htw);
        
        ////GridView1.RenderControl(htw);
        //Response.Write(sw.ToString());
        //Response.End();

    }
}
