using NUnit.Framework;

namespace ProductLib.Tests
{
    [TestFixture]
    class ClothesTests
    {
        [Test]
        public void OperatorSum_TwoCorrectClothes_NewClothesWithTheSameNameAsTheFirstTwoClothesInAnAmountEqualToTheTotalNumberOfTheFirstTwoClothesTheMarkupAndPurchasePriceEqualToTheArithmeticAverageOfTheseValuesInTheFirstTwoClothes()
        {
            Clothes firstClothes = new Clothes(13.7, "jumper", 18.5, 5);
            Clothes seconClothe = new Clothes(16.3, "jumper", 11.5, 5);
            Clothes actual = firstClothes + seconClothe;
            Clothes expected = new Clothes(15, "jumper", 15, 10);
            Assert.AreEqual(expected, actual);
        }
        public void OperatorSum_TwoClothesWithDifferentNames_ProductNameExceptionThrow()
        {
            Clothes firstClothes = new Clothes(13.7, "jumper", 18.5, 5);
            Clothes seconClothe = new Clothes(16.3, "sweater", 11.5, 5);
            bool actual = false;
            try
            {
                Clothes thirdClothes = firstClothes + seconClothe;
            }
            catch (ProductExceptions.ProductNameException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void OperatorSubtraction_CorrectNumber_NewClothesWhoseQuantityIsEqualToTheDifferenceBetweenTheQuantityOfTheFirstProductAndTheSubtractedNumber()
        {
            Clothes firstClothes = new Clothes(150, "jumper", 5, 11);
            int subtractedNumber = 10;
            Clothes actual = firstClothes - subtractedNumber;
            Clothes expectedClothes = new Clothes(150, "jumper", 5, 1);
            Assert.AreEqual(expectedClothes, actual);
        }

        [Test]
        public void OperatorSubtraction_ClothesInQuantityLessThatTheSubtractedNumber_ProductAmountException()
        {
            Clothes firstClothes = new Clothes(150, "jumper", 5, 11);
            int subtractedNumber = 12;
            bool actual = false;
            try
            {
                Clothes secondClothes = firstClothes - subtractedNumber;
            }
            catch (ProductLib.ProductExceptions.ProductAmountException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void CastOperator_ClothesToFood_NewClothes()
        {
            Clothes clothes = new Clothes(150, "jumper", 5, 11);
            Food food = (Food)clothes;
            Assert.IsNotNull(food);
        }

        [Test]
        public void CastOperator_ClothesToElectronics_ExpectsNewElectronics()
        {
            Clothes clothes = new Clothes(150, "jumper", 5, 11);
            Electronics electronics = (Electronics)clothes;
            Assert.IsNotNull(electronics);
        }

    }
}