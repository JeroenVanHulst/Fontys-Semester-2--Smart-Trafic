using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.Server
{
    [ServiceContract(Namespace = "IParkingLotService")]
    public interface IParkingLotService
    {
        [OperationContract]
        void ReserveParkingSpot(ParkingSpot parkingSpot);
    }
}
