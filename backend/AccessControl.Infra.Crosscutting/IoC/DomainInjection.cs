using AccessControl.Infra.CrossCutting.Handlers;
using AccessControl.Infra.CrossCutting.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.IoC
{
    public class DomainInjection
    {
        public static void Initialize(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }

        public static void InitializeCommands(IServiceCollection services)
        {
            
        }
    }
}
