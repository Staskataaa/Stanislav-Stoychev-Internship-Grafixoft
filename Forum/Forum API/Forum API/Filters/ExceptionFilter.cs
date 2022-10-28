using System.Net;
using System.Web.Http.Filters;

namespace Forum_API.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            HttpResponseMessage responseMessage;

            responseMessage = new HttpResponseMessage
            {
                StatusCode = GetExceptionStatusCode(exception)
            };

            context.Response = responseMessage;
        }

        private static HttpStatusCode GetExceptionStatusCode(Exception? e)
        {
            return e switch
            {
                NullReferenceException => HttpStatusCode.NotFound,
                Exception => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.BadRequest
            };
        }
    }
}
