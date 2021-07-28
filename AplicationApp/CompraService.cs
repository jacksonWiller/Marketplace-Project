using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;

namespace AplicationApp
{
    public class CompraService : ICompraService
    {
        private readonly ICompra _repositoryCompra;
        private readonly IGeneric<Compra> _repositoryGeneric;
        private readonly IMapper _mapper;
        public CompraService(IGeneric<Compra> repositoryGeneric,
                              ICompra repositoryCompra,
                              IMapper mapper)
        {
            _repositoryCompra = repositoryCompra;
            _repositoryGeneric = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<CompraDto> AddCompra(CompraDto model)
        {
            try
            {
                var compra = _mapper.Map<Compra>(model);

                await _repositoryGeneric.Add(compra);

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var compraRetorno = await _repositoryCompra.GetCompraAsyncById(compra.Id);

                    return _mapper.Map<CompraDto>(compraRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompraDto> UpdateCompra(int compraId, CompraDto model)
        {
            try
            {   
                var compra = await _repositoryCompra.GetCompraAsyncById(compraId);
                if (compra == null) return null;

                model.Id = compra.Id;

                _mapper.Map(model, compra);

                await _repositoryGeneric.Update(compra);                

                if (await _repositoryGeneric.SaveChangesAsync())
                {
                    var compraRetorno = await _repositoryCompra.GetCompraAsyncById(compra.Id);

                    return _mapper.Map<CompraDto>(compraRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCompra(int compraId)
        {
            try
        {
            var compra = await _repositoryCompra.GetCompraAsyncById(compraId);
            if (compra == null) throw new Exception("Compra para delete não encontrado.");

                await _repositoryGeneric.Delete(compra);
            return await _repositoryGeneric.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }
        public async Task<CompraDto[]> GetAllComprasAsync()
        {
            try
            {
                var compras = await _repositoryCompra.GetAllComprasAsync();
                if (compras == null) return null;

                var resultado = _mapper.Map<CompraDto[]>(compras);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CompraDto[]> GetAllComprasAsyncByNome(string nome)
        {
            try
            {
                var compra = await _repositoryCompra.GetAllCompraAsyncByNome(nome);
                if (compra == null) return null;

                var resultado = _mapper.Map<CompraDto[]>(compra);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompraDto> GetCompraAsyncById(int compraId)
        {
            try
            {
                var compra = await _repositoryCompra.GetCompraAsyncById(compraId);
                if (compra == null) return null;

                var resultado = _mapper.Map<CompraDto>(compra);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}