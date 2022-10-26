using System.Linq.Expressions;

namespace Forum_API.Repository.Repository_Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression); 

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task SaveChanges();
    }
}