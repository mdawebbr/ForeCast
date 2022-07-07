using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALMercadoVF : IDAL<PlanoEmbarque.Entities.MercadoVF>
    {
        new IEnumerable<MercadoVF> GetAll(); 
    }
}