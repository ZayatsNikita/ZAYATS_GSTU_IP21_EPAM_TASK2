using System;
using System.Collections.Generic;
using System.Text;
using ProductLib.FactoriesForSubclassesOfProducts;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    public class Product
    {

        protected double _purchasePrice;

        protected string _name;

        protected double _markUp;

        protected int _amount;

        public Product()
        {
            PurchasePrice = 0;
            Name = "";
            MarkUp = 0;
            Amount = 0;
        }
        public Product(double purchasePrice, string name,double markUp,int amount)
        {
            PurchasePrice = purchasePrice;
            Name = name;
            MarkUp = markUp;
            Amount = amount;
        }
        

        public virtual double PurchasePrice {
            get
            {
                return _purchasePrice;
            }
            set
            {
                if (value < 0)
                    throw new ProductPriceException();
                else _purchasePrice = value;
            }
        }
        
        public virtual string Name { get;  set; }
        
        public virtual double MarkUp
        {
            get
            {
                return _markUp;
            }
            set
            {
                if (value < 0)
                    throw new ProductMarkUpException();
                else _markUp = value;
            }
        } 

        public virtual int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0)
                    throw new ProductAmountException();
                else _amount = value;
            }
        }

        public static Product operator +(Product one, Product two)
        {
            if (one.GetType() == two.GetType())
            {
                if (one == null || two == null)
                    throw new NullReferenceException();
                if (one.Name != two.Name)
                    throw new ProductNameException();
                return ProductFactory.CreateProduct(one.GetType().Name,(one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
            }
            throw new ArgumentException();
        }
        public static Product operator -(Product prod, int amount)
        {
            if (prod == null)
                throw new NullReferenceException();
            if (prod.Amount - amount < 0)
                throw new ProductPriceException("Attempt to create an object with a negative number of product instances");
            return ProductFactory.CreateProduct(prod.GetType().Name,prod.PurchasePrice, prod.Name, prod.MarkUp, prod.Amount - amount);
        }

        public double GetFullPriceOfAllProducts()
        {
            return Amount*GetFullPriceOfSingleProduct();
        }
        public virtual double GetFullPriceOfSingleProduct()
        {
            return PurchasePrice + MarkUp;
        }


        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || obj == null)
                return false;
            Product product = (Product)obj;
            return MarkUp == product.MarkUp && PurchasePrice == product.PurchasePrice && Name == product.Name && Amount == product.Amount;

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(PurchasePrice, Name, MarkUp, Amount);
        }
        public override string ToString()
        {
            return String.Format($"Type: {this.GetType()}; Name: {Name};  Purchase price: {PurchasePrice}; Mark-up: {MarkUp}; Amunt:{Amount}");
        }
    
        
        public static explicit operator Int32(Product product)
        {
            return (int)product.GetFullPriceOfAllProducts() * 100;
        }

        public static implicit operator Double(Product product)
        {
            return (int)product.GetFullPriceOfAllProducts();
        }



    }
}
