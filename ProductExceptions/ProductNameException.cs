using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    /// <summary>
    /// Class that is used if there is an error with the product name
    /// </summary>
    public class ProductNameException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ProductNameException class
        /// </summary>
        public ProductNameException()
            : base("An incorrect product name was entered") { }
        /// <summary>
        /// Initializes a new instance of the ProductNameException class with specific error message
        /// </summary>
        public ProductNameException(string message)
            : base(message) { }

    }
}
