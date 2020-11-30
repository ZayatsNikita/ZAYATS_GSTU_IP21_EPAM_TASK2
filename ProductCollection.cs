using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib
{
    class ProductCollection
    {
        public ProductCollection()
        {
            Products = new List<Product>();
            Parameters = new List<String>();
        }
        public ProductCollection(List<Product> products, List<String> parameters)
        {
            Products = products;
            Parameters = parameters;
        }
        public void Add(in Product product)
        {
            Products.Add(product);
            Parameters.Add(product.GetType().Name);
        }
        public void Add(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                Products.Add(product);
                Parameters.Add((product?.GetType().Name ?? "nullName"));
            }
        }
        public List<Product> Products { get; set; }
        public List<String> Parameters { get; set; }

        public int Length 
        { 
            get
            {
                if (Products.Count != Parameters.Count)
                    throw new ArgumentException();
                return Products.Count;
            }
        }
    }
}
