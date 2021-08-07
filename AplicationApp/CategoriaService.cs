using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;

namespace AplicationApp
{
    public class CategoriaService : ICategoriaService 
    {
        private readonly ICategoria _repositoryCategoria;
        private readonly IGeneric<Categoria> _repositoryGeneric;
        private readonly IMapper _mapper;
        public CategoriaService(IGeneric<Categoria> repositoryGeneric,
                              ICategoria repositoryCategoria,
                              IMapper mapper)
        {
            _repositoryCategoria = repositoryCategoria;
            _repositoryGeneric = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> AddCategoria(CategoriaDto model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);

                await _repositoryGeneric.Add(categoria);

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var categoriaRetorno = await _repositoryCategoria.GetCategoriasAsyncById(categoria.Id);

                    return _mapper.Map<CategoriaDto>(categoriaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> UpdateCategoria(Guid categoriaId, CategoriaDto model)
        {
            try
            {   
                var categoria = await _repositoryCategoria.GetCategoriasAsyncById(categoriaId);
                if (categoria == null) return null;

                model.Id = categoria.Id;

                _mapper.Map(model, categoria);

                await _repositoryGeneric.Update(categoria);                

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var eventoRetorno = await _repositoryCategoria.GetCategoriasAsyncById(categoria.Id);

                    return _mapper.Map<CategoriaDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCategoria(Guid categoriaId)
        {
            try
            {
                var categoria = await _repositoryCategoria.GetCategoriasAsyncById(categoriaId);
                if (categoria == null) throw new Exception("Evento para delete não encontrado.");

                    await _repositoryGeneric.Delete(categoria);
                return await _repositoryGeneric.SaveChangesAsync();
            }
                catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
         public async Task<CategoriaDto[]> GetAllCategoriasAsync()
        {
            try
            {
                var categoria = await _repositoryCategoria.GetAllCategoriasAsync();
                if (categoria == null) return null;

                var resultado = _mapper.Map<CategoriaDto[]>(categoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoriaDto[]> GetAllCategoriasAsyncByNome(string nome)
        {
            try
            {
                var categoria = await _repositoryCategoria.GetAllCategoriasAsyncByNome(nome);
                if (categoria == null) return null;

                var resultado = _mapper.Map<CategoriaDto[]>(categoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> GetCategoriasAsyncById(Guid categoriaId)
        {
            try
            {
                var categoria = await _repositoryCategoria.GetCategoriasAsyncById(categoriaId);
                if (categoria == null) return null;

                var resultado = _mapper.Map<CategoriaDto>(categoria);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}