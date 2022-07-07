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
    public class DALPronostico : ConnectionFactory, IDALPronostico
    {

        public DALPronostico()
        {
        }
       

        public IEnumerable<Pronostico> GetAll()
        {

            //string sql = @"select * from tblPFSSaidaPronosticoSKU c order by c.Customer_Name";
            string sql = @"select * from tblPFSSaidaPronosticoSKU_Resumo2 c order by c.Customer_Order";
            
            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.Pronostico>(sql).ToList();

                return cl;
            }
        }

        public IEnumerable<PronosticoCSV> GetCSV1(int mes, int ano, int cliente_id, int transporte_id)
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
                var cl = con.Query<PlanoEmbarque.Entities.PronosticoCSV>(sql).ToList();

                return cl;
            }
        }
        public IEnumerable<PronosticoCSV> GetCSV()
        {

            string whereClause = "";

            string[] whereParts = new string[4];

            ////todos os meses
            //if (mes > 0)
            //{
            //    whereParts[0] = $"pe.Mes = {mes}";
            //}

            //if (ano > 0)
            //{
            //    int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
            //    whereParts[count] = $"pe.PEA_Ano = {ano}";
            //}

            //if (cliente_id > 0)
            //{
            //    int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
            //    whereParts[count] = $"pe.Cliente_Id = {cliente_id}";
            //}

            //if (transporte_id > 0)
            //{
            //    int count = whereParts.Where(x => !string.IsNullOrEmpty(x)).Count();
            //    whereParts[count] = $"pe.Transporte_Id = {transporte_id}";
            //}

            //if (mes > 0 || ano > 0 || cliente_id > 0 || transporte_id > 0)
            //{
            //    whereClause = "where ";
            //    whereClause += string.Join(" and ", whereParts.Where(x => !string.IsNullOrEmpty(x)).ToList());
            //}



            //string sql = $@"select c.Nome as Cliente,
            //                       CONVERT(VARCHAR(10),DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), 101) as [Data],
            //                       pe.Pacote,
            //                       pe.Valor
            //                from FC_PlanoEmbarque pe
            //             join FC_Cliente c on c.Id = pe.Cliente_Id
            //                {whereClause}
            //             order by DATETIMEFROMPARTS(pe.Ano, pe.Mes, pe.Dia, 0,0,0,0), c.Nome";

            string sql = $@"select * from tblPFSSaidaPronosticoSKU_Resumo2";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.PronosticoCSV>(sql).ToList();

                return cl;
            }
        }
        public IEnumerable<Pronostico> GetLinhacap()
        {

            string sql = @"select * from FC_LinhaCAP c  order by c.Linha_CAP";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Pronostico>(sql).ToList();

                return cl;
            }
        }

        public Pronostico Get(int id)
        {
            string sql = $@"select * from FC_Cliente c where c.Id = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Pronostico>(sql).FirstOrDefault();

                return cl;
            }
        }

        public IEnumerable<MeioTransporte> GetAllMeioTransporte()
        {
            string sql = $@"select m.Id, m.Nome, m.Icone
                            from FC_MeioTransporte m
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.MeioTransporte>(sql).ToList();

                return cl;
            }
        }

        public void Add(Pronostico c)
        {
            //string sql = $@"insert into FC_Cliente (Cliente_id,Nome,Linha_CAP,Mercado_CAP,Cor,Modal,Mercado_VF,Pais)
            //             values ((select max(Cliente_id)+1 from FC_Cliente),'{c.Customer_Name}','{c.Customer_Order}','{c.Customer_Order_Id}','{c.Customer_Grade}','{c.Modal}','{c.ContrMargin}', '{c.Comprimento}');";

            string sql = "";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(Pronostico c)
        {
            string sql = $@"delete FC_Cliente
                            where Id = {c.Customer_Order};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public bool ExistePlanoEmbarqueCliente(int cliente_id)
        {
            string sql = $@"select count(*) from FC_PlanoEmbarque
                            where Cliente_Id = {cliente_id};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var count = con.Query<int>(sql).FirstOrDefault();

                if (count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(Pronostico c)
        {
            string sql = $@"update FC_Cliente set Nome = '{c.Customer_Name}'
                            where Id = {c.Customer_Order};";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public IEnumerable<Pronostico> SP(string p1, int p2)
        {

            //dm_pro.dbo.spGerarProjecaoDespachosPorClientePeriodoVariavel '6000',12.3
            //Nome do botão: Calcular Forecast

            //string sql = "exec [spGerarProjecaoDespachosPorClientePeriodoVariavel] @Param1, @Param2, @Param3";
            //string sql = "exec [spPFSGerarSaidaPronosticoSKU]";

            string sql = "exec [spPFSGerarSaidaPronosticoSKU_Res] @Param1, @Param2";
           
            var values = new { Param1 = p1, Param2 = p2 };

            using (var con = new SqlConnection(base.GetConnection()))
            {
                
                SqlMapper.Settings.CommandTimeout = 0;
                var results1 = con.Query<PlanoEmbarque.Entities.Pronostico>(sql, values).ToList();
                //var results1 = con.Query<PlanoEmbarque.Entities.Pronostico>(sql).ToList();
               
               return results1;


                //var cl = con.Query<PlanoEmbarque.Entities.PlanoEmbarqueIR>(sql1).ToList();

                //return cl;


                //con.Execute(sql);

                //results1.ForEach(r => Console.WriteLine($"{r.OrderID} {r.Subtotal}"));

            }

            //var procedure = "[Sales by Year]";
            //var values = new { Beginning_Date = "2017.1.1", Ending_Date = "2017.12.31" };
            //var results = connection.Query(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            //results.ForEach(r => Console.WriteLine($"{r.OrderID} {r.Subtotal}"));
        }
    }
}
