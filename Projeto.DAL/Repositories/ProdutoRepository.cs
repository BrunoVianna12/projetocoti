using System;
using System.Collections.Generic;
using System.Text;
using Projeto.DAL.Contracts;
using Projeto.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.DAL.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string connectionString;

        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Produto obj)
        {
            string query = "INSERT INTO PRODUTO(NOME,PRECO,QUANTIDADE)" +
                "VALUES(@Nome, @Preco, @Quantidade)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, obj);
            }
        }

        public void Update(Produto obj)
        {
            var query = "UPDATE PRODUTO SET " +
                "NOME = @Nome, PRECO = @Preco, QUANTIDADE = @Quantidade " +
                "WHERE IDPRODUTO = @IdProduto";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, obj);
            }
        }

        public void Remove(int id)
        {
            var query = "DELETE FROM PRODUTO WHERE IdProduto = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, new { Id = id });
            }
        }

        public List<Produto> GetALL()
        {
            string query = "SELECT * FROM PRODUTO";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Produto>(query).ToList();
            }
        }

        public Produto GetById(int id)
        {
            var query = "select * from produto where idproduto = @IdProduto";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Produto>(query, new { IdProduto = id }).SingleOrDefault();
            }
        }

        public List<Produto> GetByNome(string nome)
        {
            var query = "select * from produto where nome like @Nome";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Produto>(query, new { Nome = $"%{nome}%" }).ToList();
            }
        }

        public List<Produto> GetByPreco(decimal precoIni, decimal precoFim)
        {
            var query = "select * from produto " +
                "where preco between @PrecoIni and @PrecoFim";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Produto>(query, new { PrecoIni = precoIni, PrecoFim = precoFim }).ToList();
            }
        }

    }
}
