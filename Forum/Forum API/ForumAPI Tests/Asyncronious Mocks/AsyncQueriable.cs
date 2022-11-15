using ForumAPI_Tests.Account_Role_Tests;
using System.Linq.Expressions;

namespace ForumAPI_Tests.Asyncronious_Mocks
{
    public class AsyncQueriable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public AsyncQueriable(IEnumerable<T> enumerable) : base(enumerable) { }

        public AsyncQueriable(Expression expression) : base(expression) { }

        public IAsyncEnumerator<T> GetEnumerator() => new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

        IQueryProvider IQueryable.Provider => new AsyncQueryProvider<T>(this);
    }
}
