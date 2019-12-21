﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext ctx = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            ctx.Database.Migrate();
            if (ctx.Products.Any())
                return;
            ctx.Products.AddRange(
                new Product
                {
                    Name = "Kayak",
                    Description = "А boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                new Product
                {
                    Name = "Lifejacket",
                    Description = "Protective and fashionaЫe",
                    Category = "Watersports",
                    Price = 48.95m
                },
                new Product
                {
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Category = "Soccer", Price = 19.50m
                },
                new Product {
                    Name = "Corner Flags",
                    Description = "Give your playing field а professional touch",
                    Category = "Soccer", Price = 34.95m },
                new Product {
                    Name = "Stadium",
                    Description = "Flat-packed 35, 000-seat stadium",
                    Category = "Soccer", Price = 79500 },
                new Product {
                    Name = "Thinking Сар",
                    Description = "Improve brain efficiency Ьу 75i",
                    Category = "Chess", Price = 16 } ,
                new Product {
                    Name = "Unsteady Chair",
                    Description = "Secretly give your opponent а disadvantage",
                    Category = "Chess", Price = 29.95m },
                new Product
                {
                    Name = "Human Chess Board",
                    Description = "А fun game for the family",
                    Category = "Chess",
                    Price = 75
                } ,
                new Product
                {
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Category = "Chess",
                    Price = 1200
                }
            );
            ctx.SaveChanges();
        }
    }
}
