using System;
using System.Collections.Generic;
using System.Text;

namespace ProductLib.FactoriesForSubclassesOfProducts
{
    class FoodFactory
    {
        public static Product CreateProduct(double purchasePrice, string name, double markUp, int amount)
        {
            return new Food(purchasePrice, name, markUp, amount);
        }
    }
}
