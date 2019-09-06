using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {GetPricesUnder50()};
            yield return new object[] { GetPricesOver50() };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275M, 48.95M, 19.90M, 34.95M };
            for(int i = 0; i < prices.Length; i++)
            {
                yield return new Product() { Name = $"P:{i + 1}", Price = prices[i] };
            }
        }

        private IEnumerable<Product> GetPricesOver50()
        {
            decimal[] prices = new decimal[] { 5M, 48.95M, 19.50M, 24.95M };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product() { Name = $"P:{i + 1}", Price = prices[i] };
            }
        }
    }
}
