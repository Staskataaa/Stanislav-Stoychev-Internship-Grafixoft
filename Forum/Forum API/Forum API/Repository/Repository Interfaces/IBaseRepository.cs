using System.Linq.Expressions;

namespace Forum_API.Repository.Repository_Interfaces
{
    public interface IBaseRepository<T> : IDisposable
    {
        IQueryable<T> FindAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}