using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database
{
    public class ConnectionStringSettings
    {

        public String Name { get; set; }
        public String ConnectionString { get; set; }
        public String ProviderName { get; set; }
        public bool Default { get; set; }
        public string Schema { get; set; }

        public ConnectionStringSettings()
        {
        }

        public ConnectionStringSettings(String name, String connectionString)
            : this(name, connectionString, null)
        {
        }

        public ConnectionStringSettings(String name, String connectionString, bool @default)
            : this(name, connectionString, null, @default)
        {
        }

        public ConnectionStringSettings(String name, String connectionString, String providerName)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }

        public ConnectionStringSettings(String name, String connectionString, String providerName, bool @default)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
            this.Default = @default;
        }

        public ConnectionStringSettings(String name, String connectionString, String providerName, bool @default, string schema)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
            this.Default = @default;
            this.Schema = schema;
        }

        protected bool Equals(ConnectionStringSettings other)
        {
            return String.Equals(Name, other.Name)
                && String.Equals(ConnectionString, other.ConnectionString)
                && String.Equals(ProviderName, other.ProviderName)
                && String.Equals(Schema, other.Schema);
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConnectionStringSettings)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConnectionString != null ? ConnectionString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProviderName != null ? ProviderName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Default.GetHashCode());
                hashCode = (hashCode * 397) ^ (Schema != null ? Schema.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return !Equals(left, right);
        }
    }
}
