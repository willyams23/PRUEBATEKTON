using Microsoft.Extensions.DependencyInjection;
using TEKTON.Application.Contracts;
using TEKTON.Application.Implementations;
using TEKTON.Domain;
using TEKTON.Domain.Aggregates.DescuentoAgg;
using TEKTON.Domain.Aggregates.ProductoAgg;
using TEKTON.Infrastructure.Data.Context;
using TEKTON.Infrastructure.Data.Repositories;

namespace TEKTON.Service.SeedWork
{
    public class InjectionsSettings
    {
        public static void ConfigureServiceCrossCutting(IServiceCollection services)
        {
            #region Inject App Service
            services.AddTransient<IProductoAppService, ProductoAppService>();
            services.AddTransient<IDescuentoAppService, DescuentoAppService>();
            #endregion

            #region Inject Repositories

            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IDescuentoRepository, DescuentoRepository>();

            #endregion
        }
    }
}