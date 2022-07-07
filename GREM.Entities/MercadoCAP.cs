using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class MercadoCAP
    {
        public MercadoCAP()
        {
        }
        [Key]
        public int MercadoCAPId { get; set; }
        public string Mercado_CAP { get; set; }
    }

}
