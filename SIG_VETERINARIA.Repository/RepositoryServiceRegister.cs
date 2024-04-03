﻿using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Repository.Breeds;
using SIG_VETERINARIA.Repository.Clients;
using SIG_VETERINARIA.Repository.Patients;
using SIG_VETERINARIA.Repository.Species;
using SIG_VETERINARIA.Repository.User;

namespace SIG_VETERINARIA.Repository
{
    public static class RepositoryServiceRegister
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpecieRepository, SpecieRepository>();
            services.AddScoped<IBreedRepository, BreedRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            return services;
        }

    }
}
