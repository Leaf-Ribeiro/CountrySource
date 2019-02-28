using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database.Maps
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).HasMaxLength(150).IsRequired();
            Property(a => a.Continent).HasMaxLength(100).IsRequired();

            HasMany(a => a.States).WithRequired().HasForeignKey(b => b.CountryId);
        }
    }
}
