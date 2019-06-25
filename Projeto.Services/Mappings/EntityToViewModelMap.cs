using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Entities;
using AutoMapper;
using Projeto.Services.Models;

namespace Projeto.Services.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Produto, ProdutoConsultaViewModel>()
                .AfterMap((src, dest)
                => dest.Total = src.Preco * src.Quantidade);
        }
    }
}
