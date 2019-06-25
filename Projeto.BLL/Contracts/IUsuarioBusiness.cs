using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;


namespace Projeto.BLL.Contracts
{
    public interface IUsuarioBusiness : IBaseBusiness<Usuario>
    {
        Usuario Obter(string login, string senha);

    }
}
