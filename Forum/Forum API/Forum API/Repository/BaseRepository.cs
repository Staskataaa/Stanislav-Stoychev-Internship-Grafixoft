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

        public virtual IQueryable<T> FindByCriteria(Expression<Func<T, bool>> expression)
            => Repository_Context.Set<T>().Where(expression);
      
        public virtual IQueryable<T> FindAll() => Repository_Context.Set<T>();

        public virtual async Task Create(T entity) 
        {
            await Repository_Context.Set<T>().AddAsync(entity);
            await Repository_Context.SaveChangesAsync(); 
        } 

        public virtual async Task Update(T entity)
        {
            Repository_Context.Set<T>().Update(entity);
            await Repository_Context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            Repository_Context.Set<T>().Remove(entity);
            await Repository_Context.SaveChangesAsync();
        }

        public virtual async Task SaveChanges() => await Repository_Context.SaveChangesAsync();
    }
}
