using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Repository.Breeds;
using SIG_VETERINARIA.Repository.Categories;
using SIG_VETERINARIA.Repository.Clients;
using SIG_VETERINARIA.Repository.Consults;
using SIG_VETERINARIA.Repository.Diagnosticos;
using SIG_VETERINARIA.Repository.Exams;
using SIG_VETERINARIA.Repository.Patients;
using SIG_VETERINARIA.Repository.Products;
using SIG_VETERINARIA.Repository.Recetas;
using SIG_VETERINARIA.Repository.Species;
using SIG_VETERINARIA.Repository.Tratamientos;
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
            services.AddScoped<IConsultRepository, ConsultRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRespository, ProductRepository>();
            services.AddScoped<ITratamientosRepository, TratamientosRepository>();
            services.AddScoped<IProductsTratamiento, ProductTratamientoRepository>();
            services.AddScoped<IRecetasRepository, RecetasRepository>();
            return services;
        }

    }
}
