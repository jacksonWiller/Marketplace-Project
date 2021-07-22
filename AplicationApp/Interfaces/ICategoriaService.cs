using System.Threading.Tasks;
using AplicationApp.Dtos;

namespace AplicationApp.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AddCategoria(CategoriaDto model);
        Task<CategoriaDto> UpdateCategoria(int categoriaId, CategoriaDto model);
        Task<bool> DeleteCategoria(int categoriaId);
        Task<CategoriaDto[]> GetAllCategoriasAsync();
        Task<CategoriaDto[]> GetAllCategoriasAsyncByNome( string nome);
        Task<CategoriaDto> GetCategoriasAsyncById(int produtosId);
    }
}