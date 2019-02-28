using CountrySource.Application.Countries;
using CountrySource.Contracts;
using CountrySource.Domain.Countries;
using CountrySource.Infrastructure.Database;
using CountrySource.Infrastructure.Database.Repositores;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure
{
    public class SicongerpPlatformContainer : Container
    {
        public SicongerpPlatformContainer()
            : base()
        {

            //entify context
            var registration = Lifestyle.Singleton.CreateRegistration<IUnitOfWorkFactory<EFContext>>(new Func<IUnitOfWorkFactory<EFContext>>(delegate ()
            {
                return new EFUnitOfWorkFactory<EFContext>(new WebUnitOfWorkStore());
            }), this);
            AddRegistration(typeof(IUnitOfWorkFactory<EFContext>), registration);
            AddRegistration(typeof(IUnitOfWorkFactory), registration);

            //repositories
            Register<ICountryRepository, CountryEFRepository>(Lifestyle.Singleton);


            //application
            Register<CountryAppService>(Lifestyle.Singleton);

        }
    }
}