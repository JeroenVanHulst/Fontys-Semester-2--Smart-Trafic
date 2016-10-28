using SmartParkingGarage.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Server
{
    [ServiceContract]
    interface IEntranceService
    {
        [OperationContract]
        ParkingSpot GetParkingSpot(string licensePlate);
    }
}
