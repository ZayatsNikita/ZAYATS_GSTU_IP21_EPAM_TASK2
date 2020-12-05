using System;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    /// <summary>
    /// Class describing Electronics
    /// </summary>
    public class Electronics : Product
    {
        /// <summary>
        /// Default constructor.
        /// <para>Properties PurchasePrice, MarkUp, Amount are assigned a null value, and the name field is assigned the value of a zero-length string.</para>
        /// </summary>
        public Electronics():base()
        { }
        /// <summary>
        /// Electronics constrictor with params.
        /// </summary>
        /// <param name="purchasePrice">Purchase price of clothes.</param>
        /// <param name="name">Name of clothes.</param>
        /// <param name="markUp">Mark-Up of single clothes item.</param>
        /// <param name="amount">Amount of clothes.</param>
        /// /// <exception cref="ProductPriceException">Thrown if a negative value is passed for purchase price.</exception>
        /// <exception cref="ProductMarkUpException">Thrown if a negative value is passed for mark-up.</exception>
        /// <exception cref="ProductAmountException">Thrown if a negative value is passed for amount.</exception>
        ///<exception cref="ProductNameException">Thrown if a null string was passed.</exception>
        public Electronics(double purchasePrice, string name, double markUp, int amount)
            : base(purchasePrice, name, markUp, amount) {/* TypeOfProduct = "Electronics";*/ }

        /// <summary>
        /// Operation for subtracting an integer from an object of the Food type.
        /// </summary>
        /// <param name="electronics">The object to subtract from.</param>
        /// <param name="amount">Subtrahend.</param>
        /// <returns>Creates a new Electronics object with the same parameters as the one being passed, but the number of units of the object being created is equal to 
        /// the difference between the number of units of the passed object and 
        /// the subtracted value.</returns>
        /// <exception cref="ProductAmountException">Thrown if the subtracted number is greater than the number of units of Food.</exception>
        public static Electronics operator -(Electronics electronics, int amount)
        {
            if (electronics == null)
                throw new NullReferenceException();
            if (electronics.Amount - amount < 0)
                throw new ProductAmountException("Attempt to create an object with a negative number of product instances");

            return new Electronics(electronics.PurchasePrice, electronics.Name, electronics.MarkUp, electronics.Amount - amount);
        }
        /// <summary>
        /// Operation of adding two objects of the Electronics type whith equals names.
        /// </summary>
        /// <param name="one">first summand.</param>
        /// <param name="two">second summand.</param>
        /// <returns>A new item of the Electronics type with the same name as the summands in an 
        /// amount equal to the total amount of the first and second
        /// summands and the price and mark-up equal to the arithmetic mean of the same parameters in the summands.</returns>
        ///<exception cref="ProductNameException">Is thrown if the objects have different names.</exception>
        public static Electronics operator +(Electronics one, Electronics two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Electronics((one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
        }

        /// <summary>
        /// Operation of explicit conversion to the Food type.
        /// </summary>
        /// <param name="product">Object to convert.</param>
        public static explicit operator Food(Electronics product)
        {
            return new Food(product.PurchasePrice, product.Name + "-food", product.MarkUp, product.Amount);
        }

        /// <summary>
        /// Operation of explicit conversion to the Clothes type.
        /// </summary>
        /// <param name="product">Object to convert.</param>
        public static explicit operator Clothes(Electronics product)
        {
            return new Clothes(product.PurchasePrice, product.Name + "-clothes", product.MarkUp, product.Amount);
        }
    }
}
