using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.Entrance
{
    class Program
    {
        private static bool isRunning = true;

        private static WorkingService service;

        static void Main(string[] args)
        {
            while (isRunning)
            {
                string message = Console.ReadLine().ToLower();

                switch(message)
                {
                    case "start":
                        //Start service
                        //TODO: Read config file
                        WorkingService.EntranceServiceClient = new EntranceServiceClient();
                        var ports = new List<string>() { "Com8" };
                        service = new WorkingService(ports);
                        service.Running = true;
                        Task.Run(() => { service.DoWork(); });
                        //ParkingSpot parkingspot = WorkingService.EntranceServiceClient.GetParkingSpot("test");
                        Console.WriteLine("Service started!");
                        break;
                    case "stop":
                        //Stop service
                        Console.WriteLine("Service stopped!");
                        //service.Working = false;
                        break;
                    case "help":
                        Console.WriteLine("Possible commands are:");
                        Console.WriteLine("Start - Start the workingservice");
                        Console.WriteLine("Stop - Stop the workingservice");
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
