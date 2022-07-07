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
    public class DALLinhaCAP : ConnectionFactory, IDALLinhaCAP
    {

        public DALLinhaCAP()
        {
        }

        public IEnumerable<LinhaCAP> GetAll()
        {

            string sql = $@"select c.LinhaCAPId,c.Linha_CAP,mc.MercadoCAPId,mc.Mercado_CAP,mvf.MercadoVFId,mvf.Mercado_VF from FC_LinhaCAP c 
                             inner join FC_MercadoCAP mc on c.MercadoCAPId = mc.MercadoCAPId 
                             inner join FC_MercadoVF mvf on c.MercadoVFId = mvf.MercadoVFId 
                             order by c.Linha_CAP";

            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.LinhaCAP>(sql).ToList();

                return cl;
            }
        }
        public LinhaCAP Get(int id)
        {
            //string sql = $@"select * from FC_LinhaCAP c where c.LinhaCAPId = {id}";
            string sql = $@"select c.LinhaCAPId,c.Linha_CAP,mc.MercadoCAPId,mc.Mercado_CAP,mvf.MercadoVFId,mvf.Mercado_VF from FC_LinhaCAP c 
                            inner join FC_MercadoCAP mc on c.MercadoCAPId = mc.MercadoCAPId 
                            inner join FC_MercadoVF mvf on c.MercadoVFId = mvf.MercadoVFId 
                            where c.LinhaCAPId = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.LinhaCAP>(sql).FirstOrDefault();

                return cl;
            }
        }

         public void Add(LinhaCAP c)
        {
            string sql = $@"insert into[FC_LinhaCAP] (LinhaCAPId, Linha_CAP, MercadoCAPId, MercadoVFId)
                            values((select max(LinhaCAPId) + 1 from[FC_LinhaCAP]),'{c.Linha_CAP}','{c.MercadoCAPId}','{c.MercadoVFId}');";
            

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(LinhaCAP c)
        {
            string sql = $@"delete FC_Cliente
                            where Id = {c.LinhaCAPId};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Update(LinhaCAP c)
        {
            string sql1 = $@"update FC_LinhaCAP set Nome = '{c.Linha_CAP}'
                            where Id = {c.LinhaCAPId};";

            string sql = $@"UPDATE[dbo].[FC_LinhaCAP]
                                 SET[Linha_CAP]    = '{c.Linha_CAP}',
                                    [MercadoCAPId] = '{c.MercadoCAPId}',
                                    [MercadoVFId]  = '{c.MercadoVFId}'
                                 WHERE LinhaCAPId  = {c.LinhaCAPId}";

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
    }
}
