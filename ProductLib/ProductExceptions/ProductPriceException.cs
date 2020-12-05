using System;

namespace ProductLib.ProductExceptions
{
    /// <summary>
    /// Class that is used if there is an error with the product pursharing price
    /// </summary>
    public class ProductPriceException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ProductPriceException class
        /// </summary>
        public ProductPriceException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the ProductPriceException class with specific error message
        /// </summary>
        public ProductPriceException()
            : base("The price parameter is out of bounds") { }

    }
}
