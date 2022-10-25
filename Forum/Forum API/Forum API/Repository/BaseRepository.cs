using Forum_API.Repository.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum_API.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ForumContext Repository_Context { get; set; }

        public BaseRepository(ForumContext repository_Context)
        {
            Repository_Context = repository_Context;
        }

        public IQueryable<T> FindAll() => Repository_Context.Set<T>().AsNoTracking();

        public void Create(T entity) => Repository_Context.Set<T>().Add(entity);

        public void Update(T entity) => Repository_Context.Set<T>().Update(entity);

        public void Delete(T entity) => Repository_Context.Set<T>().Remove(entity);

        public void Save() => Repository_Context.SaveChanges();

        public void Dispose()
        {
            Repository_Context.Dispose();
        }
    }
}
