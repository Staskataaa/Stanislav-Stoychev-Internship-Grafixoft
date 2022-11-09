using System.Linq.Expressions;

namespace Forum_API.ExpressionsGenerator
{
    public interface IExpressionsProvider<T>
    {
        public Task<Expression<Func<T, bool>>> GetExpression(object criteria, string propertyName);
    }
}
