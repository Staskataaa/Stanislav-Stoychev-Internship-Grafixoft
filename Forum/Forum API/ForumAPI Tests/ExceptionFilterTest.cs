using Forum_API.Exceptions;
using Forum_API.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForumAPI_Tests
{
    internal class ExceptionFilterTest
    {
        private ActionContext actionContext;
        private Mock<Exception> exception;
        private Mock<EntityNotFoundException> entityNotFoundException;
        private ExceptionFilter exceptionFilter;

        [SetUp]
        public void SetUp()
        {
            actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };

            entityNotFoundException = new Mock<EntityNotFoundException>();
            exception = new Mock<Exception>();

            exception.Setup(mock => mock.Message).Returns("mock exception message");
            exception.Setup(mock => mock.Source).Returns("mock exception source");

            entityNotFoundException.Setup(mock => mock.Message).Returns("mock exception message");
            entityNotFoundException.Setup(mock => mock.Source).Returns("mock exception source");

            exceptionFilter = new ExceptionFilter();
        }

        [Test]
        public void ExceptionFilter_ShouldReturnStasusCode_400()
        {
            ExceptionContext exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = exception.Object
            };

            var responseMessage = new
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = exception.Object.Message,
                Source = exception.Object.StackTrace
            };

            var expected = new ObjectResult(responseMessage);
            var expectedResponseToJSON = JsonSerializer.Serialize(expected);

            exceptionFilter.OnException(exceptionContext);

            var result = (ObjectResult)exceptionContext.Result;
            var resultToJSON = JsonSerializer.Serialize(result);

            Assert.That(resultToJSON, Is.EqualTo(expectedResponseToJSON));
        }

        [Test]
        public void ExceptionFilter_ShouldReturnStasusCode_404()
        {
            ExceptionContext exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = entityNotFoundException.Object
            };

            var responseMessage = new
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = exception.Object.Message,
                Source = exception.Object.StackTrace
            };

            var expected = new ObjectResult(responseMessage);
            var expectedResponseToJSON = JsonSerializer.Serialize(expected);

            exceptionFilter.OnException(exceptionContext);

            var result = (ObjectResult)exceptionContext.Result;
            var resultToJSON = JsonSerializer.Serialize(result);

            Assert.That(resultToJSON, Is.EqualTo(expectedResponseToJSON));
        }
    }
}
