using Forum_API.Repository.Repository_Interfaces;
using System.Linq.Expressions;

namespace Forum_API.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ForumContext _repository_Context { get; set; }

        public BaseRepository(ForumContext repository_Context)
        {
            _repository_Context = repository_Context;
        }

        public virtual IQueryable<T> FindByCriteria(Expression<Func<T, bool>> expression)
            => _repository_Context.Set<T>().Where(expression);
      
        public virtual IQueryable<T> FindAll() => _repository_Context.Set<T>();

        public virtual async Task Create(T entity) 
        {
            await _repository_Context.Set<T>().AddAsync(entity);
            await _repository_Context.SaveChangesAsync(); 
        } 

        public virtual async Task Update(T entity)
        {
            _repository_Context.Set<T>().Update(entity);
            await _repository_Context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _repository_Context.Set<T>().Remove(entity);
            await _repository_Context.SaveChangesAsync();
        }

        public virtual async Task SaveChanges() => await _repository_Context.SaveChangesAsync();
    }
}
