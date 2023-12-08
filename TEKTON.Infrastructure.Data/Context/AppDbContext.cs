using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Infrastructure.Data.Context
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


