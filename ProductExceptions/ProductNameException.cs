using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    public class ProductNameException : ArgumentException
    {
        public ProductNameException()
            : base("An incorrect product name was entered") { }
        public ProductNameException(string message)
            : base(message) { }

    }
}
