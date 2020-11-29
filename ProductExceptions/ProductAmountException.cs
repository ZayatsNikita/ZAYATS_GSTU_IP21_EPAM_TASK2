using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    class ProductAmountException : ArgumentException
    {
        ProductAmountException()
            : base("The mark-up parameter is out of bounds") { }
        ProductAmountException(string message)
            : base(message) { }

    }
}
