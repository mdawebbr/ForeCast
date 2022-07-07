using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Net;

namespace GREM.API.Util
{
    public static class Sender<TEntity>
        where TEntity : class
    {
        public static RetornoUsuarioClass Send(string url, TEntity obj)
        {
            RestClient cli = new RestClient(new Uri(url));
            RestRequest req = new RestRequest(Method.POST);
            

            string json = Newtonsoft.Json.JsonConvert.SerializeObject((object)obj, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            cli.Proxy = WebRequest.DefaultWebProxy;

            req.AddJsonBody(json);
            req.RequestFormat = DataFormat.Json;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            cli.Timeout = 1200000;
            var ret = cli.Execute(req);
            System.Diagnostics.Debug.WriteLine(ret.Content);

            ret.Content = ret.Content.Replace("'", "");
            

            return ConvertJsonToClass(ret.Content);
        }

        private static void StringEmptyToNull(ref TEntity obj, params string[] tags)
        {
            string[] props = obj.GetType().GetProperties().Where(d => tags.ToList().Contains(d.Name)).Select(d => d.Name).ToArray();

            foreach (var item in props)
            {
                if ((string)obj.GetType().GetProperty(item).GetValue(obj, null) == " ")
                    obj.GetType().GetProperty(item).SetValue(obj, null);
            }
        }

        

        public static RetornoUsuarioClass ConvertJsonToClass(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RetornoUsuarioClass>(json);
        }
    }

}