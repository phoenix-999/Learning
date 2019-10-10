using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions;
using ControllersAndActions.Controllers;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.ReceiveForm("Adam", "London") as ViewResult;

            Assert.Equal("Result", result.ViewName);
        }

        [Fact]
        public void ModelObjectType()
        {
            ExampleController controller = new ExampleController();

            var result = controller.Index() as ViewResult;

            Assert.IsType<DateTime>(result.ViewData["Date"]);
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
        }

        [Fact]
        public void Redirection()
        {
            ExampleController controller = new ExampleController();

            var result = controller.Redirect() as RedirectToRouteResult;

            Assert.False(result.Permanent);
            Assert.Equal("Example", result.RouteValues["controller"]);
            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("MyID", result.RouteValues["id"]);
        }
    }
}
