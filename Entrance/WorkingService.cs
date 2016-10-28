using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SmartParkingGarage.Entrance
{
    public class WorkingService
    {
        private SerialPort serialPort;

        private string comPort;

        private bool connectedWithArduino;

        private bool connectedWithServer;

        public bool Working { get; set; }

        private bool connectionRequested;

        private Timer timeoutTimer;

        private string message;
        public WorkingService(string comPort)
        {
            this.comPort = comPort;
            connectedWithArduino = false;
            connectionRequested = false;
            Working = true;
            timeoutTimer = new Timer(10000);
            timeoutTimer.Elapsed += requestTimeout;
        }

        ~WorkingService()
        {
            if (serialPort.IsOpen) serialPort.Close();
        }

        public void DoWork()
        {
            while (Working)
            {
                if (!connectedWithArduino)
                {
                    ConnectWithArduino();
                    connectedWithArduino = true;
                    continue;
                }
                //if (!connectedWithServer) continue;


            }

            if (serialPort.IsOpen) serialPort.Close();
        }

        private void ConnectWithArduino()
        {
            if (serialPort == null) serialPort = new SerialPort(comPort);
            if (!serialPort.IsOpen) serialPort.Open();
            serialPort.BaudRate = 115200;
            serialPort.DataReceived += dataReceivedHandler;
            SendMessage("create", "Connection");
        }

        private void SendMessage(string message, string type)
        {
            string sendMessage = string.Format("%{0}:{1}#", type, message);
            serialPort.Write(sendMessage);
            
        }

        private void dataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedMessage = serialPort.ReadExisting();

            if (message == "" && !receivedMessage.Contains("%")) return;

            if (message == "")
            {
                int index = receivedMessage.IndexOf("%");

                message = receivedMessage.Substring(index);
            }
            else
            {
                message += receivedMessage;
            }

            if (message.Contains("#"))
            {
                int index = message.IndexOf("#") + 1;
                string handleMessage = message.Substring(0, index);

                if (handleMessage == "%Connection:ACK#")
                {
                    SendMessage("ACK", "Connection");
                    connectedWithArduino = true;
                }
                else if (handleMessage.StartsWith("%LicensePlate:"))
                {
                    int startIndex = handleMessage.IndexOf(":") + 1;
                    string licensePlate = handleMessage.Substring(startIndex);
                    licensePlate = licensePlate.Remove(licensePlate.IndexOf("#"));
                    Console.WriteLine(licensePlate);
                    // TODO: ask for parkingspot
                    int number = 3;
                    if (licensePlate == "0x04 0x4C 0x58 0x7A 0x95 0x2B 0x80") number = 1;
                    else if (licensePlate == "0x04 0x9B 0x5C 0x7A 0x95 0x2B 0x80") number = 2;
                    SendMessage("["+ number +"]", "ParkingSpot");
                }
                else if (handleMessage.StartsWith("%Logging")) Console.WriteLine(handleMessage);

                message.Remove(0, handleMessage.Length);
            }
            message = message.Substring(message.IndexOf("#") + 1);
        }

        private void requestTimeout(object sender, ElapsedEventArgs e)
        {
            connectedWithArduino = false;
        }

        
    }
}
