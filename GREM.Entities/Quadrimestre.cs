using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    public class Quadrimestre
    {
        public Quadrimestre()
        {
        }
        public int Id { get; set; }
        [Key]
        public string Chave { get; set; }
        public DateTime DTInicio { get; set; }
        public DateTime DTFimValor { get; set; }

    }
}
