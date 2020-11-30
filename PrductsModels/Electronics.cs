using System;
using ProductLib.ProductExceptions;

namespace ProductLib
{
    public class Electronics : Product
    {
        public Electronics(double purchasePrice, string name, double markUp, uint amount)
            : base(purchasePrice, name, markUp, amount) {; }
        public static Electronics operator -(Electronics electronics, int amount)
        {
            if (electronics == null)
                throw new NullReferenceException();
            if (electronics.Amount - amount < 0)
                throw new ProductPriceException("Attempt to create an object with a negative number of product instances");

            return new Electronics(electronics.PurchasePrice, electronics.Name, electronics.MarkUp, electronics.Amount - (uint)amount);
        }
        public static Electronics operator +(Electronics one, Electronics two)
        {
            if (one == null || two == null)
                throw new NullReferenceException();
            if (one.Name != two.Name)
                throw new ProductNameException();
            return new Electronics((one.PurchasePrice + two.PurchasePrice) / 2, one.Name, (one.MarkUp + two.MarkUp) / 2, one.Amount + two.Amount);
        }


        public static implicit operator Food(Electronics product)
        {
            return new Food(product.PurchasePrice, product.Name + "-food", product.MarkUp, product.Amount);
        }
        public static implicit operator Wear(Electronics product)
        {
            return new Wear(product.PurchasePrice, product.Name + "-wear", product.MarkUp, product.Amount);
        }
    }
}
