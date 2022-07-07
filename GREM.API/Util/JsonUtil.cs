using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GREM.API.Util
{
    public static class JsonUtil<TEntity, TPoco>
        where TEntity : class, new()
        where TPoco : class, new()
    {

        public static TPoco CreatePoco(TEntity entity)
        {
            TPoco poco = new TPoco();

            MethodInfo metodo = typeof(TPoco).GetMethod("DePara");
            object[] parametros = new object[] { entity };

            var sd = metodo.Invoke(poco, parametros);

            return (TPoco)sd;
        }
    }
}