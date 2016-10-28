using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingGarage.Core.Classes;
using System.Collections;

namespace SmartParkingGarage.ServerProftaak
{
    public class ServerToEntrance
    {
        public List<Car> Cars { get; set; }
        public List<Parkinglot> ParkedCars { get; set; }
        public List<Parkinglot> EmptySpots { get; set; }
        public ServerToEntrance()
        {
            Cars = new List<Car>();
            ParkedCars = new List<Parkinglot>();
            EmptySpots = new List<Parkinglot>();
        }

        public string CheckIfCarIsInList(Car car)
        {
            return Cars.Where(x => x.LicencePlate == car.LicencePlate).FirstOrDefault().LicencePlate;
        }

        public bool Add(Car car)
        {
            if(car == null)
            {
                return false;
            }
            else
            {
                Cars.Add(car);
                return true;
            }
        }

        public bool Add(Parkinglot park)
        {
            if(park == null)
            {
                return false;
            }
            else
            {
                ParkedCars.Add(park);
                return true;
            }
        }

        public bool AddCarToAParkingLot(string licensePlate)
        {
            Car car = Cars.FirstOrDefault(x => x.LicencePlate == licensePlate);

            Parkinglot parkinglot = null;

            foreach (Parkinglot lot in ParkedCars.Where(x => x.Type == parkingLotType.small && !x.Reserved))
            {
                if (car.Length < lot.Length && car.Width < lot.Width) parkinglot = lot;
            }

            if (parkinglot == null)
            {
                foreach (Parkinglot lot in ParkedCars.Where(x => x.Type == parkingLotType.medium && !x.Reserved))
                {
                    if (car.Length < lot.Length && car.Width < lot.Width) parkinglot = lot;
                }
            }
            if (parkinglot == null)
            {
                parkinglot = ParkedCars.FirstOrDefault(x => x.Type == parkingLotType.large && !x.Reserved);
            }

            parkinglot.Car = car;
            return true;
        }

        public List<ParkingSpot> ReturnFreeSpots()
        {
            return ParkedCars.ToList().Where(x => !x.Reserved).ToList();
        }
    }
}
