using System;
using AplicationApp;
using AplicationApp.Interfaces;
using Domain.Identity;
using Domain.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Gererics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProAgil.Repository;

namespace Web.API.Configurations
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
           

        }
    }
}