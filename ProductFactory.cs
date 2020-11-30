using System;
using System.Collections.Generic;
using System.Text;
using ProductLib.FactoriesForSubclassesOfProducts;
namespace ProductLib
{
    public class ProductFactory
    {
        public static Product CreateProduct(string typeName, double purchasePrice, string name, double markUp, uint amount)
        {
            switch(typeName)
            {
                case "Food":
                      return FoodFactory.CreateProduct(purchasePrice, name, markUp, amount);
                case "Electronics":
                     return ElectronicsFactory.CreateProduct(purchasePrice,  name,  markUp,  amount);
                case "Wear":
                    return WearFactory.CreateProduct(purchasePrice, name, markUp, amount);
            }
            throw new ArgumentException("Wrong name was entered");
        }
    }
}
