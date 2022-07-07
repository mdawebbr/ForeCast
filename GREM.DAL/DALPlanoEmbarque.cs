using GREM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanoEmbarque.Entities;
using Dapper;
using System.Data.SqlClient;
using System.Transactions;

namespace GREM.DAL
{
    public class DALPlanoEmbarque : ConnectionFactory, IDALPlanoEmbarque
    {

        public DALPlanoEmbarque()
        {
        }

        public IEnumerable<PlanoEmbarque.Entities.PlanoEmbarque> GetAll()
        {
            string sql = $@"
	                        select * from FC_PlanoEmbarque pe 
		                        join FC_Cliente c on c.Id = pe.Cliente_Id
		                        join FC_MeioTransporte mt on mt.Id = pe.MeioTransporte_Id
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarque, PlanoEmbarque.Entities.Cliente, PlanoEmbarque.Entities.MeioTransporte, PlanoEmbarque.Entities.PlanoEmbarque>(sql,
                   map: (plano, cliente, meioTransporte) =>
                   {
                       plano.Cliente = cliente;
                       plano.MeioTransporte = meioTransporte;
                       return plano;
                   }, splitOn: "Id, Id, Id").ToList();

                return cl;
            }
        }


        public IEnumerable<PlanoEmbarque.Entities.PlanoEmbarque> GetAll(int mes, int ano)
        {
            string sql = $@"
	                        select * from FC_PlanoEmbarque pe 
		                        join FC_Cliente c on c.Cliente_Id = pe.Cliente_Id
		                        join FC_MeioTransporte mt on mt.Id = pe.MeioTransporte_Id
                            where pe.Mes = {mes} and pe.PEA_Ano = {ano}
                            order by pe.Dia, c.Cliente_Id, mt.Id";

            using (var con = new SqlConnection(base.GetConnection())) {
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarque, PlanoEmbarque.Entities.Cliente, PlanoEmbarque.Entities.MeioTransporte, PlanoEmbarque.Entities.PlanoEmbarque>(sql,
                    map: (plano, cliente, meioTransporte) =>
                    {
                        plano.Cliente = cliente;
                        plano.MeioTransporte = meioTransporte;
                        return plano;
                    }, splitOn: "Id, Id, Id").ToList();

                return cl;
            }
        }


        public IEnumerable<PlanoEmbarqueCSV> GetCSV(int mes, int ano, int cliente_id, int transporte_id)
        {

            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }



            string sql = $@"select c.Nome as Cliente,
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueCSV>(sql).ToList();

