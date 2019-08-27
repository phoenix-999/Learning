﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";

        public bool InStock { get; } = true;

        public Product Related { get; set; }

        public bool NameBeginsWithS => Name?[0] == 'S';

        public Product(bool stock = true) =>
            InStock = stock;


        public static Product[] GetProducts()
        {
            Product kayak = new Product() { Name = "Kayak", Price = 275M, Category = "Water Craft"};
            Product lifejacket = new Product(false) { Name = "Lifejacket", Price = 48.95M};

            kayak.Related = lifejacket;


            return new Product[] { kayak, lifejacket, null };
        }
    }
}
