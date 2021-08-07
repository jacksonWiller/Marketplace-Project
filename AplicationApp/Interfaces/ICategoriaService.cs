using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;

namespace AplicationApp.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AddCategoria(CategoriaDto model);
        Task<CategoriaDto> UpdateCategoria(Guid categoriaId, CategoriaDto model);
        Task<bool> DeleteCategoria(Guid categoriaId);
        Task<CategoriaDto[]> GetAllCategoriasAsync();
        Task<CategoriaDto[]> GetAllCategoriasAsyncByNome( string nome);
        Task<CategoriaDto> GetCategoriasAsyncById(Guid produtosId);
    }
}