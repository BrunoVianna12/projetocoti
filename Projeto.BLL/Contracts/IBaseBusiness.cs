using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.BLL.Contracts
{
    public interface IBaseBusiness<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(int id);

        List<TEntity> ConsultarTodas();
        TEntity ConsultarPorId(int id);
    }
}
