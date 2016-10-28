using SmartParkingGarage.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class EntranceService : IEntranceService
    {
        //private List<Car> cars;

        //private List<Category> categories;

        //private List<ParkingSpot> parkingSpots;

        public EntranceService()
        {
            /*cars = new List<Car>();
            categories = new List<Category>();
            parkingSpots = new List<ParkingSpot>();
            createDummyData();*/
            Database.CreateConnection();
        }

        public ParkingSpot GetParkingSpot(string licensePlate)
        {
            Car car = Database.ReadCar(licensePlate);//cars.FirstOrDefault(x => x.LicencePlate == licensePlate);
            Category category = Category.FindBestCategory(car, Database.ReadCategories());//categories);

            List<ParkingSpot> freeParkingSpots = Database.ReadParkingSpots()
                                                    .Where(x => x.Category.Type >= category.Type && !x.IsReserved)
                                                    .ToList();

            freeParkingSpots.OrderBy(x => x.Category.Type);

            ParkingSpot freeParkingSpot = null;

            if (freeParkingSpots.Any())
            {
                freeParkingSpot = freeParkingSpots.FirstOrDefault();
                freeParkingSpot.Car = car;
            }

            //Database.UpdateParkingSpotLicensePlate(freeParkingSpot);

            return freeParkingSpot;
        }

        /*private void createDummyData()
        {
            cars.Add(new Car(10, 10, "test"));
            cars.Add(new Car(20, 20, "test2"));
            categories.Add(new Category(15, 15));
            categories.Add(new Category(25, 25));
            parkingSpots.Add(new ParkingSpot(15, 15, "test") { Category = categories[0] });
            parkingSpots.Add(new ParkingSpot(25, 25, "test2") { Category = categories[1] });
        }*/
    }
}
