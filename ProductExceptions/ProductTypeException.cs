using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{   /// <summary>
    /// Class that is used if there is an error with the product type
    /// </summary>
    public class ProductTypeException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ProductTypeException class
        /// </summary>
        public ProductTypeException(string message)
            : base(message) { }
        /// <summary>
        /// Initializes a new instance of the ProductTypeException class with specific error message
        /// </summary>
        public ProductTypeException()
            : base("Mismatch between the expected and received types") { }

    }
}
