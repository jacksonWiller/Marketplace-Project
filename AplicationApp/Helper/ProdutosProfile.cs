using AplicationApp.Dtos;
using AutoMapper;
using Domain.Entity;

namespace AplicationApp.Helper
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
             CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}