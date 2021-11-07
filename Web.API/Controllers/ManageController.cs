using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicationApp.Dtos;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using AutoMapper.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ManageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;  
    }
}