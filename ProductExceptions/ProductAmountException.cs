using System;

namespace ProductLib.ProductExceptions
{
    /// <summary>
    /// Class that is used if there is an error with the product amount
    /// </summary>
    public class ProductAmountException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ProductAmountException class
        /// </summary>
        public ProductAmountException()
            : base("Amount value has exceeded the acceptable limits") { }
        /// <summary>
        /// Initializes a new instance of the ProductAmountException class with specific error message
        /// </summary>
        public ProductAmountException(string message)
            : base(message) { }

    }
}
