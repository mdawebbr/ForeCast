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
    public class DALParametros : ConnectionFactory, IDALParametros
    {
        public void Add(Parametros obj)
        {
            throw new NotImplementedException();
        }
        public Parametros Get(int id)
        {
            string sql = $"SELECT * FROM FC_Parametro where Id = {id}";
            using (var con = new SqlConnection(base.GetConnection()))
                return con.Query<Parametros>(sql).FirstOrDefault();
        }


        public IEnumerable<Parametros> GetAll()
        {
            string sql = "SELECT * FROM FC_Parametro";
            using (var con = new SqlConnection(base.GetConnection()))
                return con.Query<Parametros>(sql).ToList();
        }
        

        public void Remove(Parametros obj)
        {
            throw new NotImplementedException();
        }
        
        

        public void Update(Parametros obj)
        {
            string sql = $"UPDATE Parametro SET Valor = '{obj.Valor}' WHERE Chave = '{obj.Chave}'";
            using(var con = new SqlConnection(base.GetConnection()))
            {
                using(var trans = new TransactionScope())
                {
                    con.Open();
                    con.Execute(sql);
                    trans.Complete();
                }
            }
        }
    }
}
