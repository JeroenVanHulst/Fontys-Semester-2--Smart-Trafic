using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Entrance
{
    public class WorkingService
    {
        public bool Running { get; set; }

        private List<Arduino> arduinos;

        public static EntranceServiceClient EntranceServiceClient { get; set; }
        public WorkingService(List<string> comPorts)
        {
            arduinos = new List<Arduino>();
            comPorts.ForEach(x => arduinos.Add(new Arduino(x)));
            arduinos.ForEach(x => x.OpenConnection());
        }

        public void DoWork()
        {
            while (Running)
            {
                arduinos.Where(x => !x.isPortOpen).Select(x => x.OpenConnection());
            }
        }
    }
}
