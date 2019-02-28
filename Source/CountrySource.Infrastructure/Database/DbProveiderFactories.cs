using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westwind.Utilities;
using Westwind.Utilities.Properties;

namespace CountrySource.Infrastructure.Database
{
    public class DbProviderFactories
    {
        #region Provider Factories

        /// <summary>
        /// Loads a SQL Provider factory based on the DbFactory type name and assembly.       
        /// </summary>
        /// <param name="dbProviderFactoryTypename">Type name of the DbProviderFactory</param>
        /// <param name="assemblyName">Short assembly name of the provider factory. Note: Host project needs to have a reference to this assembly</param>
        /// <returns></returns>
        public static DbProviderFactory GetFactory(string dbProviderFactoryTypename, string assemblyName)
        {
            var instance = ReflectionUtils.GetStaticProperty(dbProviderFactoryTypename, "Instance");
            if (instance == null)
            {
                var a = ReflectionUtils.LoadAssembly(assemblyName);
                if (a != null)
                    instance = ReflectionUtils.GetStaticProperty(dbProviderFactoryTypename, "Instance");
            }

            if (instance == null)
                throw new InvalidOperationException(string.Format(Resources.UnableToRetrieveDbProviderFactoryForm, dbProviderFactoryTypename));

            return instance as DbProviderFactory;
        }


        /// <summary>
        /// This method loads various providers dynamically similar to the 
        /// way that DbProviderFactories.GetFactory() works except that
        /// this API is not available on .NET Standard 2.0
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DbProviderFactory GetFactory(DataAccessProviderTypes type)
        {
            if (type == DataAccessProviderTypes.SqlServer)
            {
                return SqlClientFactory.Instance; // this library has a ref to SqlClient so this works
            }
            else if (type == DataAccessProviderTypes.SqLite)
            {
#if NETFULL
                return GetDbProviderFactory("System.Data.SQLite.SQLiteFactory", "System.Data.SQLite");
#else
                return GetFactory("Microsoft.Data.Sqlite.SqliteFactory", "Microsoft.Data.Sqlite");
#endif
            }
            else if (type == DataAccessProviderTypes.MySql)
                return GetFactory("MySql.Data.MySqlClient.MySqlClientFactory", "MySql.Data");
            else if (type == DataAccessProviderTypes.PostgreSql)
                return GetFactory("Npgsql.NpgsqlFactory", "Npgsql");
#if NETFULL
            if (type == DataAccessProviderTypes.OleDb)
                return System.Data.OleDb.OleDbFactory.Instance;
            if (type == DataAccessProviderTypes.SqlServerCompact)
                return DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0");         
#endif

            throw new NotSupportedException(string.Format(Resources.UnsupportedProviderFactory, type.ToString()));
        }



        /// <summary>
        /// Returns a provider factory using the old Provider Model names from full framework .NET.
        /// Simply calls DbProviderFactories.
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static DbProviderFactory GetFactory(string providerName)
        {
#if NETFULL
            return DbProviderFactories.GetFactory(providerName);
#else
            providerName = providerName.ToLower();

            if (providerName == "system.data.sqlclient")
                return GetFactory(DataAccessProviderTypes.SqlServer);
            else if (providerName == "system.data.sqlite" || providerName == "microsoft.data.sqlite")
                return GetFactory(DataAccessProviderTypes.SqLite);
            else if (providerName == "mysql.data.mysqlclient" || providerName == "mysql.data")
                return GetFactory(DataAccessProviderTypes.MySql);
            else if (providerName == "npgsql")
                return GetFactory(DataAccessProviderTypes.PostgreSql);

            throw new NotSupportedException(string.Format(Resources.UnsupportedProviderFactory, providerName));
#endif
        }

        #endregion
    }
}
