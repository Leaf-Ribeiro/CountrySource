using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CountrySource.Infrastructure.Database
{

    public class BaseDataAccess
    {
        protected readonly IConfiguration configuration;

        public BaseDataAccess()
        {

        }

        #region [ Connection ]

        protected IDbConnection CreateConnection(string connectionStringName = null)
        {
            var ccString = GetConnectionStringByName(connectionStringName);

            var factory = DbProviderFactories.GetFactory(ccString.ProviderName);

            var connection = factory.CreateConnection();
            connection.ConnectionString = ccString.ConnectionString;

            return connection;
        }

        protected IDbConnection CreateConnection(ConnectionStringSettings ccString)
        {
            if (ccString == null)
                ccString = configuration.ConnectionStrings().Default;

            var factory = DbProviderFactories.GetFactory(ccString.ProviderName);

            var connection = factory.CreateConnection();
            connection.ConnectionString = ccString.ConnectionString;

            return connection;
        }

        protected ConnectionStringSettings GetConnectionStringByName(string name)
        {
            var settings = configuration.ConnectionStrings();
            if (settings != null)
            {
                if (string.IsNullOrEmpty(name))
                    return settings.Default;

                foreach (var cs in settings.Values)
                {
                    if (string.Compare(cs.Name, name, true) == 0)
                        return cs;
                }
            }

            return null;
        }

        protected virtual void AddParameter(IDbCommand command, string name, object value)
        {
            AddParameter(command, name, value, null);
        }

        protected virtual void AddParameter(IDbCommand command, string name, object value, DbType? type)
        {
            var parameter = command.CreateParameter();

            if (!name.StartsWith("@"))
                name = "@" + name;

            parameter.ParameterName = name;

            if (value != null)
            {
                parameter.Value = value;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }

            if (type != null)
            {
                parameter.DbType = type.Value;
            }

            command.Parameters.Add(parameter);
        }

        #endregion
    }
}
