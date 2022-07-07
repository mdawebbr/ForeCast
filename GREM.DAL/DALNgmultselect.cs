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
    public class DALNgmultselect : ConnectionFactory, IDALNgmultselect
    {

        public DALNgmultselect()
        {
        }

        public IEnumerable<Ngmultselect> GetAll()
        {

            //string sql1 = $@"select * from FC_ClienteMesAno";

            string sql = $@"exec [spObterAnosMesesClientes]";

            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.Ngmultselect>(sql).ToList();

                return cl;
            }
        }
        public Ngmultselect Get(int id)
        {
            //string sql = $@"select * from FC_MercadoCAP c where c.MercadoCAPId = {id}";
            string sql = $@"select * from FC_ClienteMesAno 
                            where Cliente_Id = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Ngmultselect>(sql).FirstOrDefault();

                return cl;
            }
        }

         public void Add(Ngmultselect c)
        {
            string sql = $@"insert into[FC_ClienteMesAno] (Cliente_Id, Mes, Ano)
                            values('{c.Cliente_Id}','{c.Meses}','{c.Ano}');";
            

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(Ngmultselect c)
        {
            string sql = $@"delete FC_ClienteMesAno
                            where Cliente_Id = {c.Cliente_Id} and 
                                  Ano = {c.Ano};";

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

        public void Update(Ngmultselect c)
        {
            //string sql1 = $@"update FC_ClienteMesAno set Cliente_Id = '{c.Cliente_Id}'
            //                where Id = {c.Cliente_Id};";

            string sql = $@"UPDATE[dbo].[FC_ClienteMesAno]
                                 SET[Cliente_Id] = '{c.Cliente_Id}',
                                    [Nome_Cliente] '{c.Nome_Cliente}',
                                    [Mes]        = '{c.Meses}',
                                    [Ano]        = '{c.Ano}', 
                                 WHERE Cliente_Id  = {c.Cliente_Id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

    }
}
