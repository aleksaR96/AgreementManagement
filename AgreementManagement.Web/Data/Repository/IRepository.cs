using System.Collections.Generic;

namespace AgreementManagement.Web.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}