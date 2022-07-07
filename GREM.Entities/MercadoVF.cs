using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class MercadoVF
    {
        public MercadoVF()
        {
        }
        [Key]
        //public int LinhaCAPId { get; set; }
        //public string Linha_CAP { get; set; }
        public string Mercado_CAP { get; set; }
        public string Mercado_VF { get; set; }
        public int MercadoCAPId { get; set; }
        public int MercadoVFId { get; set; }
    }

}
