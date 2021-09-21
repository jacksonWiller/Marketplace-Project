using System.Threading.Tasks;
using Domain.Identity;
using Id.Overview.Mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicationApp.Dtos;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using AutoMapper.Configuration;
using System.Linq;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
   
    // private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    // private readonly IMapper _mapper;

    public AccountController(
                            // IConfiguration config,
                          UserManager<User> userManager,
                          SignInManager<User> signInManager
                        //   IMapper mapper
                        )
    {
      _signInManager = signInManager;
    //   _mapper = mapper;
    //   _config = config;
      _userManager = userManager;
    }

    [HttpGet("GetUser")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUser()
    {
        return Ok(new RegisterDto());
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
        try
        {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return Created("GetUser", user);
                }
        
            return BadRequest(result.Errors);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
        }
    }

    [HttpPost("Login")]
    [AllowAnonymous]
        public async Task<IActionResult> Login ([FromForm] LoginDto model)
        {
          try
          {
            
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Ok("OK");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida");
                }
            }

            return View(model);
        }
        catch (System.Exception ex)
          {
              return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
          }

        }

    }
        
}