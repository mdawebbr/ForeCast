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
    public class DALQuadrimestre : ConnectionFactory, IDALQuadrimestre
    {

        public DALQuadrimestre()
        {
        }
        public IEnumerable<Quadrimestre> GetAll()
        {
            string sql = @"select c.Id,	c.Nome, c.Cor
                            from FC_Cliente c
                            order by c.Nome
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Quadrimestre>(sql).ToList();

                return cl;
            }
        }

        public Quadrimestre Get(int id)
        {
            string sql = $@"select c.Id,	c.Nome, c.Cor
                            from FC_Cliente c
                            where c.Id = {id}
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Quadrimestre>(sql).FirstOrDefault();

                return cl;
            }
        }

        IEnumerable<MeioTransporte> IDALQuadrimestre.GetAllMeioTransporte()
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

        public void Add(Quadrimestre q)
        {
            string sql = $@"insert into Cliente (Nome, Cor)
	                        values ('{q.Id}', null);
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Remove(Quadrimestre q)
        {
            string sql = $@"delete Cliente
                            where Id = {q.Id};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        bool IDALQuadrimestre.ExistePlanoEmbarqueCliente(int cliente_id)
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

        public void Update(Quadrimestre q)
        {
            string sql = $@"update Cliente set Nome = '{q.Id}'
                            where Id = {q.Id};
                    ";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }


    }
}
