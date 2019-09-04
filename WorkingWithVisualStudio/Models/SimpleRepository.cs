﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();

        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public SimpleRepository()
        {
            var initialItems = new Product[]
            {
                new Product(){Name = "Kayak", Price = 275M }
                ,new Product(){ Name = "Lifejacket", Price = 48.95M}
                ,new Product(){ Name = "Soccer ball", Price = 19.50M}
                ,new Product(){ Name = "Corner flag", Price = 34.95M}
            };

            foreach(var p in initialItems)
            {
                AddProduct(p);
            }
        }

        public static SimpleRepository SharedRepository => sharedRepository;

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
