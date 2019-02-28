using CountrySource.Contracts;
using CountrySource.Domain.Countries;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure.Database.Repositores
{
    public class CountryEFRepository : EFRepository<EFContext, Country>, ICountryRepository
    {
        public CountryEFRepository(IUnitOfWorkFactory<EFContext> uofwFactory) : base(uofwFactory)
        {
        }

        public Country GetById(int id)
        {
            {
                using (var unitOfWork = uofwFactory.Get())
                {
                    var context = unitOfWork.Context.Set<Country>();

                    return context.Include("States")
                                  .FirstOrDefault(a => a.Id == id);
                }
            }
        }

        public IList<Country> FindBy(string text)
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var context = unitOfWork.Context.Set<Country>();

                if (!string.IsNullOrWhiteSpace(text))
                    return context.Where(a => a.Name.Contains(text) || a.Continent.Contains(text))
                                  .ToList();

                return context.ToList();
            }
        }


        public State GetStateBy(int id)
        {
            {
                using (var unitOfWork = uofwFactory.Get())
                {
                    var context = unitOfWork.Context.Set<State>();

                    return context.Include("Country")
                                  .Include("Cities")
                                  .FirstOrDefault(a => a.Id == id);
                }
            }
        }

        public IList<State> FindAllStates()
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var context = unitOfWork.Context.Set<State>();

                return context.Include("Cities")
                              .Include("Country")
                              .ToList();
            }
        }

        public IList<State> FindStateBy(string text)
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var context = unitOfWork.Context.Set<State>();

                if (!string.IsNullOrWhiteSpace(text))
                    return context.Include("Country")
                                  .Where(a => a.Name.Contains(text) || a.Country.Name.Contains(text) || a.Country.Continent.Contains(text))
                                  .ToList();

                return context.Include("Country").ToList();
            }
        }

        public City GetCityBy(int id)
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var context = unitOfWork.Context.Set<City>();

                return context.Include("State.Country")
                              .FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<City> FindCityBy(string text)
        {
            using (var unitOfWork = uofwFactory.Get())
            {
                var context = unitOfWork.Context.Set<City>();

                if (!string.IsNullOrWhiteSpace(text))
                    return context.Include("State.Country")
                                  .Where(a => a.Name.Contains(text) || a.State.Name.Contains(text) || a.State.Country.Name.Contains(text))
                                  .ToList();

                return context.Include("State.Country").ToList();
            }
        }

        public void Add(City city)
        {
            base.Add(city);
        }

        public void Add(State state)
        {
            base.Add(state);
        }

        public void Update(City city)
        {
            base.Update(city);
        }

        public void Update(State state)
        {
            base.Update(state);
        }

        public void Delete(City city)
        {
            base.Delete(city);
        }

        public void Delete(State state)
        {
            base.Delete(state);
        }
    }
}
