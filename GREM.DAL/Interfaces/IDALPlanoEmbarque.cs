using PlanoEmbarque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREM.DAL.Interfaces
{
    public interface IDALPlanoEmbarque : IDAL<PlanoEmbarque.Entities.PlanoEmbarque>
    {
        IEnumerable<PlanoEmbarque.Entities.PlanoEmbarque> GetAll(int mes, int ano);
        bool PassouLimiteDia(PlanoEmbarque.Entities.PlanoEmbarque p);
        bool PassouLimiteDiaAlterar(PlanoEmbarque.Entities.PlanoEmbarque pe, PlanoEmbarqueAlterar p);
        IEnumerable<PlanoEmbarqueCSV> GetCSV(int mes, int ano, int cliente_id, int transporte_id);
        //ToDo Mauro
        IEnumerable<PlanoEmbarqueIR> GetIR(int mes, int ano, int cliente_id, int transporte_id);
        IEnumerable<PlanoEmbarqueQ> GetIRQ1(int mes, int ano, int cliente_id, int transporte_id);
        IEnumerable<PlanoEmbarqueQ> GetIRQ2(int mes, int ano, int cliente_id, int transporte_id);
        IEnumerable<PlanoEmbarqueQ> GetIRQ3(int mes, int ano, int cliente_id, int transporte_id);
        IEnumerable<PlanoEmbarqueQ> GetIRQ4(int mes, int ano, int cliente_id, int transporte_id);
    }
}