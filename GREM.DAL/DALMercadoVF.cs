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
    public class DALMercadoVF : ConnectionFactory, IDALMercadoVF
    {

        public DALMercadoVF()
        {
        }

        public IEnumerable<MercadoVF> GetAll()
        {

            string sql = $@"select c.MercadoVFId,c.Mercado_VF,mc.MercadoCAPId,mc.Mercado_CAP from FC_MercadoVF c 
                             inner join FC_MercadoCAP mc on c.MercadoCAPId = mc.MercadoCAPId 
                             order by c.MercadoVFId";

            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.MercadoVF>(sql).ToList();

                return cl;
            }
        }
        public MercadoVF Get(int id)
        {
            //string sql = $@"select * from FC_LinhaCAP c where c.LinhaCAPId = {id}";
            string sql = $@"select c.MercadoVFId,c.Mercado_VF,mc.MercadoCAPId,mc.Mercado_CAP from FC_MercadoVF c 
                             inner join FC_MercadoCAP mc on c.MercadoCAPId = mc.MercadoCAPId 
                             where c.MercadoVFId = {id} 
							 order by c.MercadoVFId ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.MercadoVF>(sql).FirstOrDefault();

                return cl;
            }
        }

         public void Add(MercadoVF c)
        {
            string sql = $@"SET IDENTITY_INSERT [FC_MercadoVF] ON;
                            insert into[FC_MercadoVF] (MercadoVFId, Mercado_VF, MercadoCAPId)
                            values((select max(MercadoVFId) + 1 from[FC_MercadoVF]),'{c.Mercado_VF}','{c.Mercado_CAP}');";
            

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(MercadoVF c)
        {
            string sql = $@"delete FC_MercadoVF
                            where MercadoVFId = {c.MercadoVFId};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }



        public void Update(MercadoVF c)
        {
            string sql1 = $@"update FC_MercadoVF set Nome = '{c.Mercado_VF}'
                            where Id = {c.MercadoVFId};";

            string sql = $@"UPDATE[dbo].[FC_MercadoVF]
                                 SET[Mercado_VF]    = '{c.Mercado_VF}',
                                    [MercadoCAPId]  = '{c.Mercado_CAP}'
                                 WHERE MercadoVFId  =  {c.MercadoVFId}";

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
