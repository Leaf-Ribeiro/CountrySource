using CountrySource.Application.Countries.Commands;
using CountrySource.Contracts;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries
{
    public class CountryAppService : AppService<ICountryRepository, Country>
    {
        public CountryAppService(IUnitOfWorkFactory unitOfWorkFactory, ICountryRepository repository) : base(unitOfWorkFactory, repository)
        {
        }



        public void Create(CountryCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var exists = repository.GetBy(command.Name);
            if (exists != null) throw new Exception("País já exisnte.");
            var country = new Country(command.Name, command.Continent);

            repository.Add(country);
        }

        public void Update(CountryUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var country = GetById(command.Id.Value);

            country.Update(command.Name, command.Continent);

            repository.Update(country);
        }

        public void Delete(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var country = GetById(id.Value);

            repository.Delete(country);
        }

        public Country GetById(int? id)
        {
            var country = repository.GetById(id.Value);
            if (country == null) throw new Exception("Pais não encontrado ou não cadastrado.");

            return country;
        }

        public IList<Country> FindBy(string text)
        {
            return repository.FindBy(text);
        }

        #region [ State ]

        public void CreateState(StateCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var country = repository.GetById(command.CountryId.Value);
            if (country == null) throw new Exception("País não encontrado ou não cadastrado.");

            country.CrateState(command.Name);

            repository.Update(country);
        }

        public void UpdateState(StateUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var state = GetStateBy(command.Id);
            state.Update(command.Name, command.CountryId);

            repository.Update(state);
        }

        public void DeleteState(int? stateId)
        {
            if (!stateId.HasValue) throw new ArgumentNullException(nameof(stateId));
            var state = GetStateBy(stateId.Value);

            repository.Delete(state);
        }

        public State GetStateBy(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var state = repository.GetStateBy(id.Value);
            if (state == null) throw new Exception("Estado não encontrado ou não cadastrado.");

            return state;
        }

        public IList<State> FindStateBy(string text)
        {
            return repository.FindStateBy(text);
        }

        public IList<State> FindAllStates()
        {
            return repository.FindAllStates();
        }

        #endregion


        #region [ City ] 

        public void CreateCity(CityCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.StateId.HasValue) throw new ArgumentNullException(nameof(command.StateId));

            var state = repository.GetStateBy(command.StateId.Value);

            state.CreateCity(command.Name);

            repository.Update(state);
        }

        public void UpdateCity(CityUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var city = GetCityBy(command.Id);

            city.Update(command.Name, command.StateId);

            repository.Update(city);
        }

        public void DeleteCity(int? cityId)
        {
            if (!cityId.HasValue) throw new ArgumentNullException(nameof(cityId));

            var city = GetCityBy(cityId);

            repository.Delete(city);
        }

        public City GetCityBy(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var city = repository.GetCityBy(id.Value);
            if (city == null) throw new Exception("Cidade não encontrada ou não cadastrada.");

            return city;
        }

        public IList<City> FindCityBy(string text)
        {
            return repository.FindCityBy(text);
        }

        #endregion
    }
}
