using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;
using LanguageFeatures.Models.Extensions;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach (var p in Product.GetProducts())
            {
                string name = p?.Name;
                decimal? price = p?.Price;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}");
            }

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Products = Product.GetProducts();
            results.Add($"Total: {shoppingCart.Products.TotalPrices()}");

            return View(results);
        }
    }
}
