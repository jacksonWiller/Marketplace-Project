using System;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface ICategoria
    {
        //PRODUTOS
        Task<Categoria[]> GetAllCategoriasAsync();
        Task<Categoria[]> GetAllCategoriasAsyncByNome( string nome);
        Task<Categoria> GetCategoriasAsyncById(Guid CategoriaId);
    }
}