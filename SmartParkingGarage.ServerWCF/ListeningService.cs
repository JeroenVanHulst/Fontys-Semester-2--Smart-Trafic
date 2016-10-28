using SmartParkingGarage.Core.Classes;
using SmartParkingGarage.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartParkingGarage.ServerWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ListeningService : IListeningService
    {
        public ParkingSpot GetParkingSpot(string licensePlate)
        {
            return RunningService.entranceService.GetParkingSpot(licensePlate);
        }
    }
}
