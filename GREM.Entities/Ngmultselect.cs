using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class Ngmultselect
    {
        public Ngmultselect()
        {
        }
        [Key]
        public int Cliente_Id { get; set; }
        public string Nome_Cliente { get; set; }
        public string Meses { get; set; }
        public int Ano { get; set; }
        //public float Valor { get; set; }

        public class NgmultselectAdd
        {
            public List<int> Cliente_id { get; set; }
            public string Nome_Cliente { get; set; }
            public List<string> Meses { get; set; }
            public int Ano { get; set; }
            //public float Valor { get; set; }
        }
    }

}
