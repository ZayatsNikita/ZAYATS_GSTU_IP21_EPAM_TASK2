using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    class ProductMarkUpException : ArgumentException
    {
        ProductMarkUpException()
            : base("The mark-up parameter is out of bounds") { }
        ProductMarkUpException(string message)
            : base(message) { }

    }
}
