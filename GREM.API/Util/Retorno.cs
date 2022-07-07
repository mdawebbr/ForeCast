using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GREM.API.Util
{
    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public enum EnumTipo
    {
        green, orange
    }

    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public enum EnumStatus
    {
        OK, NOTOK
    }
    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public class Retorno
    {
        public string Mensagem { get; set; }
        public string Tipo
        {
            get
            {
                if (Status == "NOTOK")
                    return "orange";
                else if (Status == "OK")
                    return "green";
                return "";
            }
        }
        public string Titulo { get; set; }
        public string Status { get; set; }
    }
    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public class RetornoList
    {
        public List<string> Mensagem { get; set; }
        public string Tipo {
            get {
                if (Status == "NOTOK")
                    return "orange";
                else if (Status == "OK")
                    return "green";
                return "";
            }
        }
        public string Titulo { get; set; }
        public string Status { get; set; }
    }
    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public static class ErrorUtil
    {
        public static void AppendError(string erro, ref List<string> lista)
        {
            lista.Add($"{lista.Count + 1}. - {erro} <br />");
        }
    }
    [Obsolete("Classe Obsoleta, favor usar o ApiHelper")]
    public static class RetornoUtil
    {
        public static Retorno Ok(string titulo, string mensagem)
        {
            return new Retorno(){
                Mensagem = mensagem,
                Titulo = titulo,
                Status = EnumStatus.OK.ToString()
            };
        }

        public static RetornoList Ok(string titulo, List<string> mensagem)
        {
            return new RetornoList()
            {
                Mensagem = mensagem,
                Titulo = titulo,
                Status = EnumStatus.OK.ToString(),
            };
        }

        public static Retorno Notok(string titulo, string mensagem)
        {
            return new Retorno()
            {
                Mensagem = mensagem,
                Titulo = titulo,
                Status = EnumStatus.NOTOK.ToString(),
            };
        }

        public static Retorno Notok(string titulo, List<string> mensagem)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 1; i <= mensagem.Count; i++)
                str.Append($"<b>{i}.</b> {mensagem[i-1]}<br>");

            return new Retorno()
            {
                Mensagem = str.ToString(),
                Titulo = titulo,
                Status = EnumStatus.NOTOK.ToString(),
            };
        }
    }
}