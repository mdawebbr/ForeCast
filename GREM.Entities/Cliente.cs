using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class Cliente
    {
        public Cliente()
        {
        }
        [Key]
        //public int Id { get; set; }
        public int Cliente_id { get; set; }
        public string Nome { get; set; }
        public string Linha_CAP { get; set; }
        public string Mercado_CAP { get; set; }
        public string Cor { get; set; }
        public string Modal { get; set; }
        public string Mercado_VF { get; set; }
        public string Pais { get; set; }
        public string Percentual { get; set; }
        public int LinhaCAPId { get; set; }
        public int MercadoCAPId { get; set; }
        public int MercadoVFId { get; set; }
    }
}
