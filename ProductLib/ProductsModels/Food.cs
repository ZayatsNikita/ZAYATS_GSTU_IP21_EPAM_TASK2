using System;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    /// <summary>
    /// Class describing food
    /// </summary>
    public class Food : Product
    {
        /// <summary>
        /// Default constructor.
        /// <para>Properties PurchasePrice, MarkUp, Amount are assigned a null value, and the name field is assigned the value of a zero-length string.</para>
        /// </summary>
        public Food() : base()
        { }
        /// <summary>
        /// Food constrictor with params.
        /// </summary>
        /// <param name="purchasePrice">Purchase price of Food.</param>
        /// <param name="name">Name of Food.</param>
        /// <param name="markUp">Mark-Up of single Food item.</param>
        /// <param name="amount">Amount of Food.</param>
        /// /// <exception cref="ProductPriceException">Thrown if a negative value is passed for purchase price.</exception>
        /// <exception cref="ProductMarkUpException">Thrown if a negative value is passed for mark-up.</exception>
        /// <exception cref="ProductAmountException">Thrown if a negative value is passed for amount.</exception>
        ///<exception cref="ProductNameException">Thrown if a null string was passed for name.</exception>

        public Food(double purchasePrice, string name, double markUp, int amount)
            : base(purchasePrice, name, markUp, amount) {; }

        /// <summary>
        /// Operation for subtracting an integer from an object of the Food type.
        /// </summary>
        /// <param name="food">The object to subtract from.</param>
        /// <param name="amount">subtrahend.</param>
        /// <returns>Creates a new Food object with the same parameters as the one being passed, but the number of units of the object being created is equal to 
        /// the difference between the number of units of the passed object and 
        /// the subtracted value.</returns>
        /// <exception cref="ProductAmountException">Thrown if the subtracted number is greater than the number of units of Food.</exception>
        public static Food operator -(Food food, int amount)
        {
            if (food == null)
                throw new NullReferenceException();
            if (food.Amount - amount < 0)
                throw new ProductAmountException("Attempt to create an object with a negative number of product instances");

            return new Food(food.PurchasePrice, food.Name, food.MarkUp, food.Amount - amount);
        }
        /// <summary>
        /// Operation of adding two objects of the Food type whith equals names.
        /// </summary>
        /// <param name="one">first summand.</param>
        /// <param name="two">second summand.</param>
        /// <returns>A new item of the Food type with the same name as the summands in an 
        /// amount equal to the total amount of the first and second
        /// summands and the price and mark-up equal to the arithmetic mean of the same parameters in the summands.</returns>
        ///<exception cref="ProductNameException">Is thrown if the objects have different names.</exception>

        public static Food operator +(Food one, Food two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Food((one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
        }

        /// <summary>
        /// Operation of explicit conversion to the Electronics type.
        /// </summary>
        /// <param name="product">Object to convert.</param>
        public static explicit operator Electronics(Food product)
        {
            return new Electronics(product.PurchasePrice, product.Name + "-electronics", product.MarkUp, product.Amount);
        }

        /// <summary>
        /// Operation of explicit conversion to the Clothes type
        /// </summary>
        /// <param name="product">Object to convert</param>
        public static explicit operator Clothes(Food product)
        {
            return new Clothes(product.PurchasePrice, product.Name + "-clothes", product.MarkUp, product.Amount);
        }
    }
}
