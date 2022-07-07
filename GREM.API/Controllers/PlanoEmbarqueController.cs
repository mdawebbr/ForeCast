using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using GREM.DAL.Interfaces;
using GREM.API.Util;
using PlanoEmbarque.Entities;
using System.IO;
using GREM.DAL;
using GREM.API.Filters;
using System.Globalization;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using PlanoEmbarque.API.Util;


namespace GREM.API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/PlanoEmbarque")]
    public class PlanoEmbarqueController : ApiHelper
    {
        private IDALCliente _dalCliente;
        private IDALPlanoEmbarque _dalPlanoEmbarque;

        public PlanoEmbarqueController(IDALCliente dalCliente, IDALPlanoEmbarque dalPlanoEmbarque)
        {
            _dalCliente = dalCliente;
            _dalPlanoEmbarque = dalPlanoEmbarque;
        }

        [HttpGet]
        [Route("GetCSV")]
        public IHttpActionResult GetCSV(int mes, int ano, int cliente_id, int transporte_id)
        {
            var lista = _dalPlanoEmbarque.GetCSV(mes, ano, cliente_id, transporte_id).ToList();
            CSVHelper c = new CSVHelper();
            c.WriterCSV(lista);
            //var dataBytes = File.ReadAllBytes("\\\\gremportaldev\\GREM_DEV\\file.csv");
            var dataBytes = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioCSV"]);
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);

            return new FileResult(dataStream, Request, "file.csv");

            //MemoryStream ms = new MemoryStream();


            //using (var memoryStream = new MemoryStream())
            //{
            //    using (var writer = new StreamWriter(memoryStream))
            //    {
            //        writer.AutoFlush = true;
            //        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //        {
            //            csv.Configuration.Delimiter = ";";
            //            csv.Configuration.HasHeaderRecord = false;
            //            csv.WriteRecords(lista);

            //            memoryStream.Flush();
            //            memoryStream.Position = 0;
            //            memoryStream.Dispose();
            //            return new FileResult(memoryStream, Request, "file.csv");
            //        }

            //    }

            //}
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll(int mes, int ano)
        {
            var lista = _dalPlanoEmbarque.GetAll(mes, ano);
            List<PlanoEmbarqueVM> peVM = new List<PlanoEmbarqueVM>();

            List<int> diasMes = new List<int>();
            if (mes < 7)
                ano += 1;

            int qtdDiasMes = System.DateTime.DaysInMonth(ano, mes);

            for(int i = 1; i <= qtdDiasMes; i++)
            {
                PlanoEmbarqueVM pe = new PlanoEmbarqueVM();
                pe.Dia = i;
                pe.Mes = mes;

                var plano = lista.Where(x => x.Dia == i).ToList();

                pe.ListaCliente = new List<ClientePlanoEmbarque>();

                foreach (var p in plano)
                {
                    ClientePlanoEmbarque cpe = new ClientePlanoEmbarque();
                    cpe.ClienteValor = p.Cliente.Nome + ": " + p.Valor.ToString();
                    cpe.MeioTransporte = p.MeioTransporte;
                    cpe.Cor = p.Cliente.Cor;
                    cpe.Id = p.Id;
                    cpe.Valor = p.Valor;
                    cpe.Cliente = p.Cliente;

                    pe.ListaCliente.Add(cpe);
                }

                peVM.Add(pe);
            }

            return Ok(peVM);
        }


        [HttpGet]
        [Route("GetFilter")]
        public IHttpActionResult GetFilter(int mes, int ano, int cliente_id, int transporte_id)
        {
            var lista = _dalPlanoEmbarque.GetAll(mes, ano);

            if(cliente_id > 0)
            {
                lista = lista.Where(x => x.Cliente_Id == cliente_id).ToList();
            }
            if(transporte_id > 0)
            {
                lista = lista.Where(x => x.MeioTransporte_Id == transporte_id).ToList();
            }

            List<PlanoEmbarqueVM> peVM = new List<PlanoEmbarqueVM>();
            

            if (mes < 7)
                ano += 1;

            int qtdDiasMes = System.DateTime.DaysInMonth(ano, mes);

            for (int i = 1; i <= qtdDiasMes; i++)
            {
                PlanoEmbarqueVM pe = new PlanoEmbarqueVM();
                pe.Dia = i;
                pe.Mes = mes;

                var plano = lista.Where(x => x.Dia == i).ToList();

                pe.ListaCliente = new List<ClientePlanoEmbarque>();

                float valorTotal = 0;

                foreach (var p in plano)
                {
                    ClientePlanoEmbarque cpe = new ClientePlanoEmbarque();
                    cpe.ClienteValor = p.Cliente.Nome + ": " + p.Valor.ToString();
                    cpe.MeioTransporte = p.MeioTransporte;
                    cpe.Cor = p.Cliente.Cor;
                    cpe.Id = p.Id;
                    cpe.Valor = p.Valor;
                    cpe.Cliente = p.Cliente;
                    cpe.Pacote = p.Pacote;

                    valorTotal += p.Valor;

                    pe.ListaCliente.Add(cpe);
                }

                pe.ValorTotalDia = valorTotal;

                peVM.Add(pe);
            }

            return Ok(peVM);
        }

        [HttpPost]
        [Route("Alterar")]
        public IHttpActionResult Alterar(PlanoEmbarqueAlterar pe)
        {
            var listaErros = new List<string>();

            if (pe.valor == 0.0)
                listaErros.Add("O campo Valor é obrigatório.");

            if (pe.transporte_id == 0)
                listaErros.Add("O campo Meio de Transporte é obrigatório.");

            if (listaErros.Count > 0)
            {
                return Ok("Erro", string.Join("<br />", listaErros));
            }


            PlanoEmbarque.Entities.PlanoEmbarque p = _dalPlanoEmbarque.Get(pe.id);

            if (_dalPlanoEmbarque.PassouLimiteDiaAlterar(p, pe))
            {
                DateTime dt = new DateTime(p.Ano, p.Mes, p.Dia);
                return Ok("Erro!",$"A data {dt.Date.ToString("dd/MM/yyyy")} atingiu o limite por transporte.");
            }
            else
            {
                p.Valor = pe.valor;
                p.MeioTransporte_Id = pe.transporte_id;
                p.Pacote = pe.pacote;
                _dalPlanoEmbarque.Update(p);
            }

            return Ok("Sucesso!", "O registro foi alterado com sucesso!");

        }

        [HttpPost]
        [Route("Remover")]
        public IHttpActionResult Remover(PlanoEmbarqueAlterar pe)
        {
            try
            {
                PlanoEmbarque.Entities.PlanoEmbarque p = _dalPlanoEmbarque.Get(pe.id);
                _dalPlanoEmbarque.Remove(p);
            }
            catch(Exception ex)
            {
                return Ok("Erro!", "Ocorreu um erro ao remover. Contate o administrador do sistema!");
            }
            

            return Ok("Sucesso!", "O registro foi removido com sucesso!");

        }



        [HttpPost]
        public IHttpActionResult Post(PlanoEmbarqueAdd pe)
        {
            var listaErros = new List<string>();

            if(pe.cliente_id == null)
            {
                listaErros.Add("O campo Cliente é obrigatório.");
            }
            else
            {
                if (pe.cliente_id.Count == 0)
                {
                    listaErros.Add("O campo Cliente é obrigatório.");
                }
            }

            if (pe.transporte_id == 0)
                listaErros.Add("O campo Meio de Transporte é obrigatório.");

            if (pe.dias == null)
            {
                listaErros.Add("O campo Dias é obrigatório.");
            }
            else
            {
                if (pe.dias.Count == 0)
                    listaErros.Add("O campo Dias é obrigatório.");
            }

            if (pe.meses == null)
            {
                listaErros.Add("O campo Meses é obrigatório.");
            }
            else
            {
                if (pe.meses.Count == 0)
                    listaErros.Add("O campo Meses é obrigatório.");
            }
            
            if(pe.peaAno == 0)
                listaErros.Add("O campo PEA/Ano é obrigatório.");

            if (pe.valor == 0.0)
                listaErros.Add("O campo Valor é obrigatório.");


            if (listaErros.Count > 0)
            {
                return Ok("Erro", string.Join("<br />", listaErros));
            }

            int ano = pe.peaAno;

            var listaErrosAoAdicionar = new List<string>();
            var teveSucessoAoAdicionar = false;

            foreach (var m in pe.meses)
            {
                if (m < 7)
                    ano = pe.peaAno + 1;

                int qtdDiasMes = System.DateTime.DaysInMonth(ano, m);

                foreach(var d in pe.dias)
                {
                    if(d <= qtdDiasMes)
                    {
                        foreach(var cliente in pe.cliente_id)
                        {
                            PlanoEmbarque.Entities.PlanoEmbarque p = new PlanoEmbarque.Entities.PlanoEmbarque();
                            p.Ano = ano;
                            p.Cliente_Id = cliente;
                            p.Dia = d;
                            p.MeioTransporte_Id = pe.transporte_id;
                            p.Mes = m;
                            p.PEA_Ano = pe.peaAno;
                            p.Valor = pe.valor;


                            if (_dalPlanoEmbarque.PassouLimiteDia(p))
                            {
                                DateTime dt = new DateTime(p.Ano, p.Mes, p.Dia);
                                listaErrosAoAdicionar.Add($"<i class=\"fa fa-times\" style=\"color: #B22222;\" aria-hidden=\"true\"></i> A data {dt.Date.ToString("dd /MM/yyyy")} atingiu o limite por transporte.");
                            }
                            else
                            {
                                _dalPlanoEmbarque.Add(p);
                                teveSucessoAoAdicionar = true;
                            }
                        }
                        
                    }
                }
            }

            if(listaErrosAoAdicionar.Count > 0 && teveSucessoAoAdicionar == true)
            {
                var mensagemRetorno = "Identificamos os erros abaixo: <br /><br />" + string.Join("<br />", listaErrosAoAdicionar);
                mensagemRetorno = mensagemRetorno + " <br /><br /> " + "<i class=\"fa fa-check\" style=\"color: #228B22;\" aria-hidden=\"true\"></i>  Os demais registros foram cadastrados com sucesso.";
                return Ok("Atenção!", mensagemRetorno);
            }
            else if(listaErrosAoAdicionar.Count > 0 && teveSucessoAoAdicionar == false)
            {
                var mensagemRetorno = "Identificamos os erros abaixo: <br /><br />" + string.Join("<br />", listaErrosAoAdicionar);
                return Ok("Erro!", mensagemRetorno);
            }
            else if(listaErrosAoAdicionar.Count == 0 && teveSucessoAoAdicionar == true)
            {
                return Ok("Sucesso!", "A carga de forecast foi cadastrada com sucesso");
            }

            return Ok("Sucesso!", "A carga de forecast foi cadastrada com sucesso");
        }

        [HttpGet]
        [Route("GetDiaMesFilter")]
        public IHttpActionResult GetDiaMesFilter(int dia, int mes, int ano, int cliente_id, int transporte_id)
        {
            var lista = _dalPlanoEmbarque.GetAll(mes, ano);

            if (cliente_id > 0)
            {
                lista = lista.Where(x => x.Cliente_Id == cliente_id).ToList();
            }
            if (transporte_id > 0)
            {
                lista = lista.Where(x => x.MeioTransporte_Id == transporte_id).ToList();
            }

            List<PlanoEmbarqueVM> peVM = new List<PlanoEmbarqueVM>();

            PlanoEmbarqueVM pe = new PlanoEmbarqueVM();
            pe.Dia = dia;
            pe.Mes = mes;

            var plano = lista.Where(x => x.Dia == dia).ToList();

            pe.ListaCliente = new List<ClientePlanoEmbarque>();

            float valorTotal = 0;

            foreach (var p in plano)
            {
                ClientePlanoEmbarque cpe = new ClientePlanoEmbarque();
                cpe.ClienteValor = p.Cliente.Nome + ": " + p.Valor.ToString();
                cpe.MeioTransporte = p.MeioTransporte;
                cpe.Cor = p.Cliente.Cor;
                cpe.Id = p.Id;
                cpe.Valor = p.Valor;
                cpe.Cliente = p.Cliente;
                cpe.Pacote = p.Pacote;

                valorTotal += p.Valor;

                pe.ListaCliente.Add(cpe);
            }

            pe.ValorTotalDia = valorTotal;

            peVM.Add(pe);

            return Ok(peVM);
        }


        [HttpGet]
        [Route("GetTodosMesesFilter")]
        public IHttpActionResult GetTodosMesesFilter(int ano, int cliente_id, int transporte_id)
        {
            var lista = _dalPlanoEmbarque.GetAll();

            lista = lista.Where(x => x.PEA_Ano == ano).ToList();

            if (cliente_id > 0)
            {
                lista = lista.Where(x => x.Cliente_Id == cliente_id).ToList();
            }
            if (transporte_id > 0)
            {
                lista = lista.Where(x => x.MeioTransporte_Id == transporte_id).ToList();
            }

            List<PlanoEmbarqueTodosMesesVM> peVM = new List<PlanoEmbarqueTodosMesesVM>();


            for(int i = 7; i <= 12; i++)
            {
                if (i < 7)
                    ano += 1;

                int qtdDiasMes = System.DateTime.DaysInMonth(ano, i);

                for (int j = 1; j <= 31; j++)
                {
                    var plano = lista.Where(x => x.Dia == j && x.Mes == i).ToList();

                    float valorT = lista.Where(x => x.Mes == i).ToList().Select(x => x.Valor).Sum();
                    float valorD = plano.Select(x => x.Valor).Sum();


                    PlanoEmbarqueTodosMesesVM pe = new PlanoEmbarqueTodosMesesVM();

                    pe.Dia = j;

                    MesesPlanoEmbarque mpe = new MesesPlanoEmbarque();
                    mpe.Mes = i;
                    mpe.TemValor = plano.Any();
                    mpe.Valor = valorT;
                    mpe.ValorDia = valorD;

                    if(pe.ListaMes == null)
                    {
                        pe.ListaMes = new List<MesesPlanoEmbarque>();
                    }


                    if (peVM.Where(x => x.Dia == j).Any())
                    {
                        pe = peVM.Where(x => x.Dia == j).FirstOrDefault();
                        pe.ListaMes.Add(mpe);
                    }
                    else
                    {
                        pe.ListaMes.Add(mpe);

                        peVM.Add(pe);
                    }
                }
            }

            for (int i = 1; i <= 6; i++)
            {
                ano += 1;

                int qtdDiasMes = System.DateTime.DaysInMonth(ano, i);

                for (int j = 1; j <= 31; j++)
                {
                    var plano = lista.Where(x => x.Dia == j && x.Mes == i).ToList();

                    float valorT = lista.Where(x => x.Mes == i).ToList().Select(x => x.Valor).Sum();
                    float valorD = plano.Select(x => x.Valor).Sum();



                    PlanoEmbarqueTodosMesesVM pe = new PlanoEmbarqueTodosMesesVM();

                    pe.Dia = j;

                    MesesPlanoEmbarque mpe = new MesesPlanoEmbarque();
                    mpe.Mes = i;
                    mpe.TemValor = plano.Any();
                    mpe.Valor = valorT;
                    mpe.ValorDia = valorD;

                    if (pe.ListaMes == null)
                    {
                        pe.ListaMes = new List<MesesPlanoEmbarque>();
                    }



                    if (peVM.Where(x => x.Dia == j).Any())
                    {
                        pe = peVM.Where(x => x.Dia == j).FirstOrDefault();
                        pe.ListaMes.Add(mpe);

                        if (i == 6)
                        {
                            pe.ValorTotalDia = pe.ListaMes.Select(x => x.ValorDia).Sum();
                        }
                    }
                    else
                    {
                        pe.ListaMes.Add(mpe);
                        if (i == 6)
                        {
                            pe.ValorTotalDia = pe.ListaMes.Select(x => x.ValorDia).Sum();
                        }

                        peVM.Add(pe);
                    }

                    
                }
                
            }

            return Ok(peVM);
        }

        [HttpGet]
        [Route("GetAllMeioTransporte")]
        public IHttpActionResult GetAllMeioTransporte()
        {
            var item = _dalCliente.GetAllMeioTransporte();
            return Ok(item);
        }



        //ToDo Mauro
        [HttpGet]
        [Route("GetIR")]
        public IHttpActionResult GetIR(int mes, int ano, int cliente_id, int transporte_id)
        {
            //Planoembarquecontroller.cs
            //IDALPlanoEmbarque.cs
            //DALPlanoEmbarque.cs
            //CSVHelper.cs


            CSVHelper c = new CSVHelper();
 
            var listaIR = _dalPlanoEmbarque.GetIR(mes, ano, cliente_id, transporte_id).ToList();
            c.WriterIR(listaIR);
            var dataBytesIR = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioIR"]);
            //adding bytes to memory stream   
            var dataStreamIR = new MemoryStream(dataBytesIR);
            var FileIR = new FileResult(dataStreamIR, Request, "fileIR.txt");
            
            
            //====================================================================================
            var listaQ1 = _dalPlanoEmbarque.GetIRQ1(mes, ano, cliente_id, transporte_id).ToList();
            c.WriterQ1(listaQ1);
            var dataBytesQ1 = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioQ1"]);
            //adding bytes to memory stream   
            var dataStreamQ1 = new MemoryStream(dataBytesQ1);

            var FileQ1 = new FileResult(dataStreamQ1, Request, "fileQ1.txt");
            //====================================================================================

            //====================================================================================
            var listaQ2 = _dalPlanoEmbarque.GetIRQ2(mes, ano, cliente_id, transporte_id).ToList();
            c.WriterQ2(listaQ2);
            var dataBytesQ2 = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioQ2"]);
            //adding bytes to memory stream   
            var dataStreamQ2 = new MemoryStream(dataBytesQ2);

            var FileQ2 = new FileResult(dataStreamQ2, Request, "fileQ2.txt");
            //====================================================================================

            //====================================================================================
            var listaQ3 = _dalPlanoEmbarque.GetIRQ3(mes, ano, cliente_id, transporte_id).ToList();
            c.WriterQ3(listaQ3);
            var dataBytesQ3 = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioQ3"]);
            //adding bytes to memory stream   
            var dataStreamQ3 = new MemoryStream(dataBytesQ3);

            var FileQ3 = new FileResult(dataStreamQ3, Request, "fileQ3.txt");
            //====================================================================================

            //====================================================================================
            var listaQ4 = _dalPlanoEmbarque.GetIRQ4(mes, ano, cliente_id, transporte_id).ToList();
            c.WriterQ4(listaQ4);
            var dataBytesQ4 = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioQ4"]);
            //adding bytes to memory stream   
            var dataStreamQ4 = new MemoryStream(dataBytesQ4);

            var FileQ4 = new FileResult(dataStreamQ4, Request, "fileQ4.txt");
            //====================================================================================



            return new FileResult(dataStreamIR, Request, "fileIR.txt");

        }
        //public class PlanoEmbarqueIR
        //{
        //    public string Cliente { get; set; }
        //    public string Data { get; set; }
        //    public string Pacote { get; set; }
        //    public string Contador { get; set; }         //a partir de 9001 caso ""OVE"" Senão a partir de 1"	
        //    public string placas1 { get; set; }          //"Placas_Linhas_CAP-NA-CUS ou Placas_Linhas_CAP-NA-OVE"
        //    public string placas2 { get; set; }          //Valor inserido de demanda
        //    public string Valor1 { get; set; }
        //    public string Valor2 { get; set; }
        //    public string Valor3 { get; set; }
        //    public string Zero { get; set; }              //"Set ""0"" constante"
        //    public string Data1 { get; set; }
        //    public string QtdDiasMes { get; set; }        //Quantidade de dias do mês
        //    public string NAConstante { get; set; }       //"Set ""NA"" constante"
        //    public string Venda_Reap { get; set; }        //"Caso seja ""P/ Venda"" ou ""P/ Reaproveitamento""  --> recebe ""OVE"" Senão Set ""Cus"""
        //    public string Data_inserida { get; set; }     //"Data inserida //Formato AAAAMMDD"
        //    public string Data2 { get; set; }             //Ano/Mês inserido no Input Panel
        //    public string PlacaLinha_CAP1 { get; set; }
        //    public string Target { get; set; }            //Set "Target"	
        //    public string PlacaLinha_CAP2 { get; set; }
        //    public string Quadrimestre { get; set; }      //Quadrimestre referente a data inserida no Input Panel de acordo com o PEA
        //    public string PlacaLinha_CAP3 { get; set; }
        //    public string PlacaLinha_CAP4 { get; set; }
        //    public string PrimeiraOvr { get; set; }       //"Caso cliente seja ""P/ Venda"" ou ""P/ Reaproveitamento"" --> recebe ""Ovr"" Senão Set ""Primeira"""	
        //    public string Mercado { get; set; }           //Mercado
        //    public string US { get; set; }                //Default "US"
        //    public string Data3 { get; set; }             //Data inserida na aplicação
        //    public string Data4 { get; set; }
        //    public string Cor { get; set; }
        //    public string Data5 { get; set; }
        //    public string Data6 { get; set; }
        //}

        //[HttpGet]
        //[Route("GetIRQ1")]
        //public IHttpActionResult GetIRQ1(int mes, int ano, int cliente_id, int transporte_id)
        //{
        //    CSVHelper c = new CSVHelper();

        //    var listaQ1 = _dalPlanoEmbarque.GetIRQ1(mes, ano, cliente_id, transporte_id).ToList();
        //    c.WriterQ1(listaQ1);
        //    var dataBytesQ1 = File.ReadAllBytes(ConfigurationManager.AppSettings["diretorioQ1"]);
        //    //adding bytes to memory stream   
        //    var dataStreamQ1 = new MemoryStream(dataBytesQ1);

        //    var FileQ1 = new FileResult(dataStreamQ1, Request, "fileIRQ1.txt");

        //    return new FileResult(dataStreamQ1, Request, "fileIRQ1.txt");

        //}

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
                //httpResponseMessage.Content = new ByteArrayContent(bookStuff.ToArray());  
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = PdfFileName;
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return System.Threading.Tasks.Task.FromResult(httpResponseMessage);
            }
        }
       

    }

    //private void ExportacaoDados(DataSet data, string fileName, int type = 0)
    //{
    //    Response.Clear();
    //    Response.ClearContent();
    //    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".txt");
    //    Response.ContentType = "text/csv";
    //    ExportToCSVFile(Response.OutputStream, data.Tables[0]);
    //    Response.Flush();
    //    Response.Close();
    //    Response.End();
    //}
}

