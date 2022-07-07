using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALNgmultselect : IDAL<PlanoEmbarque.Entities.Ngmultselect>
    {
  
        new IEnumerable<Ngmultselect> GetAll(); 
    }
}