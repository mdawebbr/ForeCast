using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class Pronostico
    {
        public Pronostico()
        {
        }

        [Key]
        public string Customer_Order { get; set; }
        public string Customer_Grade { get; set; }
        public string RIO { get; set; }
        public string MES_Cod { get; set; }
        public string Customer_Name { get; set; }
        public string Pacote { get; set; }
        public string Modal { get; set; }
        public string Po_Amount { get; set; }
        public string Prod_Amount { get; set; }
        public string Plan_Amount { get; set; }
        public string Open_Amount { get; set; }
        public DateTime Due_Date { get; set; }
    }
    public class PronosticoCSV
    {
        public string Customer_Order { get; set; }
        public string Customer_Grade { get; set; }
        public string RIO { get; set; }
        public string MES_Cod { get; set; }
        public string Customer_Name { get; set; }
        public string Pacote { get; set; }
        public string Modal { get; set; }
        public string Po_Amount { get; set; }
        public string Prod_Amount { get; set; }
        public string Plan_Amount { get; set; }
        public DateTime Due_Date { get; set; }
    }
}
