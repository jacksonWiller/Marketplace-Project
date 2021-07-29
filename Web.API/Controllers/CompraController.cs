using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicationApp.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        
        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var compras = await _compraService.GetAllComprasAsync();
                if (compras == null) return NoContent();
                return Ok(compras);
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
                var categoria = await _compraService.GetAllComprasAsyncByNome(nome);

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
                var categoria = await _compraService.GetCompraAsyncById(CategoriaId);
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
        public async Task<IActionResult> Post(CompraDto model)
        {
            try
            {
                // Produto produto;
                var retorno = await _compraService.AddCompra(model);
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
        public async Task<IActionResult> Put(int id, CompraDto model)
        {
            try
            {
                var compra = await _compraService.UpdateCompra(id, model);
                if (compra == null) return NoContent();

                return Ok(compra);
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
                var compra = await _compraService.GetCompraAsyncById(id);
                if (compra == null) return NoContent();

                return await _compraService.DeleteCompra(id) 
                       ? Ok(new { message = "Deletado" }) 
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Compra.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar compra. Erro: {ex.Message}");
            }
        }
    }
}