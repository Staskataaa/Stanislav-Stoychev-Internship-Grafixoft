using System.Linq.Expressions;

namespace Forum_API.ExpressionsGenerator
{
    public abstract class ExpressionProvider<T> : IExpressionsProvider<T> where T : class
    {
        public abstract Task<Expression<Func<T, bool>>> GetExpression(object criteria, string propertyName);
    }
}
