using StackExchange.Redis;

namespace TEKTON.Service.Web.API.Descuentos.Infrastructure.Context
{
    public class AppDbContext
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return _lazyConnection.Value;
            }
        }

        static AppDbContext()
        {
            _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>

                ConnectionMultiplexer.Connect("localhost")
            );
        }
    }
}
