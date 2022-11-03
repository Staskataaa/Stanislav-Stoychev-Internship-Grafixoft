using Forum_API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Forum_API.Filters
{
    public class ExceptionFilter : ActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var exception = context.Exception;

                var responseMessage = new
                {
                    StatusCode = GetExceptionStatusCode(exception),
                    Message = exception.Message,
                    Source = exception.StackTrace,
                };

                context.Result = new ObjectResult(responseMessage);
                context.ExceptionHandled = true;
            }
        }

        private static HttpStatusCode GetExceptionStatusCode(Exception? e)
        {
            return e switch
            {
                EntityNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.BadRequest
            };
        }
    }
}
