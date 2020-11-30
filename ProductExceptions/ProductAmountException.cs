using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.ProductExceptions
{
    public class ProductAmountException : ArgumentException
    {
        public ProductAmountException()
            : base("The mark-up parameter is out of bounds") { }
        public ProductAmountException(string message)
            : base(message) { }

    }
}
