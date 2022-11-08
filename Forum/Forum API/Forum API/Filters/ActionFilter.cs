using Microsoft.AspNetCore.Mvc.Filters;

namespace Forum_API.Filters
{
    public abstract class ActionFilter : IActionFilter
    {
        public abstract void OnActionExecuted(ActionExecutedContext context);

        public abstract void OnActionExecuting(ActionExecutingContext context);
    }
}
