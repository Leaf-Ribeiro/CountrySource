using CountrySource.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Domain.Countries
{
    public interface ICountryRepository : IRepository<Country>
    {
        void Add(City city);
        void Add(State state);
        void Update(City city);
        void Update(State state);
        void Delete(City city);
        void Delete(State state);
        Country GetById(int id);
        Country GetBy(string name);
        City GetCityBy(int id);
        State GetStateBy(int id);
        IList<City> FindCityBy(string text);
        IList<State> FindAllStates();
        IList<Country> FindBy(string text);
        IList<State> FindStateBy(string text);
    }
}
