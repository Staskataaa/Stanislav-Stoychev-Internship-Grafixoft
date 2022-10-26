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

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) =>
             Repository_Context.Set<T>().Where(expression).AsQueryable();

        public IQueryable<T> FindAll() => Repository_Context.Set<T>().AsNoTracking();
       
        public async Task Create(T entity) => await Repository_Context.Set<T>().AddAsync(entity);

        public async Task Update(T entity)
        {
            Repository_Context.Set<T>().Update(entity);
            await Repository_Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Repository_Context.Set<T>().Remove(entity);
            await Repository_Context.SaveChangesAsync();
        }

        public async Task SaveChanges() => await Repository_Context.SaveChangesAsync();
    }
}
