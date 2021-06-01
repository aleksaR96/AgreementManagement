namespace AgreementManagement.Web.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductGroupRepository<T> : IRepository<T> where T : class
    {
        private readonly AgreementManagementContext _context;
        private readonly DbSet<T> _table;
        private bool disposed = false;

        public ProductGroupRepository()
        {
            _context = new AgreementManagementContext();
            _table = _context.Set<T>();
        }

        public ProductGroupRepository(DbSet<T> table)
        {
            _context = new AgreementManagementContext();
            _table = table;
        }

        public ProductGroupRepository(AgreementManagementContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int productGroupID)
        {
            return _table.Find(productGroupID);
        }

        public void Insert(T productGroup)
        {
            _table.Add(productGroup);
        }

        public void Update(T productGroup)
        {
            _context.Update(productGroup);
        }

        public void Delete(int productGroupID)
        {
            ProductGroup productGroup = _context.ProductGroup.Find(productGroupID);
            _context.ProductGroup.Remove(productGroup);
        }

        public void Save()
        {
            _context.SaveChanges();
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
    }
}
