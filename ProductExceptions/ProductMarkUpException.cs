using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    public class ProductMarkUpException : ArgumentException
    {
        public ProductMarkUpException()
            : base("The mark-up parameter is out of bounds") { }
        public ProductMarkUpException(string message)
            : base(message) { }

    }
}
