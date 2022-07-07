using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GREM.API.Util
{
    public class ApiHelper : ApiController
    {
        public IHttpActionResult Ok(string titulo, string mensagem)
        {
            var json = new
            {
                mensagem = mensagem,
                titulo = titulo,
                type = "green"
            };

            return base.Ok(json);
        }

        public IHttpActionResult Notok(string titulo, string mensagem)
        {
            var json = new
            {
                mensagem = mensagem,
                titulo = titulo,
                type = "orange"
            };

            return base.Ok(json);
        }
    }
}