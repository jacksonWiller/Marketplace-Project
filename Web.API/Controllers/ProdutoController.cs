using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Infrastructure.Repository;
using Infrastructure.Repository.Gererics;
using AplicationApp.Interfaces;
using AplicationApp.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync();
                if (produtos == null) return NoContent();
                return Ok(produtos);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter so produtos. Erro: {exeption.Message}");
            }
        }
        [HttpGet("{nome}/nome")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var produto = await _produtoService.GetAllProdutosAsyncByNome(nome);

                return Ok(produto);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter o produto por nome. Erro: {exeption.Message}");
            }
        }
        [HttpGet("{ProdutosId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid ProdutosId)
        {
            try
            {
                var produto = await _produtoService.GetProdutoAsyncById(ProdutosId);

                return Ok(produto);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter o Produtos por Id. Erro: {exeption.Message}");
            }
        }
         
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ProdutoDto model)
        {
            try
            {
                // Produto produto;
                var retorno = await _produtoService.AddProduto(model);
               
                return Ok(retorno);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar adicionar o produto. Erro: {exeption.Message}");
            }
        }
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(Guid id, ProdutoDto model)
        {
            try
            {
                var evento = await _produtoService.UpdateProduto(id, model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar atualizar o produto. Erro: {exeption.Message}");
            }
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoAsyncById(id);
                if (produto == null) return NoContent();

                await _produtoService.DeleteProduto(id);
                return Ok(new { message = "Deletado" });              
                    //    : throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar remover o produto. Erro: {exeption.Message}");
            }
        }
    
    }
}