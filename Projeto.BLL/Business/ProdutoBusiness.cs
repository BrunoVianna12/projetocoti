using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;
using Projeto.DAL.Contracts;
using Projeto.BLL.Contracts;

namespace Projeto.BLL.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private IProdutoRepository repository;

        public ProdutoBusiness(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        public void Cadastrar(Produto obj)
        {
            repository.Create(obj);
        }

        public void Atualizar(Produto obj)
        {
            repository.Update(obj);
        }

        public void Excluir(int id)
        {
            repository.Remove(id);
        }

        public List<Produto> ConsultarTodas()
        {
            return repository.GetALL(); 
        }

        public Produto ConsultarPorId(int id)
        {
            return repository.GetById(id);
        }

        public List<Produto> ConsultarPorNome(string nome)
        {
            return repository.GetByNome(nome);
        }

        public List<Produto> ConsultarPorPreco(decimal precoIni, decimal precoFim)
        {
            return repository.GetByPreco(precoIni, precoFim);
        }

    }
}
