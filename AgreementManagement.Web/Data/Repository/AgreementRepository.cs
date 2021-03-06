namespace AgreementManagement.Web.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AgreementRepository<T> : IRepository<T> where T : class
    {
        private readonly AgreementManagementContext _context;
        private readonly DbSet<T> _table;
        private bool disposed = false;

        public AgreementRepository()
        {
            _context = new AgreementManagementContext();
            _table = _context.Set<T>();
        }

        public AgreementRepository(DbSet<T> table)
        {
            _context = new AgreementManagementContext();
            _table = table;
        }

        public AgreementRepository(AgreementManagementContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Delete(int id)
        {
            Agreement agreement = _context.Agreement.Find(id);
            _context.Agreement.Remove(agreement);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public T GetById(string id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Update(obj);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICollection<Agreement> SortAgreements(string columnName, bool orderAscending = true)
        {
            IQueryable<Agreement> agreements = (IQueryable<Agreement>)_table.ToList();

            switch (columnName)
            {
                case nameof(Agreement.EffectiveDate):
                    agreements = orderAscending ?
                        agreements.OrderBy(s => s.EffectiveDate).AsQueryable() : agreements.OrderByDescending(s => s.EffectiveDate).AsQueryable();
                    break;
                case nameof(Agreement.ExpirationDate):
                    agreements = orderAscending ?
                        agreements.OrderBy(s => s.ExpirationDate).AsQueryable() : agreements.OrderByDescending(s => s.ExpirationDate).AsQueryable();
                    break;
                case nameof(Agreement.ProductPrice):
                    agreements = orderAscending ?
                        agreements.OrderBy(s => s.ProductPrice).AsQueryable() : agreements.OrderByDescending(s => s.ProductPrice).AsQueryable();
                    break;
                case nameof(Agreement.NewPrice):
                    agreements = orderAscending ?
                        agreements.OrderBy(s => s.NewPrice).AsQueryable() : agreements.OrderByDescending(s => s.NewPrice).AsQueryable();
                    break;
                default:
                    break;
            }

            var result = agreements.ToList();
            return result;
        }
    }
}
