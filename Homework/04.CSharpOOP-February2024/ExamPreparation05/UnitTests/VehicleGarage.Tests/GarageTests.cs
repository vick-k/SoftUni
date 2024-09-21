using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_Garage_ValidData()
        {
            Garage garage = new Garage(5);

            Assert.IsNotNull(garage);
            Assert.That(garage.Capacity, Is.EqualTo(5));
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_Vehicle_ValidData()
        {
            Vehicle car = new Vehicle("Honda", "Civic", "W123");

            Assert.IsNotNull(car);
            Assert.That(car.Brand, Is.EqualTo("Honda"));
            Assert.That(car.Model, Is.EqualTo("Civic"));
            Assert.That(car.LicensePlateNumber, Is.EqualTo("W123"));
            Assert.That(car.BatteryLevel, Is.EqualTo(100));
            Assert.That(car.IsDamaged, Is.False);
        }

        [Test]
        public void AddVehicle_FullCapacity()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            Vehicle car2 = new("Honda", "S2000", "W234");
            Vehicle car3 = new("Honda", "Accord", "W345");

            garage.AddVehicle(car1);
            garage.AddVehicle(car2);

            Assert.That(garage.AddVehicle(car3), Is.False);
        }

        [Test]
        public void AddVehicle_DuplicatedLicensePlateNumber()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            Vehicle car2 = new("Honda", "S2000", "W123");

            garage.AddVehicle(car1);

            Assert.That(garage.AddVehicle(car2), Is.False);
        }

        [Test]
        public void AddVehicle_Success()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");

            Assert.That(garage.AddVehicle(car1), Is.True);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(garage.Vehicles.Contains(car1), Is.True);
        }

        [Test]
        public void ChargeVehicles()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            Vehicle car2 = new("Honda", "S2000", "W234");

            garage.AddVehicle(car1);
            garage.AddVehicle(car2);
            garage.DriveVehicle("W123", 20, false);

            Assert.That(garage.ChargeVehicles(80), Is.EqualTo(1));
        }

        [Test]
        public void DriveVehicle_Success()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            garage.AddVehicle(car1);
            garage.DriveVehicle("W123", 20, false);

            Assert.That(car1.BatteryLevel, Is.EqualTo(80));
            Assert.That(car1.IsDamaged, Is.False);
        }

        [Test]
        public void DriveVehicle_Success_WithAccident()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            garage.AddVehicle(car1);
            garage.DriveVehicle("W123", 20, true);

            Assert.That(car1.BatteryLevel, Is.EqualTo(80));
            Assert.That(car1.IsDamaged, Is.True);
        }

        [Test]
        public void DriveVehicle_Fail_DamagedCar()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            car1.IsDamaged = true;
            garage.AddVehicle(car1);
            garage.DriveVehicle("W123", 20, true);

            Assert.That(car1.BatteryLevel, Is.EqualTo(100));
            Assert.That(car1.IsDamaged, Is.True);
        }

        [Test]
        public void RepairVehicles()
        {
            Garage garage = new Garage(2);
            Vehicle car1 = new("Honda", "Civic", "W123");
            Vehicle car2 = new("Honda", "S2000", "W234");
            car1.IsDamaged = true;
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);

            Assert.That(car1.IsDamaged, Is.True);
            Assert.That(garage.RepairVehicles(), Is.EqualTo("Vehicles repaired: 1"));
            Assert.That(car1.IsDamaged, Is.False);
        }
    }
}