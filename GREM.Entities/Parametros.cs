using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEmbarque.Entities
{
    [Table("Parametros")]
    public class Parametros
    {
        [Key]
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
    }
}
