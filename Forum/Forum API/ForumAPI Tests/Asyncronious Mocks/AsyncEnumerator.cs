using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumAPI_Tests.Account_Role_Tests
{
    internal class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> inner;

        public AsyncEnumerator(IEnumerator<T> inner) => this.inner = inner;

        public void Dispose() => inner.Dispose();

        public T Current => inner.Current;

        public ValueTask<bool> MoveNextAsync() => new(inner.MoveNext());

        public ValueTask DisposeAsync()
        {
            inner.Dispose();
            return new ValueTask();
        }
    }
}
