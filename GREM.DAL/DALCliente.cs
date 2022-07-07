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
    public class DALCliente : ConnectionFactory, IDALCliente
    {

        public DALCliente()
        {
        }

        public IEnumerable<Cliente> GetAll()
        {

            string sql = @"select * from FC_Cliente c  order by c.Nome";
            
            //GREM.DAL.ConnectionFactory.cs
            using (var con = new SqlConnection(base.GetConnection())) { 
                var cl = con.Query<PlanoEmbarque.Entities.Cliente>(sql).ToList();

                return cl;
            }
        }
        public IEnumerable<Cliente> GetLinhacap()
        {

            string sql = @"select * from FC_LinhaCAP c  order by c.Linha_CAP";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Cliente>(sql).ToList();

                return cl;
            }
        }

        public Cliente Get(int id)
        {
            string sql = $@"select * from FC_Cliente c where c.Cliente_id = {id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                var cl = con.Query<PlanoEmbarque.Entities.Cliente>(sql).FirstOrDefault();

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

        public void Add(Cliente c)
        {
            //Cliente_id, Nome,    Linha_CAP, Mercado_CAP, Cor, Modal,   Mercado_VF, Pais,    MercadoCAPId, MercadoVFId, LinhaCAPId, percentual
            string sql = $@"insert into FC_Cliente (Cliente_id,Nome,Linha_CAP,Mercado_CAP,Cor,Modal,Mercado_VF,Pais)
	                        values ((select max(Cliente_id)+1 from FC_Cliente),'{c.Nome}','{c.Linha_CAP}','{c.Mercado_CAP}','{c.Cor}','{c.Modal}','{c.Mercado_VF}', '{c.Pais}');";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }
        public  void Remove(Cliente c)
        {
            string sql = $@"delete FC_Cliente
                            where cliente_id = {c.Cliente_id}";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public void Update(Cliente c)
        {
            string sql = $@"update FC_Cliente 
                            set Nome = '{c.Nome}',
                            Linha_CAP = '{c.Linha_CAP}',
                            Mercado_CAP = '{c.Mercado_CAP}',
                            Cor = '{c.Cor}',
                            Modal = '{c.Modal}',
                            Mercado_VF = '{c.Mercado_VF}',
                            Pais = '{c.Pais}',
                            MercadoCAPId = '{c.MercadoCAPId}',
                            MercadoVFId = '{c.MercadoVFId}',
                            LinhaCAPId = '{c.LinhaCAPId}'
                        where Cliente_Id = {c.Cliente_id};";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql);
            }
        }

        public bool ExistePlanoEmbarqueCliente(int cliente_id)
        {
            string sql = $@"select count(*) from FC_PlanoEmbarque
                            where Cliente_Id = {cliente_id};";

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
