using ProductLib.ProductExceptions;
using System;

namespace ProductLib
{
    /// <summary>
    /// A class that is the base class for all products
    /// </summary>
    public abstract class Product
    {

        protected double _purchasePrice;

        protected string _name;

        protected double _markUp;

        protected int _amount;

        /// <summary>
        /// Default constructor.
        /// <para>Properties PurchasePrice, MarkUp, Amount are assigned a null value, and the name field is assigned the value of a zero-length string.</para>
        /// </summary>
        public Product()
        {
            PurchasePrice = 0;
            Name = "";
            MarkUp = 0;
            Amount = 0;
        }
        /// <summary>
        /// Creates an object with the specified parameters.
        /// </summary>
        /// <param name="purchasePrice">Purchase price of product.</param>
        /// <param name="name">Name of product.</param>
        /// <param name="markUp">Mark-up of product.</param>
        /// <param name="amount">Amount of product.</param>
        /// <exception cref="ProductPriceException">Thrown if a negative value is passed for purchase price.</exception>
        /// <exception cref="ProductMarkUpException">Thrown if a negative value is passed for mark-up.</exception>
        /// <exception cref="ProductAmountException">Thrown if a negative value is passed for amount.</exception>
        ///<exception cref="ProductNameException">Thrown if a null string was passed.</exception>
        public Product(double purchasePrice, string name,double markUp,int amount)
        {
            PurchasePrice = purchasePrice;
            Name = name;
            MarkUp = markUp;
            Amount = amount;
        }
        /// <summary>
        /// Type of This product.
        /// </summary>
        public virtual string TypeOfProduct { get => GetType().Name; }
        /// <summary>
        /// Purchase price of a single product.
        /// </summary>
        /// <exception cref="ProductPriceException">Thrown if a negative value is passed.</exception>
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
        /// <summary>
        /// Product name.
        /// </summary>
        /// <exception cref="ProductNameException">Thrown if a null name is passed.</exception>
        public virtual string Name 
        {
            get=> _name;  
            set
            {
                if (value == null)
                {
                    throw new ProductNameException();
                }
                else
                {
                    _name = value;
                }
            }
        }
        /// <summary>
        /// Mark-up for 1 product.
        /// </summary>
        /// <exception cref="ProductMarkUpException">Thrown if a negative value is passed</exception>
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
        /// <summary>
        /// Quantity of goods in stock.
        /// </summary>
        /// <exception cref="ProductAmountException">Thrown if a negative value is passed.</exception>
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

        /// <summary>
        /// The total cost of the product.
        /// </summary>
        /// <returns>A real number equal to the total cost of the entire product
        /// <para>multiplied by the number of instances of this product.</para></returns>
        public double GetFullPriceOfAllProducts()
        {
            return Amount*GetFullPriceOfSingleProduct();
        }
        /// <summary>
        /// A real number equal to the total cost one instance of the product.
        /// </summary>
        /// <returns>A real number equal to the total cost of the entire product.
        /// </returns>
        public virtual double GetFullPriceOfSingleProduct()
        {
            return PurchasePrice + MarkUp;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || (obj == null && this!=null))
                return false;
            if (this == null && obj == null)
                return true;
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

        /// <summary>
        /// Explicit conversion of the product to an integer.
        /// </summary>
        /// <param name="product">The product from which the data will be received.</param>
        /// <returns>The number of kopecks corresponding to the total cost of the product.</returns>
        public static explicit operator Int32(Product product)
        {
            return (int)(product.GetFullPriceOfAllProducts() * 100);
        }

        /// <summary>
        /// Explicit conversion of the product to an real number.
        /// </summary>
        /// <param name="product">The product from which the data will be received.</param>
        /// <returns>The number of rubles corresponding to the total cost of the product.</returns>
        public static explicit operator Double(Product product)
        {
            return product.GetFullPriceOfAllProducts();
        }
    }
}
