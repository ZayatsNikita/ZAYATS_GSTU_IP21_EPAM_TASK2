using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    class ProductPriceException : ArgumentException
    {
        public ProductPriceException(string message)
            : base(message) { }
        public ProductPriceException()
            : base("The price parameter is out of bounds") { }

    }
}
