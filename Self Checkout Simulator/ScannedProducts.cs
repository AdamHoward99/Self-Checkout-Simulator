using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class ScannedProducts
    {
        private List<Product> products = new List<Product>();

        public List<Product> GetProducts() => products;
        public int CalculateWeight() => products.Sum<Product>((Product p) => p.Weight);
        public int CalculatePrice() => products.Sum<Product>((Product p) => p.CalculatePrice());
        public void Reset() => products.Clear();
        public void Add(Product p) => products.Add(p);
        public void Remove() => products.RemoveAt(products.Count - 1);
        public bool ContainsItems() => products.Count > 0;
        public Product GetLastItem() => products[products.Count - 1];
    }
}