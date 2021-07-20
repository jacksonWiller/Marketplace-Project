using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;

namespace AplicationApp
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryGeneric _repositoryGeneric;
        private readonly IMapper _mapper;
        public ProdutoService(IRepositoryGeneric repositoryGeneric,
                              IRepositoryProduto repositoryProduto,
                              IMapper mapper)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryGeneric = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoDto model)
        {
            try
            {
                var evento = _mapper.Map<Produto>(model);

                _repositoryGeneric.Add<Produto>(evento);

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var eventoRetorno = await _repositoryProduto.GetProdutoAsyncById(evento.Id);

                    return _mapper.Map<ProdutoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model)
        {
            try
            {   
                var produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
                if (produto == null) return null;

                model.Id = produto.Id;

                _mapper.Map(model, produto);

                _repositoryGeneric.Update<Produto>(produto);                

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var eventoRetorno = await _repositoryProduto.GetProdutoAsyncById(produto.Id);

                    return _mapper.Map<ProdutoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
        {
            var produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
            if (produto == null) throw new Exception("Evento para delete não encontrado.");

            _repositoryGeneric.Delete<Produto>(produto);
            return await _repositoryGeneric.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }
        public async Task<ProdutoDto[]> GetAllProdutosAsync()
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsync();
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDto[]> GetAllProdutosAsyncByNome(string nome)
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsyncByNome(nome);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoAsyncById(int produtosId)
        {
            try
            {
                var produto = await _repositoryProduto.GetProdutoAsyncById(produtosId);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}