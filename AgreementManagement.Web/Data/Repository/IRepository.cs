namespace AgreementManagement.Web.Data.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}