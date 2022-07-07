using CsvHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace PlanoEmbarque.API.Util
{
    public class CSVHelper
    {

        public void WriterCSV(List<PlanoEmbarque.Entities.PlanoEmbarqueCSV> lista)
        {
            //using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioCSV"]))
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioCSV"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        public void WriterCSVPronostico(List<PlanoEmbarque.Entities.PronosticoCSV> lista)
        {
            //using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioCSV"]))
            //using (var FileExcel = new StreamWriter(ConfigurationManager.AppSettings["diretorioExel"]))
            using (var writer = new StreamWriter(@"C:\Temp\file.csv"))

            //using (var writer = new StreamWriter(@"C:\Temp\file.csv"))
            
                //var dataBytes = File.ReadAllBytes("\\\\gremportaldev\\GREM_DEV\\file.csv");

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        //ToDo Mauro
        public void WriterIR(List<PlanoEmbarque.Entities.PlanoEmbarqueIR> lista)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioIR"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        public void WriterQ1(List<PlanoEmbarque.Entities.PlanoEmbarqueQ> lista)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioQ1"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        public void WriterQ2(List<PlanoEmbarque.Entities.PlanoEmbarqueQ> lista)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioQ2"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        public void WriterQ3(List<PlanoEmbarque.Entities.PlanoEmbarqueQ> lista)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioQ3"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
        public void WriterQ4(List<PlanoEmbarque.Entities.PlanoEmbarqueQ> lista)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["diretorioQ4"]))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteRecords(lista);
            }
        }
    }

}