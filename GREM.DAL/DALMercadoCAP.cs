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
    public class DALMercadoCAP : ConnectionFactory, IDALMercadoCAP
    {

        public DALMercadoCAP()
        {
        }

        public IEnumerable<MercadoCAP> GetAll()
        {

            string sql = $@"select * from FC_MercadoCAP";

            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.MercadoCAP>(sql).ToList();

                return cl;
            }
        }
        public MercadoCAP Get(int id)
        {
            //string sql = $@"select * from FC_MercadoCAP c where c.MercadoCAPId = {id}";
            string sql = $@"select * from FC_MercadoCAP 
                            where MercadoCAPId = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.MercadoCAP>(sql).FirstOrDefault();

                return cl;
            }
        }

         public void Add(MercadoCAP c)
        {
            //string sql = $@"insert into[FC_MercadoCAP] (MercadoCAPId, Mercado_CAP)
            //                values((select max(MercadoCAPId) + 1 from[FC_MercadoCAP]),'{c.Mercado_CAP}');";

            string sql = $@"insert into[FC_MercadoCAP] (Mercado_CAP)
                            values('{c.Mercado_CAP}');";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(MercadoCAP c)
        {
            string sql = $@"delete FC_MercadoCAP where MercadoCAPId = {c.MercadoCAPId};";

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

        public void Update(MercadoCAP c)
        {
            string sql1 = $@"update FC_MercadoCAP set Nome = '{c.Mercado_CAP}'
                            where Id = {c.MercadoCAPId};";

            string sql = $@"UPDATE[dbo].[FC_MercadoCAP]
                                 SET[Mercado_CAP]    = '{c.Mercado_CAP}'
                                 WHERE MercadoCAPId  = {c.MercadoCAPId}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }
    }
}
