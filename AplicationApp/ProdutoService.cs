using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Repository;


namespace AplicationApp
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProduto _repositoryProduto;
        private readonly IGeneric<Produto> _repositoryGenericProdutos;
        private readonly IMapper _mapper;
        public ProdutoService(IGeneric<Produto> repositoryGeneric,
                              IProduto repositoryProduto,
                              IMapper mapper)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryGenericProdutos = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                await _repositoryGenericProdutos.Add(produto);

                if (await _repositoryGenericProdutos.SaveChangesAsync())
                {
                    var produtoRetorno = await _repositoryProduto.GetProdutoAsyncById(produto.Id);

                    return _mapper.Map<ProdutoDto>(produtoRetorno);
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

                await _repositoryGenericProdutos.Update(produto);                

                if (await _repositoryGenericProdutos.SaveChangesAsync())
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

                await _repositoryGenericProdutos.Delete(produto);
            return await _repositoryGenericProdutos.SaveChangesAsync();
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