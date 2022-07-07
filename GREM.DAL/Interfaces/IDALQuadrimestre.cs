using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALQuadrimestre : IDAL<PlanoEmbarque.Entities.Quadrimestre>
    {
        new IEnumerable<Quadrimestre> GetAll();
        IEnumerable<MeioTransporte> GetAllMeioTransporte();
        bool ExistePlanoEmbarqueCliente(int cliente_id);
    }
}