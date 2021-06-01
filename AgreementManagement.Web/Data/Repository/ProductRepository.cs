namespace AgreementManagement.Web.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository<T> : IRepository<T> where T : class
    {
        private readonly AgreementManagementContext _context;
        private readonly DbSet<T> _table;
        private bool disposed = false;

        public ProductRepository()
        {
            _context = new AgreementManagementContext();
            _table = _context.Set<T>();
        }

        public ProductRepository(DbSet<T> table)
        {
            _context = new AgreementManagementContext();
            _table = table;
        }

        public ProductRepository(AgreementManagementContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int productID)
        {
            return _table.Find(productID);
        }

        public void Insert(T product)
        {
            _table.Add(product);
        }

        public void Update(T product)
        {
            _context.Update(product);
        }

        public void Delete(int productID)
        {
            Product product = _context.Product.Find(productID);
            _context.Product.Remove(product);
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

        public ICollection<Product> SortProducts(string columnName, bool orderAscending = true)
        {
            IQueryable<Product> products = (IQueryable<Product>)_table.ToList();

            switch (columnName)
            {
                case nameof(Product.ProductDescription):
                    products = orderAscending ?
                        products.OrderBy(s => s.ProductDescription).AsQueryable() : products.OrderByDescending(s => s.ProductDescription).AsQueryable();
                    break;
                case nameof(Product.Price):
                    products = orderAscending ?
                        products.OrderBy(s => s.Price).AsQueryable() : products.OrderByDescending(s => s.Price).AsQueryable();
                    break;
                default:
                    break;
            }

            var result = products.ToList();
            return result;
        }
    }
}
