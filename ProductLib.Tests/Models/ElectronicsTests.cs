using NUnit.Framework;

namespace ProductLib.Tests
{
    [TestFixture]
    class ElectronicsTests
    {
        [Test]
        public void OperatorSum_TwoCorrectElectronics_NewElectronicsWithTheSameNameAsTheFirstTwoElectronicsInAnAmountEqualToTheTotalNumberOfTheFirstTwoElectronicsTheMarkupAndPurchasePriceEqualToTheArithmeticAverageOfTheseValuesInTheFirstTwoElectronics()
        {
            Electronics firstElectronics = new Electronics(13.7, "samsung s6", 18.5, 5);
            Electronics secondElectronics = new Electronics(16.3, "samsung s6", 11.5, 5);
            Electronics actual = firstElectronics + secondElectronics;
            Electronics expected = new Electronics(15, "samsung s6", 15, 10);
            Assert.AreEqual(expected, actual);
        }
        public void OperatorSum_TwoElectronicsWithDifferentNames_ProductNameExceptionThrow()
        {
            Electronics firstElectronics = new Electronics(13.7, "samsung s6", 18.5, 5);
            Electronics secondElectronics = new Electronics(16.3, "iphone 6", 11.5, 5);
            bool actual = false;
            try
            {
                Electronics thirdElectronics = firstElectronics + secondElectronics;
            }
            catch (ProductExceptions.ProductNameException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void OperatorSubtraction_CorrectNumber_NewElectronicsWhoseQuantityIsEqualToTheDifferenceBetweenTheQuantityOfTheFirstProductAndTheSubtractedNumber()
        {
            Electronics firstElectronics = new Electronics(150, "samsung s6", 5, 11);
            int subtractedNumber = 10;
            Electronics actual = firstElectronics - subtractedNumber;
            Electronics expectedElectronics = new Electronics(150, "samsung s6", 5, 1);
            Assert.AreEqual(expectedElectronics, actual);
        }

        [Test]
        public void OperatorSubtraction_ElectronicsInQuantityLessThatTheSubtractedNumber_ProductAmountException()
        {
            Electronics firstElectronics = new Electronics(150, "samsung s6", 5, 11);
            int subtractedNumber = 12;
            bool actual = false;
            try
            {
                Electronics secondElectronics = firstElectronics - subtractedNumber;
            }
            catch (ProductLib.ProductExceptions.ProductAmountException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void CastOperator_ElectronicsToFood_NewElectronics()
        {
            Electronics electronics = new Electronics(150, "samsung s6", 5, 11);
            Food food = (Food)electronics;
            Assert.IsNotNull(food);
        }

        [Test]
        public void CastOperator_ElectronicsToClothes_ExpectsNewElectronics()
        {
            Electronics electronics = new Electronics(150, "samsung s6", 5, 11);
            Clothes clothes = (Clothes)electronics;
            Assert.IsNotNull(clothes);
        }

    }
}