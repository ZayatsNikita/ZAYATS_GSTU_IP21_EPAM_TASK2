using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.FactoriesForSubclassesOfProducts
{
    class WearFactory
    {
        public Product CreateProduct(double purchasePrice, string name, double markUp, uint amount)
        {
            return new Wear(purchasePrice, name, markUp, amount);
        }
    }
}
