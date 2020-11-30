using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.FactoriesForSubclassesOfProducts
{
    class WearFactory
    {
        public static Product CreateProduct(double purchasePrice, string name, double markUp, int amount)
        {
            return new Wear(purchasePrice, name, markUp, amount);
        }
    }
}
