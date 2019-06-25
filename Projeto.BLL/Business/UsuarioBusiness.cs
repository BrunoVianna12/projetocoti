using System;
using System.Collections.Generic;
using System.Text;
using Projeto.BLL.Contracts;
using Projeto.Entities;
using Projeto.DAL.Contracts;


namespace Projeto.BLL.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository repository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            this.repository = usuarioRepository;
        }

        public void Cadastrar(Usuario obj)
        {
            if (repository.HasLogin(obj.Login))
            {
                throw new Exception("Login já foi cadastrado. Tente outro.");
            }
            else
            {
                repository.Create(obj);
            }
        }

        public void Atualizar(Usuario obj)
        {
            repository.Update(obj);
        }

        public void Excluir(int id)
        {
            repository.Remove(id);
        }

        public List<Usuario> ConsultarTodas()
        {
            return repository.GetALL();
        }

        public Usuario ConsultarPorId(int id)
        {
            return repository.GetById(id);
        }

        public Usuario Obter(string login, string senha)
        {
            return repository.Find(login, senha);
        }
    }
}
