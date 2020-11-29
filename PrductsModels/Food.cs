using System;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    public class Food : Product
    {
        public Food(double purchasePrice, string name, double markUp, uint amount)
            : base(purchasePrice, name, markUp, amount) {; }


        public static Food operator -(Food food, int amount)
        {
            if (food == null)
                throw new NullReferenceException();
            if (food.Amount - amount < 0)
                throw new ProductPriceException("Attempt to create an object with a negative number of product instances");

            return new Food(food.PurchasePrice,food.Name,food.MarkUp,food.Amount-(uint)amount);
        }
        public static Food operator +(Food one, Food two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Food((one.PurchasePrice+two.PurchasePrice)/2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount+two.Amount);
        }
    }
}А
