namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Ctor_ValidData_ShouldInitialize()
        {
            Car car = new("Honda", "Civic", 9.5, 45);

            Assert.That(car, Is.Not.Null);
            Assert.That(car.Make == "Honda");
            Assert.That(car.Model == "Civic");
            Assert.That(car.FuelConsumption == 9.5);
            Assert.That(car.FuelCapacity == 45);
            Assert.That(car.FuelAmount == 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_IsNullOrEmpty_ThrowsException(string input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Car(input, "Civic", 9.5, 45));
            Assert.That(ae.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Model_IsNullOrEmpty_ThrowsException(string input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Car("Honda", input, 9.5, 45));
            Assert.That(ae.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumption_ZeroOrNegative_ThrowsException(double input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Car("Honda", "Civic", input, 45));
            Assert.That(ae.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacity_ZeroOrNegative_ThrowsException(double input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Car("Honda", "Civic", 9.5, input));
            Assert.That(ae.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_ValidAmount_CarIsRefueled()
        {
            Car car = new("Honda", "Civic", 9.5, 45);
            car.Refuel(20);

            Assert.That(car.FuelAmount, Is.EqualTo(20));
        }

        [Test]
        public void Refuel_AmountMoreThanCapacity_CarIsRefueledToMax()
        {
            Car car = new("Honda", "Civic", 9.5, 45);
            car.Refuel(60);

            Assert.That(car.FuelAmount, Is.EqualTo(45));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ZeroOrNegative_ThrowsException(double input)
        {
            Car car = new("Honda", "Civic", 9.5, 45);

            ArgumentException ae = Assert.Throws<ArgumentException>(() => car.Refuel(input));
            Assert.That(ae.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Drive_ValidDistance_FuelAmountShouldDecrease()
        {
            Car car = new("Honda", "Civic", 9.5, 45);
            double distance = 150;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            car.Refuel(40);

            double fuelLeft = car.FuelAmount - fuelNeeded;
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(fuelLeft));
        }

        [Test]
        public void Drive_NotEnoughFuel_ThrowsException()
        {
            Car car = new("Honda", "Civic", 9.5, 45);
            double distance = 150;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            car.Refuel(10);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.That(ioe.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}