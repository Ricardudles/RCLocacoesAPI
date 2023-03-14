using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Application.Mappings;
using RCLocacoes.Application.Services;
using RCLocacoes.Application.Validator;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Domain.Interfaces;
using RCLocacoes.Infra.Data;
using RCLocacoes.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Ioc
{
    public static class InjectorBootStrapper
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<AddressProfile>();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            //APP
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();

            //DATA
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //VALIDATOR
            services.AddScoped<IValidator<AddressDto>, AddressValidator>();
            services.AddScoped<IValidator<UserDto>, UserValidator>();

        }
    }
}
