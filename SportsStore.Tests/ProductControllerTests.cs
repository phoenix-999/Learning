using System;
using Xunit;
using SportsStore.Models;
using SportsStore.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CountPageTest()
        {
            IQueryable<Product> products = new List<Product>()
            {
                new Product{Id = 1, Name = "P1"},
                new Product{Id = 2, Name = "P2"},
                new Product{Id = 3, Name = "P3"},
                new Product{Id = 4, Name = "P4"},
                new Product{Id = 5, Name = "P5"}
            }.AsQueryable();
            
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(r => r.Products).Returns(products);

            ProductController productController = new ProductController(mock.Object);
            var result = productController.List() as ViewResult;
            var modelData = result.Model as IEnumerable<Product>;

            var actual = products.Take(productController.PageSize);
            Assert.Equal(modelData.Count(), actual.Count());
            foreach(var p in actual)
            {
                Assert.Contains(p, modelData);
            }
        }
    }
}
