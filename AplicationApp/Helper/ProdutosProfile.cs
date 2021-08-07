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
             CreateMap<Categoria, CategoriaDto>().ReverseMap();
             CreateMap<ProdutosCategorias, ProdutosCategoriasDto>().ReverseMap();
             CreateMap<Compra, CompraDto>().ReverseMap(); 
             CreateMap<ItemPedido, ItemPedidoDto>().ReverseMap(); 
             
        }
    }
}