                return cl;
            }
        }

        //ToDo Mauro
        public IEnumerable<PlanoEmbarqueIR> GetIR(int mes, int ano, int cliente_id, int transporte_id)
        {

            //var lista = _dalQuadrimestre.GetIR(mes, ano, cliente_id, transporte_id).ToList();


            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }

            string sql = $@"select c.Nome as Cliente,
                                   c.Linha_CAP as Linha_CAP,       
                                   c.constante as constante,
                                   c.Data_inserida as Data_inserida,
                                   c.NAConstante as NAConstante,
                                   c.DataAnoMes as DataAnoMes,
                                   c.Mercado as Mercado,
                                   getdate(),
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data1],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql1 = $@"select c.Nome as Cliente, 
                                    pe.Contador as Contador, 
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas1,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas2,
   	                                pe.Valor as Valor1,
   	                                pe.Valor as Valor2,
   	                                pe.Valor as Valor3,
	                                '0' as Zero,
	                                getdate() as data1,
	                                (Select DAY(DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, -1, getdate()), 0)))) as QtdDiasMes,
	                                'NA' as NAConstante,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovc', 'Cus')) as Venda_Reap,
	                                (Select CONVERT(VARCHAR(4), DATEPART(year, getdate())) + '/' + CONVERT(VARCHAR(4), DATEPART(month, getdate()))) as Data_inserida,
	                                (Select CONVERT(VARCHAR(4), pe.Ano) + CONVERT(VARCHAR(2), pe.Mes)) as Data2,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP1,
	                                'Target' as Target,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP2,
	                                pe.Quadrimestre as Quadrimestre,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP3,
	                                c.Linha_CAP as PlacaLinha_CAP4,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovr', 'Primeira')) as PrimeiraOvr,
                                    c.mercado as Mercado,
	                                'US' as US,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data3], 
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data4], 
                                    pe.Pacote as Pacote,
	                                (select q.Chave from FC_Quadrimestre q where DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0) between q.DTInicio and DTFimValor ) as Quadrimestre,
	                                c.Cor as Cor,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data5], 
	                                (Select format(CAST(getdate() AS DATE), 'yyyyMM')) as [Data6]
                           from FC_PlanoEmbarque pe
                           join FC_Cliente c on c.Id = pe.Cliente_Id
                           {whereClause} 
                           order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), c.Nome";
                           //where pe.Mes = 7 and pe.PEA_Ano = 2020 
                            
            using (var con = new SqlConnection(base.GetConnection()))
            {
                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql).ToList();
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql1).ToList();

                return cl;
            }
        }


        public PlanoEmbarque.Entities.Quadrimestre GetQ(int id)
        {
            string sql = $@"select c.*
                            from FC_Quadrimestre c
                            where c.Id = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Quadrimestre>(sql).FirstOrDefault();

                return cl;
            }
        }

        public PlanoEmbarque.Entities.PlanoEmbarque Get(int id)
        {
            string sql = $@"select c.*
                            from FC_PlanoEmbarque c
                            where c.Id = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarque>(sql).FirstOrDefault();

                return cl;
            }
        }

        public bool PassouLimiteDiaAlterar(PlanoEmbarque.Entities.PlanoEmbarque pe, PlanoEmbarqueAlterar p)
        {

            var limite = GetLimiteByTransporteId(pe.MeioTransporte_Id);

            string sql = $@"select count(*) from FC_PlanoEmbarque pe
	                        where pe.Dia = {pe.Dia} and pe.Mes = {pe.Mes} and pe.PEA_Ano = {pe.PEA_Ano}
	                        and pe.MeioTransporte_Id = {pe.MeioTransporte_Id} and pe.Id <> {p.id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var count = con.Query<int>(sql).FirstOrDefault();

                if (count >= limite)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PassouLimiteDia(PlanoEmbarque.Entities.PlanoEmbarque p)
        {
            var limite = GetLimiteByTransporteId(p.MeioTransporte_Id);

            string sql = $@"select count(*) from FC_PlanoEmbarque pe
	                        where pe.Dia = {p.Dia} and pe.Mes = {p.Mes} and pe.PEA_Ano = {p.PEA_Ano}
	                        and pe.MeioTransporte_Id = {p.MeioTransporte_Id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var count = con.Query<int>(sql).FirstOrDefault();

                if (count >= limite)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetLimiteByTransporteId(int id)
        {
            string sql = $@"select p.Valor from FC_Parametro p
                            where p.Chave = '{id}'";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<int>(sql).FirstOrDefault();

                return cl;
            }
        }


        public void Add(PlanoEmbarque.Entities.PlanoEmbarque pe)
        {
            string sql = $@"insert into FC_PlanoEmbarque (Dia, Mes, Ano, Valor, PEA_Ano, MeioTransporte_Id, Cliente_Id, Pacote)
	                        values ({pe.Dia},{pe.Mes},{pe.Ano},{pe.Valor},{pe.PEA_Ano},{pe.MeioTransporte_Id},{pe.Cliente_Id}, null);";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(PlanoEmbarque.Entities.PlanoEmbarque pe)
        {
            string sql = $@"delete FC_PlanoEmbarque
                            where Id = {pe.Id};";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Update(PlanoEmbarque.Entities.PlanoEmbarque pe)
        {
            string sql = $@"update FC_PlanoEmbarque set Valor = {pe.Valor}, MeioTransporte_Id = {pe.MeioTransporte_Id} , Pacote = '{pe.Pacote}'
                            where Id = {pe.Id};";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }
        public IEnumerable<PlanoEmbarqueQ> GetIRQ1(int mes, int ano, int cliente_id, int transporte_id)
        {

            //var lista = _dalQuadrimestre.GetIR(mes, ano, cliente_id, transporte_id).ToList();


            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }

            string sql = $@"select c.Nome as Cliente,
                                   c.Linha_CAP as Linha_CAP,       
                                   c.constante as constante,
                                   c.Data_inserida as Data_inserida,
                                   c.NAConstante as NAConstante,
                                   c.DataAnoMes as DataAnoMes,
                                   c.Mercado as Mercado,
                                   getdate(),
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data1],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql1 = $@"select c.Nome as Cliente, 
                                    pe.Contador as Contador, 
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas1,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas2,
   	                                pe.Valor as Valor1,
   	                                pe.Valor as Valor2,
   	                                pe.Valor as Valor3,
	                                '0' as Zero,
	                                getdate() as data1,
	                                (Select DAY(DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, -1, getdate()), 0)))) as QtdDiasMes,
	                                'NA' as NAConstante,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovc', 'Cus')) as Venda_Reap,
	                                (Select CONVERT(VARCHAR(4), DATEPART(year, getdate())) + '/' + CONVERT(VARCHAR(4), DATEPART(month, getdate()))) as Data_inserida,
	                                (Select CONVERT(VARCHAR(4), pe.Ano) + CONVERT(VARCHAR(2), pe.Mes)) as Data2,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP1,
	                                'Target' as Target,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP2,
	                                pe.Quadrimestre as Quadrimestre,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP3,
	                                c.Linha_CAP as PlacaLinha_CAP4,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovr', 'Primeira')) as PrimeiraOvr,
                                    c.mercado as Mercado,
	                                'US' as US,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data3], 
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data4], 
                                    pe.Pacote as Pacote,
	                                (select q.Chave from FC_Quadrimestre q where DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0) between q.DTInicio and DTFimValor ) as Quadrimestre,
	                                c.Cor as Cor,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data5], 
	                                (Select format(CAST(getdate() AS DATE), 'yyyyMM')) as [Data6]
                           from FC_PlanoEmbarque pe
                           join FC_Cliente c on c.Id = pe.Cliente_Id
                           where Quadrimestre = 'Q1'
                           order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), c.Nome";
            //where pe.Mes = 7 and pe.PEA_Ano = 2020 
            //{whereClause} 
            using (var con = new SqlConnection(base.GetConnection()))
            {
                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql).ToList();
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueQ>(sql1).ToList();

                return cl;
            }
        }
        public IEnumerable<PlanoEmbarqueQ> GetIRQ2(int mes, int ano, int cliente_id, int transporte_id)
        {

            //var lista = _dalQuadrimestre.GetIR(mes, ano, cliente_id, transporte_id).ToList();


            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }
            //whereClause = "where Quadrimestre = "'Q1'"";

            string sql = $@"select c.Nome as Cliente,
                                   c.Linha_CAP as Linha_CAP,       
                                   c.constante as constante,
                                   c.Data_inserida as Data_inserida,
                                   c.NAConstante as NAConstante,
                                   c.DataAnoMes as DataAnoMes,
                                   c.Mercado as Mercado,
                                   getdate(),
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data1],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql1 = $@"select c.Nome as Cliente, 
                                    pe.Contador as Contador, 
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas1,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas2,
   	                                pe.Valor as Valor1,
   	                                pe.Valor as Valor2,
   	                                pe.Valor as Valor3,
	                                '0' as Zero,
	                                getdate() as data1,
	                                (Select DAY(DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, -1, getdate()), 0)))) as QtdDiasMes,
	                                'NA' as NAConstante,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovc', 'Cus')) as Venda_Reap,
	                                (Select CONVERT(VARCHAR(4), DATEPART(year, getdate())) + '/' + CONVERT(VARCHAR(4), DATEPART(month, getdate()))) as Data_inserida,
	                                (Select CONVERT(VARCHAR(4), pe.Ano) + CONVERT(VARCHAR(2), pe.Mes)) as Data2,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP1,
	                                'Target' as Target,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP2,
	                                pe.Quadrimestre as Quadrimestre,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP3,
	                                c.Linha_CAP as PlacaLinha_CAP4,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovr', 'Primeira')) as PrimeiraOvr,
                                    c.mercado as Mercado,
	                                'US' as US,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data3], 
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data4], 
                                    pe.Pacote as Pacote,
	                                (select q.Chave from FC_Quadrimestre q where DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0) between q.DTInicio and DTFimValor ) as Quadrimestre,
	                                c.Cor as Cor,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data5], 
	                                (Select format(CAST(getdate() AS DATE), 'yyyyMM')) as [Data6]
                           from FC_PlanoEmbarque pe
                           join FC_Cliente c on c.Id = pe.Cliente_Id
                           where Quadrimestre = 'Q2'
                           order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), c.Nome";
            //where pe.Mes = 7 and pe.PEA_Ano = 2020 

            using (var con = new SqlConnection(base.GetConnection()))
            {
                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql).ToList();
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueQ>(sql1).ToList();

                return cl;
            }
        }
        public IEnumerable<PlanoEmbarqueQ> GetIRQ3(int mes, int ano, int cliente_id, int transporte_id)
        {

            //var lista = _dalQuadrimestre.GetIR(mes, ano, cliente_id, transporte_id).ToList();


            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }

            string sql = $@"select c.Nome as Cliente,
                                   c.Linha_CAP as Linha_CAP,       
                                   c.constante as constante,
                                   c.Data_inserida as Data_inserida,
                                   c.NAConstante as NAConstante,
                                   c.DataAnoMes as DataAnoMes,
                                   c.Mercado as Mercado,
                                   getdate(),
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data1],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql1 = $@"select c.Nome as Cliente, 
                                    pe.Contador as Contador, 
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas1,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas2,
   	                                pe.Valor as Valor1,
   	                                pe.Valor as Valor2,
   	                                pe.Valor as Valor3,
	                                '0' as Zero,
	                                getdate() as data1,
	                                (Select DAY(DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, -1, getdate()), 0)))) as QtdDiasMes,
	                                'NA' as NAConstante,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovc', 'Cus')) as Venda_Reap,
	                                (Select CONVERT(VARCHAR(4), DATEPART(year, getdate())) + '/' + CONVERT(VARCHAR(4), DATEPART(month, getdate()))) as Data_inserida,
	                                (Select CONVERT(VARCHAR(4), pe.Ano) + CONVERT(VARCHAR(2), pe.Mes)) as Data2,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP1,
	                                'Target' as Target,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP2,
	                                pe.Quadrimestre as Quadrimestre,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP3,
	                                c.Linha_CAP as PlacaLinha_CAP4,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovr', 'Primeira')) as PrimeiraOvr,
                                    c.mercado as Mercado,
	                                'US' as US,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data3], 
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data4], 
                                    pe.Pacote as Pacote,
	                                (select q.Chave from FC_Quadrimestre q where DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0) between q.DTInicio and DTFimValor ) as Quadrimestre,
	                                c.Cor as Cor,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data5], 
	                                (Select format(CAST(getdate() AS DATE), 'yyyyMM')) as [Data6]
                           from FC_PlanoEmbarque pe
                           join FC_Cliente c on c.Id = pe.Cliente_Id
                           where Quadrimestre = 'Q3' 
                           order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), c.Nome";
            //where pe.Mes = 7 and pe.PEA_Ano = 2020 

            using (var con = new SqlConnection(base.GetConnection()))
            {
                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql).ToList();
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueQ>(sql1).ToList();

                return cl;
            }
        }
        public IEnumerable<PlanoEmbarqueQ> GetIRQ4(int mes, int ano, int cliente_id, int transporte_id)
        {

            //var lista = _dalQuadrimestre.GetIR(mes, ano, cliente_id, transporte_id).ToList();


            string whereClause = "";

            string[] whereParts = new string[4];

            //todos os meses
            if (mes > 0)
            {
                whereParts[0] = $"pe.Mes = {mes}";
            }

            if (ano > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.PEA_Ano = {ano}";
            }

            if (cliente_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            }

            if (transporte_id > 0)
            {
                int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
                whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            }

            if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            {
                whereClause = "where ";
                whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            }

            string sql = $@"select c.Nome as Cliente,
                                   c.Linha_CAP as Linha_CAP,       
                                   c.constante as constante,
                                   c.Data_inserida as Data_inserida,
                                   c.NAConstante as NAConstante,
                                   c.DataAnoMes as DataAnoMes,
                                   c.Mercado as Mercado,
                                   getdate(),
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
                                   CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data1],
                                   pe.Pacote,
                                   pe.Valor
                            from FC_PlanoEmbarque pe
	                        join FC_Cliente c on c.Id = pe.Cliente_Id
                            {whereClause}
	                        order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql1 = $@"select c.Nome as Cliente, 
                                    pe.Contador as Contador, 
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas1,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Ovc', 'PLACAS_' + c.Linha_CAP + '-NA-Cus')) as placas2,
   	                                pe.Valor as Valor1,
   	                                pe.Valor as Valor2,
   	                                pe.Valor as Valor3,
	                                '0' as Zero,
	                                getdate() as data1,
	                                (Select DAY(DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, -1, getdate()), 0)))) as QtdDiasMes,
	                                'NA' as NAConstante,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovc', 'Cus')) as Venda_Reap,
	                                (Select CONVERT(VARCHAR(4), DATEPART(year, getdate())) + '/' + CONVERT(VARCHAR(4), DATEPART(month, getdate()))) as Data_inserida,
	                                (Select CONVERT(VARCHAR(4), pe.Ano) + CONVERT(VARCHAR(2), pe.Mes)) as Data2,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP1,
	                                'Target' as Target,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP2,
	                                pe.Quadrimestre as Quadrimestre,
	                                (Select 'PLACAS_' + c.Linha_CAP) as PlacaLinha_CAP3,
	                                c.Linha_CAP as PlacaLinha_CAP4,
	                                (Select IIF(c.Linha_CAP = 'Ovc', 'Ovr', 'Primeira')) as PrimeiraOvr,
                                    c.mercado as Mercado,
	                                'US' as US,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data3], 
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data4], 
                                    pe.Pacote as Pacote,
	                                (select q.Chave from FC_Quadrimestre q where DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0) between q.DTInicio and DTFimValor ) as Quadrimestre,
	                                c.Cor as Cor,
                                    CONVERT(VARCHAR(10), DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), 112) as [Data5], 
	                                (Select format(CAST(getdate() AS DATE), 'yyyyMM')) as [Data6]
                           from FC_PlanoEmbarque pe
                           join FC_Cliente c on c.Id = pe.Cliente_Id
                           where Quadrimestre = 'Q4'
                           order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0, 0, 0, 0), c.Nome";
            //where pe.Mes = 7 and pe.PEA_Ano = 2020 

            using (var con = new SqlConnection(base.GetConnection()))
            {
                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql).ToList();
                var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueQ>(sql1).ToList();

                return cl;
            }
        }
        //ToDo Mauro




    }
}
