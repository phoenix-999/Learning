using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        ApplicationDbContext db;
        public EFProductRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Product> Products => db.Products;
    }
}
