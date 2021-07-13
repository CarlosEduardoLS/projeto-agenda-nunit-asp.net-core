using Agenda.Domain;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }


        public void Adicionar(Contato contato)
        {
            using (var con = new NpgsqlConnection(_strCon))
            {
                con.Execute("INSERT INTO contato (id, nome) VALUES (@Id, @Nome);", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new NpgsqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("SELECT id, nome FROM contato c WHERE c.id = @Id", new { Id = id });
            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new NpgsqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("SELECT id, nome FROM contato").ToList();
            }
            return contatos;
        }
    }
}
