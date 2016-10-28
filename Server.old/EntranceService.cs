using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.Server
{
    public class EntranceService : IEntanceService
    {
        private List<Car> cars;

        private List<Category> categories;

        private List<ParkingSpot> parkingSpots;

        public EntranceService()
        {

        }

        public EntranceService(List<Car> cars, List<Category> categories, List<ParkingSpot> parkingSpots)
        {
            this.cars = cars;
            this.categories = categories;
            this.parkingSpots = parkingSpots;
        }

        public ParkingSpot GetParkingSpot(string licensePlate)
        {
            Car car = cars.FirstOrDefault(x => x.LicencePlate == licensePlate);
            Category category = Category.FindBestCategory(car, categories);

            List<ParkingSpot> freeParkingSpots = parkingSpots.Where(x => x.Category == category && !x.IsReserved).ToList();

            ParkingSpot freeParkingSpot = null;

            if (freeParkingSpots.Any())
            {
                freeParkingSpot = freeParkingSpots.FirstOrDefault();
                freeParkingSpot.Car = car;
            }

            return freeParkingSpot;
        }
    }
}
