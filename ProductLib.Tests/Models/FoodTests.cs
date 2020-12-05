using NUnit.Framework;

namespace ProductLib.Tests
{
    [TestFixture]
    class FoodTests
    {
        [Test]
        public void OperatorSum_TwoCorrectFood_NewFoodWithTheSameNameAsTheFirstWwoFoodsInAnAmountEqualToTheTotalNumberOfTheFirstTwoFoodsTheMarkupAndPurchasePriceEqualToTheArithmeticAverageOfTheseValuesInTheFirstTwoFoods()
        {
            Food firstFood = new Food(13.7, "pasta", 18.5, 5);
            Food seconFood = new Food(16.3, "pasta", 11.5, 5);
            Food actual = firstFood + seconFood;
            Food expectedFood = new Food(15, "pasta", 15, 10);
            Assert.AreEqual(expectedFood, actual);
        }
        public void OperatorSum_TwoFoodsWithDifferentNames_ProductNameExceptionThrow()
        {
            Food firstFood = new Food(13.7, "pasta", 18.5, 5);
            Food seconFood = new Food(16.3, "buckwheat", 11.5, 5);
            bool actual = false;
            try
            {
                Food thirdFood = firstFood + seconFood;
            }
            catch (ProductLib.ProductExceptions.ProductNameException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void OperatorSubtraction_CorrectNumber_NewFoodWhoseQuantityIsEqualToTheDifferenceBetweenTheQuantityOfTheFirstProductAndTheSubtractedNumber()
        {
            Food firstFood = new Food(150,"pasta",5,11);
            int subtractedNumber = 10;
            Food actual = firstFood - subtractedNumber;
            Food expectedFood = new Food(150, "pasta", 5, 1);
            Assert.AreEqual(expectedFood, actual);
        }

        [Test]
        public void OperatorSubtraction_FoodInQuantityLessThatTheSubtractedNumber_ProductAmountException()
        {
            Food firstFood = new Food(150, "pasta", 5, 11);
            int subtractedNumber = 12;
            bool actual = false;
            try
            {
                Food secondFood = firstFood - subtractedNumber;
            }
            catch (ProductExceptions.ProductAmountException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void CastOperator_FoodToClothes_NewClothes()
        {
            Food food = new Food(150, "pasta", 5, 11);
            Clothes clothes = (Clothes)food;
            Assert.IsNotNull(clothes);
        }

        [Test]
        public void CastOperator_FoodTo_ExpectsNewElectronics()
        {
            Food food = new Food(150, "pasta", 5, 11);
            Electronics electronics = (Electronics)food;
            Assert.IsNotNull(electronics);
        }

    }
}