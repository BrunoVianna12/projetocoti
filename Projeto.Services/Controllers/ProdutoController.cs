using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Entities;
using Projeto.BLL.Contracts;
using Projeto.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Projeto.Services.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoBusiness business;

        public ProdutoController(IProdutoBusiness business)
        {
            this.business = business;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProdutoCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(model);
                    business.Cadastrar(produto);
                    return Ok($"Produto {produto.Nome}, cadastrado com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProdutoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(model);
                    business.Atualizar(produto);
                    return Ok($"Produto {produto.Nome}, atualizado com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var produto = business.ConsultarPorId(id);
                if (produto != null)
                {
                    business.Excluir(id);
                    return Ok($"Produto excluído com sucesso");
                }
                else
                {
                    return BadRequest("Produto não encontrado");
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                
            }
        }

        [HttpGet]
        public IActionResult ConsultarTodos()
        {
            try
            {
                List<ProdutoConsultaViewModel> lista = Mapper.Map<List<ProdutoConsultaViewModel>>(business.ConsultarTodas());
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                
            }
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            try
            {
                ProdutoConsultaViewModel model = Mapper.Map<ProdutoConsultaViewModel>(business.ConsultarPorId(id));
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
    }
}