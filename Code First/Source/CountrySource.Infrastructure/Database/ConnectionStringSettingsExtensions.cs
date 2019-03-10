using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database
{
    public static class ConnectionStringSettingsExtensions
    {
        private static object objLock = new object();
        private static ConnectionStringSettingsCollection connectionStringSettings = null;

        public static ConnectionStringSettingsCollection ConnectionStrings(this IConfiguration configuration, String section = "ConnectionStrings")
        {
            if (connectionStringSettings == null)
            {
                lock (objLock)
                {
                    if (connectionStringSettings == null)
                    {
                        connectionStringSettings = configuration.GetSection(section).Get<ConnectionStringSettingsCollection>();
                        if (connectionStringSettings == null)
                        {
                            connectionStringSettings = new ConnectionStringSettingsCollection();
                        }
                    }
                }
            }

            return connectionStringSettings;
        }

        public static ConnectionStringSettings ConnectionString(this IConfiguration configuration, String name, String section = "ConnectionStrings")
        {
            ConnectionStringSettings connectionStringSettings = null;

            var collection = configuration.ConnectionStrings(section);

            collection.TryGetValue(name, out connectionStringSettings);

            return connectionStringSettings;
        }
    }
}
