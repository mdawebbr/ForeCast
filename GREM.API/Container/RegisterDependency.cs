using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using GREM.DAL.Interfaces;
using GREM.DAL;
using GREM.API.Util;

namespace GREM.API.Container
{
    public static class RegisterDependency
    {
        public static void Register(ref IUnityContainer _container)
        {
            _container.RegisterType<IDALCliente, DALCliente>();
            _container.RegisterType<IDALLinhaCAP, DALLinhaCAP>();
            _container.RegisterType<IDALMercadoCAP, DALMercadoCAP>();
            _container.RegisterType<IDALMercadoVF, DALMercadoVF>();
            _container.RegisterType<IDALPronostico, DALPronostico>();
            _container.RegisterType<IDALPlanoEmbarque, DALPlanoEmbarque>();
            _container.RegisterType<IDALParametros, DALParametros>();
            _container.RegisterType<IDALNgmultselect, DALNgmultselect>();
        }
    }
}