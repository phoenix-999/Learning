using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SportsStore.Models;
using SportsStore.Controllers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new Product[] {
                    new Product { ProductID = 1, Name = "P1"},
                    new Product { ProductID = 2, Name = "P2" },
                    new Product { ProductID = 3, Name = "P3" },
                    new Product { ProductID = 4, Name = "P4" },
                    new Product { ProductID = 5, Name = "P5" }
                }.AsQueryable<Product>()
                );

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            var results = (controller.List(2) as ViewResult).Model as IEnumerable<Product>;

            Assert.True(results.Count() == 2);
            Assert.Equal("P4", results.ElementAt(0).Name);
            Assert.Equal("P5", results.ElementAt(1).Name);
        }
    }
}
