using NUnit.Framework;
using ProductLib.ProductExceptions;
namespace ProductLib.Tests
{
    [TestFixture]
    public class ProductTests
    {

        [Test]
        public void GetFullPriceOfAllProductsTest_CorrectProdct_ProductPPricePlusProductMarkUpMulProductAmouunt()
        {
            Product data = new Electronics(302.3, "Redmi Note 8", 100.8, 10);
            double actual = data.GetFullPriceOfAllProducts();
            double expects = data.Amount * (data.MarkUp + data.PurchasePrice);
            Assert.AreEqual(expects, actual, 0.01);
        }
        [Test]
        public void GetFullPriceOfSingleItemOfProductsTest_CorrectProdct_ProductPPricePlusProductMarkUp()
        {
            Product data = new Electronics(302.3, "Redmi Note 8", 100.8, 10);

            double actual = data.GetFullPriceOfSingleProduct();

            double expects = data.MarkUp + data.PurchasePrice;

            Assert.AreEqual(expects, actual, 0.01);
        }
        [Test]
        public void CastOperator_ProductToInt_TheFullCostOfTheProductInKopecksà()
        {
            Product product = new Electronics(150, "samsung s6", 5, 11);
            
            int expected = (int)(product.GetFullPriceOfAllProducts() * 100);

            Assert.AreEqual(expected,(int)product);
        }
        [Test]
        public void CastOperator_ProductToDouble_TheFullCostOfTheProductInRubela()
        {
            Product product = new Electronics(150, "samsung s6", 5, 11);

            double expected = product.GetFullPriceOfAllProducts();

            Assert.AreEqual(expected, (double)product,0.1);
        }
        [TestCase("Electronics","abbc",13.5,-5,10)]
        [TestCase("Food", "abbc",13.5,-5,10)]
        [TestCase("Clothes", "abbc",13.5,-5,10)]
        public void ObjecåÑreation_NegativeMarkUp_ProductMarkUpExceptionThrow(string type, string name, double pursheringPrice, double markUp, int amount)
        {
            Product product;
            bool actual = false;
            try
            {
                switch (type)
                {
                    case "Electronics":
                        product = new Electronics(pursheringPrice, name, markUp, amount);
                        break;
                    case "Food":
                        product = new Food(pursheringPrice, name, markUp, amount);
                        break;
                    case "Clothes":
                        product = new Clothes(pursheringPrice, name, markUp, amount);
                        break;
                }

                
            }
            catch (ProductMarkUpException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase("Electronics", "abbc", -13.5, 5, 10)]
        [TestCase("Food", "abbc", -13.5, 5, 10)]
        [TestCase("Clothes", "abbc", -13.5, 5, 10)]
        public void ObjecåÑreation_NegativePPprice_ProductPriceExceptionThrow(string type, string name, double pursheringPrice, double markUp, int amount)
        {
            Product product;
            bool actual = false;
            try
            {
                switch (type)
                {
                    case "Electronics":
                        product = new Electronics(pursheringPrice, name, markUp, amount);
                        break;
                    case "Food":
                        product = new Food(pursheringPrice, name, markUp, amount);
                        break;
                    case "Clothes":
                        product = new Clothes(pursheringPrice, name, markUp, amount);
                        break;
                }
            }
            catch (ProductPriceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase("Electronics", "abbc", 13.5, 5, -10)]
        [TestCase("Food", "abbc", 13.5, 5, -10)]
        [TestCase("Clothes", "abbc", 13.5, 5, -10)]
        public void ObjecåÑreation_NegativeAmount_ProductAmountExceptionThrow(string type, string name, double pursheringPrice, double markUp, int amount)
        {
            Product product;
            bool actual = false;
            try
            {
                switch (type)
                {
                    case "Electronics":
                        product = new Electronics(pursheringPrice, name, markUp, amount);
                        break;
                    case "Food":
                        product = new Food(pursheringPrice, name, markUp, amount);
                        break;
                    case "Clothes":
                        product = new Clothes(pursheringPrice, name, markUp, amount);
                        break;
                }
            }
            catch (ProductAmountException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase("Electronics", null, 13.5, 5, -10)]
        [TestCase("Food", null, 13.5, 5, -10)]
        [TestCase("Clothes", null, 13.5, 5, -10)]
        public void ObjecåÑreation_NullName_ProductAmountExceptionThrow(string type, string name, double pursheringPrice, double markUp, int amount)
        {
            Product product;
            bool actual = false;
            try
            {
                switch (type)
                {
                    case "Electronics":
                        product = new Electronics(pursheringPrice, name, markUp, amount);
                        break;
                    case "Food":
                        product = new Food(pursheringPrice, name, markUp, amount);
                        break;
                    case "Clothes":
                        product = new Clothes(pursheringPrice, name, markUp, amount);
                        break;
                }
            }
            catch (ProductNameException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

    }

}