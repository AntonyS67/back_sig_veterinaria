using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Application.Breed;
using SIG_VETERINARIA.Application.Categories;
using SIG_VETERINARIA.Application.Clients;
using SIG_VETERINARIA.Application.Consults;
using SIG_VETERINARIA.Application.Diagnosticos;
using SIG_VETERINARIA.Application.Exams;
using SIG_VETERINARIA.Application.Patients;
using SIG_VETERINARIA.Application.Products;
using SIG_VETERINARIA.Application.Specie;
using SIG_VETERINARIA.Application.User;

namespace SIG_VETERINARIA.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ISpecieApplication, SpecieApplication>();
            services.AddScoped<IBreedApplication, BreedApplication>();
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IPatientApplication, PatientApplication>();
            services.AddScoped<IConsultApplication, ConsultApplication>();
            services.AddScoped<IExamApplication, ExamApplication>();
            services.AddScoped<IDiagnosticoApplication, DiagnosticoApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            return services;
        }

    }
}
