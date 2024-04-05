using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }

                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }

                model = value;
            }
        }

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }

                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void Drive(double mileage)
        {
            double batteryUsed = Math.Round(mileage / MaxMileage * 100);

            if (GetType().Name == "CargoVan")
            {
                BatteryLevel -= (int)batteryUsed + 5;
            }
            else
            {
                BatteryLevel -= (int)batteryUsed;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            IsDamaged = !IsDamaged;
        }

        public override string ToString()
        {
            if (IsDamaged)
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: damaged";
            }
            else
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK";
            }
        }
    }
}
