using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Database
{
    public class EFDatabase
    {
        private readonly EFContext context;
        public EFDatabase(EFContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            this.context = context;
        }

        #region [ Pais ]

        public void Add(Pais pais)
        {
            context.Set<Pais>().Add(pais);

            context.SaveChanges();
        }

        public void Update(Pais updated)
        {
            var pais = context.Set<Pais>().FirstOrDefault(a => a.Id == updated.Id);
            if (pais == null) throw new Exception("Pais inexistente ou não cadastrada.");

            pais.Update(updated.Nome, updated.Continente);

            context.SaveChanges();
        }

        public void Delete(Pais deleted)
        {
            var dbSet = context.Set<Pais>();

            var pais = dbSet.FirstOrDefault(a => a.Id == deleted.Id);
            if (pais == null) throw new Exception("Pais inexistente ou não cadastrada.");

            dbSet.Remove(pais);

            context.SaveChanges();
        }

        public Pais GetById(int id)
        {
            return context.Set<Pais>()
                          .Include("Estados")
                          .FirstOrDefault(a => a.Id == id);
        }

        public Pais GetBy(string nome)
        {
            return context.Set<Pais>()
                          .FirstOrDefault(a => a.Nome.Contains(nome));
        }

        public IList<Pais> FindAll()
        {

            return context.Set<Pais>().ToList();
        }

        public IList<Pais> FindBy(string text)
        {

            if (!string.IsNullOrWhiteSpace(text))
                return context.Set<Pais>().Where(a => a.Nome.Contains(text) || a.Continente.Contains(text))
                              .ToList();

            return context.Set<Pais>().ToList();
        }

        #endregion


        #region [ Estado ]

        public void Add(Estado estado)
        {
            context.Set<Estado>().Add(estado);

            context.SaveChanges();
        }

        public void Update(Estado updated)
        {
            var estado = context.Set<Estado>().FirstOrDefault(a => a.Id == updated.Id);
            if (estado == null) throw new Exception("Estado inexistente ou não cadastrada.");

            estado.Update(updated.Nome, updated.Pais);

            context.SaveChanges();
        }

        public void Delete(Estado deleted)
        {
            var dbSet = context.Set<Estado>();

            var estado = dbSet.FirstOrDefault(a => a.Id == deleted.Id);
            if (estado == null) throw new Exception("Pais inexistente ou não cadastrada.");

            dbSet.Remove(estado);

            context.SaveChanges();
        }

        public Estado GetEstadoBy(int id)
        {
            return context.Set<Estado>()
                          .Include("Pais")
                          .Include("Cidades")
                          .FirstOrDefault(a => a.Id == id);
        }

        public Estado GetEstadoBy(string nome)
        {
            return context.Set<Estado>()
                          .Include("Pais")
                          .Include("Cidades")
                          .FirstOrDefault(a => a.Nome.Contains(nome));
        }

        public IList<Estado> FindAllEstados()
        {
            return context.Set<Estado>()
                          .Include("Cidades")
                          .Include("Pais")
                          .ToList();
        }

        public IList<Estado> FindEstadoBy(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
                return context.Set<Estado>()
                              .Include("Pais")
                              .Where(a => a.Nome.Contains(text) || a.Pais.Nome.Contains(text) || a.Pais.Continente.Contains(text))
                              .ToList();

            return context.Set<Estado>().Include("Pais").ToList();
        }

        #endregion

        #region [ Cidade ] 

        public void Add(Cidade cidade)
        {
            context.Set<Cidade>().Add(cidade);

            context.SaveChanges();
        }

        public void Update(Cidade updated)
        {
            var cidade = context.Set<Cidade>().FirstOrDefault(a => a.Id == updated.Id);
            if (cidade == null) throw new Exception("Cidade inexistente ou não cadastrada.");

            cidade.Update(updated.Nome, updated.Estado);

            context.SaveChanges();
        }

        public void Delete(Cidade deleted)
        {
            var dbSet = context.Set<Cidade>();

            var cidade = dbSet.FirstOrDefault(a => a.Id == deleted.Id);
            if (cidade == null) throw new Exception("Pais inexistente ou não cadastrada.");

            dbSet.Remove(cidade);

            context.SaveChanges();
        }

        public Cidade GetCidadeBy(int id)
        {
            return context.Set<Cidade>()
                          .Include("Estado.Pais")
                          .FirstOrDefault(a => a.Id == id);
        }

        public Cidade GetCidadeBy(string nome)
        {
            return context.Set<Cidade>()
                          .Include("Estado.Pais")
                          .FirstOrDefault(a => a.Nome.Contains(nome));
        }

        public IList<Cidade> FindCidadeBy(string text)
        {

            if (!string.IsNullOrWhiteSpace(text))
                return context.Set<Cidade>()
                              .Include("Estado.Pais")
                              .Where(a => a.Nome.Contains(text) || a.Estado.Nome.Contains(text) || a.Estado.Pais.Nome.Contains(text))
                              .ToList();

            return context.Set<Cidade>().Include("Estado.Pais").ToList();
        }

        #endregion

    }
}