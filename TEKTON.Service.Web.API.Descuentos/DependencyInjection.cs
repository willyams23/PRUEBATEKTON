using TEKTON.Service.Web.API.Descuentos.Service;

namespace TEKTON.Service.Web.API.Descuentos
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            InjectionsSettings.ConfigureServiceCrossCutting(services);

            return services;
        }
    }
}
