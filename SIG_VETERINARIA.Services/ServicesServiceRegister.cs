using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.Services.Breed;
using SIG_VETERINARIA.Services.Categories;
using SIG_VETERINARIA.Services.Clients;
using SIG_VETERINARIA.Services.Common;
using SIG_VETERINARIA.Services.Consults;
using SIG_VETERINARIA.Services.Diagnosticos;
using SIG_VETERINARIA.Services.Exams;
using SIG_VETERINARIA.Services.Patients;
using SIG_VETERINARIA.Services.Products;
using SIG_VETERINARIA.Services.Recetas;
using SIG_VETERINARIA.Services.Specie;
using SIG_VETERINARIA.Services.Tratamientos;
using SIG_VETERINARIA.Services.User;

namespace SIG_VETERINARIA.Services
{
    public static class ServicesServiceRegister
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISpecieService, SpecieService>();
            services.AddScoped<IBreedService, BreedService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultService, ConsultService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IDiagnosticoService, DiagnosticosService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITratamientosService, TratamientoService>();
            services.AddScoped<IProductsTratamientoService, ProductsTratamientoService>();
            services.AddScoped<IRecetasService, RecetasService>();
            return services;
        }

    }
}
