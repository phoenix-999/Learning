using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize { get; set; } = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List(int pageNumber = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize));
        }
    }
}