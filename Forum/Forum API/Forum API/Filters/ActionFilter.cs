using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Forum_API.Filters
{
    public class ActionFilter : IActionFilter
    {

        public virtual void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public virtual void OnActionExecuting(ActionExecutingContext context)
        {            
        }
    }
}
