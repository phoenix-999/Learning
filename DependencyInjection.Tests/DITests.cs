using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjection.Controllers;
using DependencyInjection.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;



namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            var data = new Product[] { new Product { Name = "Test", Price = 100M} };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);

            HomeController controller = new HomeController(mock.Object);
            var result = controller.Index() as ViewResult;

            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
