using System.Web.Http;
using WebActivatorEx;
using GREM.API;
using Swashbuckle.Application;
using System.Linq;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "RegisterApi")]
namespace GREM.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "GREM.API");
                        c.ResolveConflictingActions(d => d.First());
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
