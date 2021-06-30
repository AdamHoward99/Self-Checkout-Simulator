using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class ScannedProducts
    {
        // Attributes

        private List<Product> products = new List<Product>();


        // Operations

        public List<Product> GetProducts()
        {
            return products;
        }

        public int CalculateWeight()
        {
            return products.Sum<Product>((Product p) => p.GetWeight());
        }

        public int CalculatePrice()
        {
            return products.Sum<Product>((Product p) => p.CalculatePrice());
        }

        public void Reset()
        {
            products.Clear();
        }

        public void Add(Product p)
        {
            products.Add(p);
        }

        public void Remove(Product p)
        {
            products.Remove(p);
        }

        public bool HasItems()
        {
            return products.Count > 0;
        }

    }
}