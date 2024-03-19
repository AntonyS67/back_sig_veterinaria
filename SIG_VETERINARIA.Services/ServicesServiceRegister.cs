using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.Services.Specie;
using SIG_VETERINARIA.Services.User;

namespace SIG_VETERINARIA.Services
{
    public static class ServicesServiceRegister
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISpecieService, SpecieService>();
            return services;
        }

    }
}
