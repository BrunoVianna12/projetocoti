using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;

namespace Projeto.DAL.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        bool HasLogin(string login);
        Usuario Find(string login, string senha);
    }
}
