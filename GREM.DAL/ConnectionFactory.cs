using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;

namespace GREM.DAL
{
    public class ConnectionFactory
    {
        /*
        comandos Angular
        Compilar para DEV
        ng build --configuration=dev
        Compilar para Produção
        ng build --configuration=production
        ng build --configuration=dev
        Angular.json
        "baseHref": "/webstart/",
        "deployUrl": "/webstart/",
        trocar para sql do servidor no webconfig
        DapperServer = TERBRDSPM02V01 Servidor SQL Ternium
        Dapperlocal = SRV2012R2 - 01   Servidor SQL Local
        <add key="dapperkey" value="DapperServer"/>
        <add key = "dapperkey" value= "Dapperlocal" />
        GREM.DAL.ConnectionFactory 
        return ConfigurationManager.ConnectionStrings["DapperServer"].ConnectionString;
        return ConfigurationManager.ConnectionStrings["Dapperlocal"].ConnectionString;
        Trocar de Debug para Release
        trocar no web.config a string de coneção ForeCast Entity Framework para o servidor que sera usado Ternium ou Local
        estou vendo se da pra automatizar isso no web.config
        Zipar diretorio GREM.UI\dist\dev e enviar para o Servidor
        Não precisa mais renomear o web.config em Desenvolvimento
        Renomerar web.config
        */

        public string GetConnection()
        {
            //pega nome do servidor no webconfig
            //string conectionstring = WebConfigurationManager.AppSettings["dapperkey"];

            return ConfigurationManager.ConnectionStrings["Dapperserver"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["Dapperlocal"].ConnectionString;
        }
    }
}
