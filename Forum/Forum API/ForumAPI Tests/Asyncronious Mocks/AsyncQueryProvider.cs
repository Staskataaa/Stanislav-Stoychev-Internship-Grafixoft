using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests.Asyncronious_Mocks
{
    internal class AsyncQueryProvider<T> : IAsyncQueryProvider
    {
        private readonly IQueryProvider inner;

        internal AsyncQueryProvider(IQueryProvider inner) => this.inner = inner;

        public IQueryable CreateQuery(Expression expression) => new AsyncQueriable<T>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new AsyncQueriable<TElement>(expression);

        public object Execute(Expression expression) => inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression) => inner.Execute<TResult>(expression);

        public static IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression) => new AsyncQueriable<TResult>(expression);

        TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Execute<TResult>(expression);
    }
}