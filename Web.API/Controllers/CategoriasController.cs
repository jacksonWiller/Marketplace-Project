using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/Produtos/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _categoriaService.GetAllCategoriasAsync();
                if (produtos == null) return NoContent();
                return Ok(produtos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Banco Dados Falhou {ex.Message}");
            }
        }
        [HttpGet("{nome}/nome")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var categoria = await _categoriaService.GetAllCategoriasAsyncByNome(nome);

                return Ok(categoria);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                "Banco Dados Falhou");
            }
        }
        [HttpGet("{CategoriaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int CategoriaId)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriasAsyncById(CategoriaId);

                return Ok(categoria);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                "Banco Dados Falhou");
            }
        }
         
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CategoriaDto model)
        {
            try
            {
                // Produto produto;
                var retorno = await _categoriaService.AddCategoria(model);
               
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, CategoriaDto model)
        {
            try
            {
                var evento = await _categoriaService.UpdateCategoria(id, model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _categoriaService.GetCategoriasAsyncById(id);
                if (produto == null) return NoContent();

                return await _categoriaService.DeleteCategoria(id) 
                       ? Ok(new { message = "Deletado" }) 
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}
