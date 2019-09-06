using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WorkingWithVisualStudio.Models;
using WorkingWithVisualStudio.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsCompleted(IEnumerable<Product> products)
        {
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);

            var controller = new HomeController() { Repository = mock.Object};
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products, Times.AtLeastOnce);
        }
    }
}
