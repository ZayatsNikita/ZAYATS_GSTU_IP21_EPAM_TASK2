using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib
{
    public class ProductFactory
    {
        public static Product CreateProduct(string typeName, double purchasePrice, string name, double markUp, uint amount)
        {
            switch(typeName)
            {
                case "Food":

                    break;
                case "Electronics":

                    break;
                case "Wear":

                    break;
            }
        }
    }
}
