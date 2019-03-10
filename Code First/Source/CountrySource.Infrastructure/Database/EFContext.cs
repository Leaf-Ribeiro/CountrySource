using CountrySource.Infrastructure.Database.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database
{
    public class EFContext : DbContext
    {
        public bool IgnoreNonAttachedEntities { get; set; }

        public EFContext() : this("CountrySource")
        {

        }

        public EFContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.UseDatabaseNullSemantics = false;
            Database.Log = s => Debug.WriteLine(s);
            IgnoreNonAttachedEntities = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(typeof(CountryMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void IgnoreNotAttachedEntities()
        {
            if (!IgnoreNonAttachedEntities)
                return;

            var entries = ChangeTracker.Entries().Where(c => c.State == EntityState.Added);

            foreach (var dbEntityEntry in entries)
            {
                try
                {
                    var propertyId = dbEntityEntry.Property("Id");
                    if (propertyId == null)
                        throw new Exception("Invalid entity to be saved or update");

                    var id = (int?)propertyId.CurrentValue;

                    if (id.HasValue && id > 0)
                        dbEntityEntry.State = EntityState.Unchanged;
                }
                catch (Exception) { }
            }
        }


        public override int SaveChanges()
        {
            IgnoreNotAttachedEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            IgnoreNotAttachedEntities();
            return base.SaveChangesAsync();
        }


    }
}
