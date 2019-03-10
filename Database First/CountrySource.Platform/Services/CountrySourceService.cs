using CountrySource.Platform.Database;
using CountrySource.Platform.Models;
using CountrySource.Platform.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Services
{
    public class CountrySourceService
    {
        private readonly EFDatabase database;
        public CountrySourceService(EFDatabase database)
        {
            if (database == null) throw new ArgumentNullException(nameof(database));

            this.database = database;
        }

        public void Create(PaisCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var exists = database.GetBy(command.Nome);
            if (exists != null) throw new Exception("Ja existe um Pais cadastrado com esse nome.");
            var pais = new Pais(command.Nome, command.Continente);

            database.Add(pais);
        }

        public void Update(PaisUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var Pais = GetById(command.Id.Value);

            var exists = database.GetBy(command.Nome);
            if (exists != null) throw new Exception("Ja existe um Pais cadastrado com esse nome.");

            Pais.Update(command.Nome, command.Continente);

            database.Update(Pais);
        }

        public void Delete(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var Pais = GetById(id.Value);

            database.Delete(Pais);
        }

        public Pais GetById(int? id)
        {
            var Pais = database.GetById(id.Value);
            if (Pais == null) throw new Exception("Pais não encontrado ou não cadastrado.");

            return Pais;
        }

        public IList<Pais> FindAll()
        {
            return database.FindAll();
        }

        public IList<Pais> FindBy(string text)
        {
            return database.FindBy(text);
        }

        #region [ Estado ]

        public void CreateEstado(EstadoCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var pais = database.GetById(command.PaisId.Value);
            if (pais == null) throw new Exception("País não encontrado ou não cadastrado.");

            var exists = database.GetEstadoBy(command.Nome);
            if (exists != null) throw new Exception("Já existe um Estado cadastrado com esse nome.");

            var estado = new Estado(command.Nome, pais);

            database.Add(estado);
        }

        public void UpdateEstado(EstadoUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var estado = GetEstadoBy(command.Id);

            var pais = GetById(command.PaisId.Value);
            if (pais == null) throw new Exception("Pais inválido.");

            var exists = database.GetEstadoBy(command.Nome);
            if (exists != null) throw new Exception("Já existe um Estado cadastrado com esse nome.");
            estado.Update(command.Nome, pais);

            database.Update(estado);
        }

        public void DeleteEstado(int? EstadoId)
        {
            if (!EstadoId.HasValue) throw new ArgumentNullException(nameof(EstadoId));
            var Estado = GetEstadoBy(EstadoId.Value);

            database.Delete(Estado);
        }

        public Estado GetEstadoBy(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var Estado = database.GetEstadoBy(id.Value);
            if (Estado == null) throw new Exception("Estado não encontrado ou não cadastrado.");

            return Estado;
        }

        public IList<Estado> FindEstadoBy(string text)
        {
            return database.FindEstadoBy(text);
        }

        public IList<Estado> FindAllEstados()
        {
            return database.FindAllEstados();
        }

        #endregion


        #region [ Cidade ] 

        public void CreateCidade(CidadeCreateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.EstadoId.HasValue) throw new ArgumentNullException(nameof(command.EstadoId));

            var exists = database.GetCidadeBy(command.Nome);
            if (exists != null) throw new Exception("Já existe uma Cidade cadastrada com esse nome.");

            var estado = database.GetEstadoBy(command.EstadoId.Value);
            if (estado == null) throw new Exception("Estado não encontrado ou inexistente.");

            var cidade = new Cidade(command.Nome, estado);

            database.Add(cidade);
        }

        public void UpdateCidade(CidadeUpdateCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (!command.Id.HasValue) throw new ArgumentNullException(nameof(command.Id));

            var cidade = GetCidadeBy(command.Id);

                        var exists = database.GetCidadeBy(command.Nome);
            if (exists != null) throw new Exception("Já existe uma Cidade cadastrada com esse nome.");

            var estado = database.GetEstadoBy(command.EstadoId.Value);
            if (estado == null) throw new Exception("Estado não encontrado ou inexistente.");

            cidade.Update(command.Nome, estado);

            database.Update(cidade);
        }

        public void DeleteCidade(int? cidadeId)
        {
            if (!cidadeId.HasValue) throw new ArgumentNullException(nameof(cidadeId));

            var cidade = GetCidadeBy(cidadeId);
            if (cidade == null) throw new Exception("Cidade não existente ou não cadastrada.");

            database.Delete(cidade);
        }

        public Cidade GetCidadeBy(int? id)
        {
            if (!id.HasValue) throw new ArgumentNullException(nameof(id));

            var cidade = database.GetCidadeBy(id.Value);
            if (cidade == null) throw new Exception("Cidade não encontrada ou não cadastrada.");

            return cidade;
        }

        public IList<Cidade> FindCidadeBy(string text)
        {
            return database.FindCidadeBy(text);
        }

        #endregion
    }
}
