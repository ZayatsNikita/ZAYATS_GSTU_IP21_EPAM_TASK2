using System;
using System.Collections.Generic;
using System.Text;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    /// <summary>
    /// Class describing clothing
    /// </summary>
    public class Clothes : Product
    {
        /// <summary>
        /// Default constructor.
        /// <para>Properties PurchasePrice, MarkUp, Amount are assigned a null value, and the name field is assigned the value of a zero-length string.</para>
        /// </summary>
        public Clothes() : base()
        { }
        /// <summary>
        /// Clothes constrictor with params.
        /// </summary>
        /// <param name="purchasePrice">Purchase price of clothes.</param>
        /// <param name="name">Name of clothes.</param>
        /// <param name="markUp">Mark-Up of single clothes item.</param>
        /// <param name="amount">Amount of clothes.</param>
        /// /// <exception cref="ProductPriceException">Thrown if a negative value is passed for purchase price.</exception>
        /// <exception cref="ProductMarkUpException">Thrown if a negative value is passed for mark-up.</exception>
        /// <exception cref="ProductAmountException">Thrown if a negative value is passed for amount.</exception>
        ///<exception cref="ProductNameException">Thrown if a null string was passed.</exception>
        public Clothes(double purchasePrice, string name, double markUp, int amount)
            : base(purchasePrice, name, markUp, amount) {; }


        /// <summary>
        /// Operation for subtracting an integer from an object of the Clothing type.
        /// </summary>
        /// <param name="clothes">The object to subtract from.</param>
        /// <param name="amount">subtrahend.</param>
        /// <returns>Creates a new Clothing object with the same parameters as the one being passed, but the number of units of the object being created is equal to 
        /// the difference between the number of units of the passed object and 
        /// the subtracted value.</returns>
        /// <exception cref="ProductAmountException">Thrown if the subtracted number is greater than the number of units of Clothing.</exception>
        public static Clothes operator -(Clothes clothes, int amount)
        {
            if (clothes == null)
                throw new NullReferenceException();
            if (clothes.Amount - amount < 0)
                throw new ProductAmountException("Attempt to create an object with a negative number of product instances");
            return new Clothes(clothes.PurchasePrice, clothes.Name, clothes.MarkUp, clothes.Amount - amount);
        }
        /// <summary>
        /// Operation of adding two objects of the Clothing type whith equals names.
        /// </summary>
        /// <param name="one">first summand.</param>
        /// <param name="two">second summand.</param>
        /// <returns>A new item of the Clothing type with the same name as the summands in an 
        /// amount equal to the total amount of the first and second
        /// summands and the price and mark-up equal to the arithmetic mean of the same parameters in the summands.</returns>
        ///<exception cref="ProductNameException">Is thrown if the objects have different names.</exception>
        public static Clothes operator +(Clothes one, Clothes two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Clothes((one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
        }

        /// <summary>
        /// Operation of explicit conversion to the Food type.
        /// </summary>
        /// <param name="product">Object to convert.</param>
        public static explicit operator Food(Clothes product)
        {
            return new Food(product.PurchasePrice, product.Name + "-food", product.MarkUp, product.Amount);
        }
        /// <summary>
        /// Operation of explicit conversion to the Electronics type.
        /// </summary>
        /// <param name="product">Object to convert.</param>
        public static explicit operator Electronics(Clothes product)
        {
            return new Electronics(product.PurchasePrice, product.Name + "-electronics", product.MarkUp, product.Amount);
        }
    }
}
