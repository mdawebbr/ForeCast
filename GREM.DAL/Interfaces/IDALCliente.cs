using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALCliente : IDAL<PlanoEmbarque.Entities.Cliente>
    {
        new IEnumerable<Cliente> GetAll();
        IEnumerable<MeioTransporte> GetAllMeioTransporte();
        bool ExistePlanoEmbarqueCliente(int cliente_id);
    
    }
}