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
    interface IParkingLotService
    {
        [OperationContract]
        bool SetParkingSpotStatus(int id, int value);

        [OperationContract]
        void SetParkingSpotAvailable(int id, int value);
    }
}
