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
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).HasMaxLength(150).IsRequired();

            HasRequired(a => a.Country).WithMany().HasForeignKey(b => b.CountryId);
            HasMany(a => a.Cities).WithRequired().HasForeignKey(b => b.StateId);
        }
    }
}
