using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;
using Projeto.DAL;

namespace Projeto.BLL.Contracts
{
    public interface IProdutoBusiness : IBaseBusiness<Produto>
    {
        List<Produto> ConsultarPorNome(string nome);
        List<Produto> ConsultarPorPreco(decimal precoIni, decimal precoFim);
    }
}
