using TEKTON.Service.Web.API.Descuentos.Domain;

namespace TEKTON.Service.Web.API.Descuentos.Service
{
    public class InjectionsSettings
    {
        public static void ConfigureServiceCrossCutting(IServiceCollection services)
        {
            #region Inject Repositories
            services.AddTransient<IDescuentoRepository, DescuentoRepository>();
            #endregion
        }
    }
}
