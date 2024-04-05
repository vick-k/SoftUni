using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class CoffeeMatTests
    {
        [Test]
        public void Ctor_ValidData()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);

            Assert.IsNotNull(coffeeMat);
            Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(20));
            Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(10));
            Assert.That(coffeeMat.Income, Is.EqualTo(0));
        }

        [Test]
        public void FillWaterTank_Full()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);
            coffeeMat.FillWaterTank();

            Assert.That(coffeeMat.FillWaterTank(), Is.EqualTo("Water tank is already full!"));
        }

        [Test]
        public void FillWaterTank_Empty()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);

            Assert.That(coffeeMat.FillWaterTank(), Is.EqualTo("Water tank is filled with 20ml"));
        }

        [Test]
        public void AddDrink_True()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);

            Assert.That(coffeeMat.AddDrink("coffee", 1.5), Is.True);
        }

        [Test]
        public void AddDrink_False_DuplicatedName()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);
            coffeeMat.AddDrink("coffee", 1.5);

            Assert.That(coffeeMat.AddDrink("coffee", 1.5), Is.False);
        }

        [Test]
        public void AddDrink_False_NoSpace()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 2);
            coffeeMat.AddDrink("coffee", 1.5);
            coffeeMat.AddDrink("tea", 1.2);

            Assert.That(coffeeMat.AddDrink("water", 0.5), Is.False);
        }

        [Test]
        public void BuyDrink_EmptyTank()
        {
            CoffeeMat coffeeMat = new CoffeeMat(20, 10);
            coffeeMat.AddDrink("coffee", 1.5);

            Assert.That(coffeeMat.BuyDrink("coffee"), Is.EqualTo("CoffeeMat is out of water!"));
        }

        [Test]
        public void BuyDrink_OutOfWater()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("coffee", 1.5);
            coffeeMat.AddDrink("tea", 1.2);
            coffeeMat.BuyDrink("tea");

            Assert.That(coffeeMat.BuyDrink("coffee"), Is.EqualTo("CoffeeMat is out of water!"));
        }

        [Test]
        public void BuyDrink_NoSuchDrink()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);
            coffeeMat.AddDrink("tea", 1.2);
            coffeeMat.FillWaterTank();

            Assert.That(coffeeMat.BuyDrink("coffee"), Is.EqualTo("coffee is not available!"));
        }

        [Test]
        public void BuyDrink_Success()
        {
            CoffeeMat coffeeMat = new CoffeeMat(200, 10);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("coffee", 1.5);

            Assert.That(coffeeMat.BuyDrink("coffee"), Is.EqualTo("Your bill is 1.50$"));
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat coffeeMat = new CoffeeMat(200, 10);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("coffee", 1.5);
            coffeeMat.AddDrink("tea", 1.2);
            coffeeMat.BuyDrink("coffee");
            coffeeMat.BuyDrink("tea");

            Assert.That(coffeeMat.Income, Is.EqualTo(2.7));
            Assert.That(coffeeMat.CollectIncome(), Is.EqualTo(2.7));
            Assert.That(coffeeMat.Income, Is.EqualTo(0));
        }
    }
}