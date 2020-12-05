using NUnit.Framework;

namespace ProductLib.Tests.Processing
{
    class ValidationsTests
    {
        [TestCase("Clothes","abc",10,5.5,13)]
        [TestCase("Electronics", "abc",10,5.5,13)]
        [TestCase("Food", "abc",10,5.5,13)]
        public void IsProductTest_CorrectValue_True(string typeOfProduct, string name, double pPrice, double markup, int amount)
        {
            bool actual = ProductValidation.Validation.IsProduct(typeOfProduct,  name, pPrice, markup, amount);
            Assert.IsTrue(actual);
        }
        [TestCase("Clothess", "abc", 10, 5.5, 13)]
        [TestCase("Electrofnics", "abc", 10, 5.5, 13)]
        [TestCase("Foogd", "abc", 10, 5.5, 13)]
        [TestCase("Clothes", "abc", -10, 5.5, 13)]
        [TestCase("Electronics", "abc", 10, -5.5, 13)]
        [TestCase("Food", "abc", 10, 5.5, -13)]
        public void IsProductTest_WrongValue_True(string typeOfProduct, string name, double pPrice, double markup, int amount)
        {
            bool actual = ProductValidation.Validation.IsProduct(typeOfProduct, name, pPrice, markup, amount);
            Assert.IsFalse(actual);
        }
    }
}


