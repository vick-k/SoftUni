using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle = null;

            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            foreach (IRoute route in routes.GetAll())
            {
                if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length == length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }

                if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }

                if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length > length)
                {
                    route.LockRoute();
                }
            }

            IRoute newRoute = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(newRoute);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser currentUser = users.FindById(drivingLicenseNumber);
            IVehicle currentVehicle = vehicles.FindById(licensePlateNumber);
            IRoute currentRoute = routes.FindById(routeId);

            if (currentUser.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            if (currentVehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            if (currentRoute.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            currentVehicle.Drive(currentRoute.Length);

            if (isAccidentHappened)
            {
                currentVehicle.ChangeStatus();
                currentUser.DecreaseRating();
            }
            else
            {
                currentUser.IncreaseRating();
            }

            return currentVehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            var damagedVehicles = vehicles
                .GetAll()
                .Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .ToList();

            int countOfRepairedVehicles = 0;

            if (count < damagedVehicles.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    damagedVehicles[i].ChangeStatus();
                    damagedVehicles[i].Recharge();
                    countOfRepairedVehicles++;
                }
            }
            else
            {
                foreach (var vehicle in damagedVehicles)
                {
                    vehicle.ChangeStatus();
                    vehicle.Recharge();
                    countOfRepairedVehicles++;
                }
            }

            return string.Format(OutputMessages.RepairedVehicles, countOfRepairedVehicles);
        }

        public string UsersReport()
        {
            StringBuilder sb = new();
            sb.AppendLine("*** E-Drive-Rent ***");

            var arrangedUsers = users
                .GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            foreach (var user in arrangedUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
