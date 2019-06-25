using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;
using Projeto.DAL.Contracts;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.DAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString;

        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Usuario obj)
        {
            var query = "insert into usuario(Nome,Login,Senha) values (@Nome,@Login,@Senha)";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Usuario obj)
        {
            var query = "update usuario set Nome=@Nome, Login =@Login, Senha=@Senha where IdUsuario =@IdUsuario";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, obj);
            }
        }

        public void Remove(int id)
        {
            var query = "delete from usuario where IdUsuario = @IdUsuario";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, new { IdUsuario = id });
            }
        }

        public List<Usuario> GetALL()
        {
            var query = "select * from usuario";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Usuario>(query).ToList();
            }
        }

        public Usuario GetById(int id)
        {
            var query = "select * from usuario where idUsuario = @id";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Usuario>(query, new { IdUsuario = id }).SingleOrDefault();
            }
        }

        public bool HasLogin(string login)
        {
            var query = "select count(login) from usuario where Login = @Login";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<int>(query, new { Login = login }).SingleOrDefault() > 0;
            }
        }

        public Usuario Find(string login, string senha)
        {
            var query = "select * from usuario where login = @Login and senha = @Senha";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Usuario>(query, new { Login = login, Senha = senha }).FirstOrDefault();
            }
        }
    }
}
