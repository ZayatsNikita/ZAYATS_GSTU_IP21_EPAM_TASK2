using System;

namespace ProductLib.ProductExceptions
{
    /// <summary>
    /// Class that is used if there is an error with the product mark-up
    /// </summary>
    public class ProductMarkUpException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ProductMarkUpException class
        public ProductMarkUpException()
            : base("The mark-up parameter is out of bounds") { }
        /// <summary>
        /// Initializes a new instance of the ProductMarkUpException class with specific error message
        /// </summary>
        public ProductMarkUpException(string message)
            : base(message) { }

    }
}
