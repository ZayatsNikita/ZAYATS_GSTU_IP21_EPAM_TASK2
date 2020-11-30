using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.FactoriesForSubclassesOfProducts
{
    internal class ElectronicsFactory
    {
        public static Electronics CreateProduct(double purchasePrice, string name, double markUp, uint amount)
        {
            return new Electronics(purchasePrice, name, markUp, amount);
        }
    }
}
