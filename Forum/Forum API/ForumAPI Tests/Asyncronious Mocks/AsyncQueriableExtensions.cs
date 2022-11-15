using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
namespace ForumAPI_Tests.Asyncronious_Mocks
{
    public static class AsyncQueryableExtensions
    {
        public static IQueryable<T> AsAsyncQueryable<T>(this IEnumerable<T> source)
        {
            return new AsyncQueriable<T>(source ?? throw new ArgumentNullException(nameof(source)));
        }
    }
}
