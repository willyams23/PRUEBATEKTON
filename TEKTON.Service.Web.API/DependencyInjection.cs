using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TEKTON.Application.MapperProfiles;
using TEKTON.Infrastructure.Data.Context;
using TEKTON.Service.SeedWork;

namespace TEKTON.Service.Web.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            InjectionsSettings.ConfigureServiceCrossCutting(services);

           
            services.AddHttpClient("WebApiDescuento", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5220/");
            });

            return services;
        }
    }
}
