using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext ctx;

        public EFProductRepository(ApplicationDbContext context)
        {
            this.ctx = context;
        }
        public IQueryable<Product> Products => ctx.Products;
    }
}
