using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALPronostico : IDAL<PlanoEmbarque.Entities.Pronostico>
    {
        new IEnumerable<Pronostico> GetAll();
        IEnumerable<PronosticoCSV> GetCSV();
        IEnumerable<Pronostico> SP(string p1, int p2);
        IEnumerable<MeioTransporte> GetAllMeioTransporte();
        bool ExistePlanoEmbarqueCliente(int cliente_id);
    }
}