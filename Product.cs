using System;
using System.Collections.Generic;
using System.Text;
using ProductLib.FactoriesForSubclassesOfProducts;


namespace ProductLib
{
    public class Product
    {
        public Product()
        {
            PurchasePrice = 0;
            Name = "";
            MarkUp = 0;
            Amount = 0;
        }
        public Product(double purchasePrice, string name,double markUp,uint amount)
        {
            PurchasePrice = purchasePrice;
            Name = name;
            MarkUp = markUp;
            Amount = amount;
        }
        public virtual double PurchasePrice { get; set; }
        public virtual string Name { get;  set; }
        
        public virtual double MarkUp { get;  set; }
        public virtual uint Amount { get;  set; }

        public double GetFullPriceOfAllProducts()
        {
            return Amount*GetFullPriceOfSingleProduct();
        }
        public virtual double GetFullPriceOfSingleProduct()
        {
            return PurchasePrice + MarkUp;
        }
    }
}
