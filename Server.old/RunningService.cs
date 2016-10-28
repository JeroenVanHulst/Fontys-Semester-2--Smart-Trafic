using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.Server
{
    public class RunningService
    {
        public bool Running { get; set; }

        public List<Car> Cars { get; set; }

        public List<Category> Categories { get; set; }

        public List<ParkingSpot> ParkingSpots { get; set; }

        public static EntranceService entranceService { get; set; }

        private ParkingLotService parkingLotService;

        public RunningService()
        {
            Running = false;
            Cars = new List<Car>();
            Categories = new List<Category>();
            ParkingSpots = new List<ParkingSpot>();

            entranceService = new EntranceService(Cars, Categories, ParkingSpots);
            parkingLotService = new ParkingLotService();

            ParkingSpots = parkingLotService.GetParkingSpots();

            buildDummyData();
        }

        private void buildDummyData()
        {
            Cars.Add(new Car(250, 150, "0x04 0x25 0x54 0x72 0x95 0x2B 0x80"));

            Categories.Add(new Category(280, 180));
            Categories.Add(new Category(380, 230));
            Categories.Add(new Category(480, 280));
        }

        public void DoWork()
        {
            Running = true;
            while (Running)
            {
                
            }
        }
    }
}
