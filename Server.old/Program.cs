using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Server
{
    class Program
    {
        private static bool running;

        private static RunningService runningService;

        private static ServiceHost entranceHost;

        private static ServiceHost parkingHost;

        static void Main(string[] args)
        {
            running = true;
            while (running)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Start":
                    case "start":
                        runningService = new RunningService();
                        Console.WriteLine("Service started");
                        var task = new Task(() => { runningService.DoWork(); });
                        task.RunSynchronously();
                        break;
                    case "Stop":
                    case "stop":
                        runningService.Running = false;
                        entranceHost.Close();
                        parkingHost.Close();
                        break;
                    case "Exit":
                    case "exit":
                        running = false;
                        break;
                    case "Help":
                    case "help":
                        Console.WriteLine("Available commands are:");
                        Console.WriteLine("Start - Starting the server");
                        Console.WriteLine("Stop - Stopping the server");
                        Console.WriteLine("Exit - Exit the program");
                        break;
                }
            }
        }
    }
}