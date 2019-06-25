using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.DAL.Contracts
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Remove(int id);

        List<TEntity> GetALL();
        TEntity GetById(int id);

    }
}
