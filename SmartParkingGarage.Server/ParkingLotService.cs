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
    public class ParkingLotService : IParkingLotService
    {
        public ParkingLotService()
        {
            Database.CreateConnection();
        }

        public bool SetParkingSpotStatus(int id, int value)
        {
            if (id == 1 && value == 1)
            {
                Database.UpdateParkingSpotStatus(id, true);
                return true;
            }
            else
            {
                return false;
            }
            //Database.UpdateParkingSpotStatus(id, value == 1 ? true : false);
        }

        public void SetParkingSpotAvailable(int id, int value)
        {
            if (value == 0) Database.UpdateParkingSpotAvailable(id);
        }
    }
}
