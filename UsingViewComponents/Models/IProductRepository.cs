using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void AddProduct(Product newProduct);
    }
}
