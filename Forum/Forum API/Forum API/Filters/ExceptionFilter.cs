using Forum_API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Forum_API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var responseMessage = new
            {
                StatusCode = GetExceptionStatusCode(exception),
                Message = exception.Message,
                Source = exception.StackTrace,
            };

            Console.WriteLine(responseMessage.ToString());
            context.Result = new ObjectResult(responseMessage);
        }

        private static HttpStatusCode GetExceptionStatusCode(Exception? e)
        {
            return e switch
            {
                EntityNotFoundException => HttpStatusCode.NotFound
            };
        }

    }
}
