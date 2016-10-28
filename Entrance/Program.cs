using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Entrance
{
    public class Program
    {
        private static bool isRunning = true;

        private static WorkingService service;
        static void Main(string[] args)
        {
            while (isRunning)
            {
                string message = Console.ReadLine();

                switch(message)
                {
                    case "start":
                    case "Start":
                        //Start service
                        Console.WriteLine("Service started!");
                        service = new WorkingService("Com3");
                        Task.Run(() => { service.DoWork(); });
                        break;
                    case "stop":
                    case "Stop":
                        //Stop service
                        Console.WriteLine("Service stopped!");
                        service.Working = false;
                        break;
                    case "help":
                    case "Help":
                        Console.WriteLine("Possible commands are:");
                        Console.WriteLine("Start - Start the workingservice");
                        Console.WriteLine("Stop - Stop the workingservice");
                        break;
                    case "Exit":
                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
