using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Filters.Controllers;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using Moq;

namespace Filters.Tests
{
    
    public class HttpsOnlyAttributeTest
    {
        [Fact]
        public void ResultsTest()
        {
            var httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(r => r.IsHttps).Returns(true).Returns(false);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(c => c.Request).Returns(httpRequest.Object);

            var actionContext = new ActionContext(httpContext.Object, new RouteData(), new ActionDescriptor());

            var authorizationFilterContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());


            var httpsOnlyAttribute = new HttpsOnlyAttribute();
            httpsOnlyAttribute.OnAuthorization(authorizationFilterContext);
            Assert.Null(authorizationFilterContext.Result);

            httpsOnlyAttribute.OnAuthorization(authorizationFilterContext);
            Assert.IsType<StatusCodeResult>(authorizationFilterContext.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, (authorizationFilterContext.Result as StatusCodeResult).StatusCode);
        }
    }
}
