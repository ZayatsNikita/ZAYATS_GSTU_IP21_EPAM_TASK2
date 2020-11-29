using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.FactoriesForSubclassesOfProducts
{
    class FoodFactory
    {
        public Product CreateProduct(double purchasePrice, string name, double markUp, uint amount)
        {
            return new Food(purchasePrice, name, markUp, amount);
        }
    }
}
