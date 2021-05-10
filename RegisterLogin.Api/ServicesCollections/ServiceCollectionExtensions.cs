using AutoMapper;
using Dapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RegisterLogin.Api;
using RegisterLogin.Api.Busines;
using RegisterLogin.Api.Data.Repositories;
using RegisterLogin.Api.Domain.Models.Request;
using RegisterLogin.Api.Validators;
using System;
using System.IO;
using System.Reflection;
using static RegisterLogin.API.Filters.ValidateModelFilter;

namespace RegisterLogin.API.ServicesCollections
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelAttribute));}).AddFluentValidation();
            services.AddScoped<IValidator<LoginRequest>, LoginValidator>();
            services.AddScoped<IValidator<LoginUpdateRequest>, LoginUpdateValidator>();
                       
            return services;
        }

        public static IServiceCollection SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(configuration =>// arrowfunction
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RegisterLogin API",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"; //
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                configuration.IncludeXmlComments(xmlPath);// configuration ou options
            });
            return services;
        }

        public static IServiceCollection DapperServices(this IServiceCollection services)
        {
            services.AddScoped<LoginRepository>(); //DAPPER responsavel pelo mapeapento dos insert 
            
            
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            return services;
        }

        public static IServiceCollection BusinessServices(this IServiceCollection services)
        {
            services.AddTransient<LoginBL>();

            return services;
        }

        public static IServiceCollection RepositoryServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(new Action<IMapperConfigurationExpression>(x => { }), typeof(Startup));
            return services;
        }
    }
}


