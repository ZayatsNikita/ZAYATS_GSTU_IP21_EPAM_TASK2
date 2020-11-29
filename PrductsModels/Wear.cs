using System;
using System.Collections.Generic;
using System.Text;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    public class Wear : Product
    {
        public Wear(double purchasePrice, string name, double markUp, uint amount)
            : base(purchasePrice, name, markUp, amount) {; }
        public static Wear operator -(Wear wear, int amount)
        {
            if (wear == null)
                throw new NullReferenceException();
            if (wear.Amount - amount < 0)
                throw new ProductPriceException("Attempt to create an object with a negative number of product instances");
            return new Wear(wear.PurchasePrice, wear.Name, wear.MarkUp, wear.Amount - (uint)amount);
        }
        public static Wear operator +(Wear one, Wear two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Wear((one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
        }
    }
}
