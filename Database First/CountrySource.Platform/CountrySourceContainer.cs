using CountrySource.Platform.Database;
using CountrySource.Platform.Models;
using CountrySource.Platform.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform
{
    public class SicongerpPlatformContainer : Container
    {
        public SicongerpPlatformContainer()
            : base()
        {

            var registration = Lifestyle.Transient.CreateRegistration<EFContext> (new Func<EFContext>(delegate ()
            {
                return new EFContext();
            }), this);

            Register<CountrySourceService>(Lifestyle.Transient);
            Register<EFDatabase>(Lifestyle.Transient);

        }
    }
}