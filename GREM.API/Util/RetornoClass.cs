using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GREM.API.Util
{
    public class RetornoUsuarioClass
    {
        public string status { get; set; }
        public Usuario usuario { get; set; }
    }

    public class Usuario
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<GenericAttributesValues> GenericAttributesValues { get; set; }
        public string Status { get; set; }

    } 

    public class GenericAttributesValues
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}