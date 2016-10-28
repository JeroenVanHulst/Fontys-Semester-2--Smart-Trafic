using SmartParkingGarage.Core.Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Timers;

namespace SmartParkingGarage.Entrance
{
    public class Arduino
    {
        public string ComPort { get; set; }

        public bool isPortOpen { get { return serialPort.IsOpen; } }

        private SerialPort serialPort;

        private Timer timeoutTimer;

        private string message;

        public Arduino(string comPort)
        {
            ComPort = comPort;
            timeoutTimer = new Timer(10000);
            timeoutTimer.Elapsed += requestTimeout;
        }

        public bool OpenConnection()
        {
            if (serialPort != null && serialPort.IsOpen) return true;

            serialPort = new SerialPort(ComPort);
            serialPort.Open();

            if (!serialPort.IsOpen) return false;

            serialPort.BaudRate = 9600;
            serialPort.DataReceived += dataReceivedHandler;
            SendMessage("create", "Connection", true);

            return true;
        }

        public bool CloseConnection()
        {
            if (!serialPort.IsOpen) return true;

            serialPort.Close();

            return serialPort.IsOpen;
        }

        private void SendMessage(string message, string type, bool askFeedback)
        {
            string sendMessage = string.Format("%{0}:{1}#", type, message);
            serialPort.Write(sendMessage);
            if (askFeedback) timeoutTimer.Start();
        }

        private void dataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedMessage = serialPort.ReadExisting();

            if (string.IsNullOrWhiteSpace(message) && !receivedMessage.Contains("%")) return;

            if (string.IsNullOrWhiteSpace(message))
            {
                int index = receivedMessage.LastIndexOf("%");
                message = receivedMessage.Substring(index);
            }
            else
            {
                message += receivedMessage;
            }

            if (message.Contains("#")) HandleMessage();
        }

        private void HandleMessage()
        {
            int index = message.IndexOf("#") + 1;
            string handleMessage = message.Substring(0, index);

            if (handleMessage == "%Connection:ACK#")
            {
                timeoutTimer.Stop();
                SendMessage("Ack", "Connection", false);
            }
            else if (handleMessage.StartsWith("%LicensePlate:"))
            {
                int startIndex = handleMessage.IndexOf(":") + 1;
                string licensePlate = handleMessage.Substring(startIndex);

                licensePlate = licensePlate.Remove(licensePlate.IndexOf("#"));

                string newLicensePlate = createLicensePlate(licensePlate);
                Console.WriteLine(newLicensePlate);
                if (newLicensePlate.Length == 17)
                {
                    ParkingSpot parkingSpot = WorkingService.EntranceServiceClient.GetParkingSpot(newLicensePlate);
                    timeoutTimer.Start();
                    if (parkingSpot != null)
                    {
                        Console.WriteLine(string.Format("ParkingSpot found: {0} With length: {1} and width: {2}", parkingSpot.Name, parkingSpot.Length, parkingSpot.Width));
                        SendMessage(parkingSpot.Name, "ParkingSpot", true);
                    }
                    else
                    {
                        Console.WriteLine("No parkingspots available at the moment");
                        SendMessage("NONE", "ParkingSpot", true);
                    }
                }
            }
            else if (handleMessage.StartsWith("%Logging"))
            {
                Console.WriteLine(handleMessage);
            }
            else if (handleMessage.StartsWith("%ParkingSpot:ACK#")) timeoutTimer.Stop();
            else if (handleMessage == "%ACK#") timeoutTimer.Stop();

            message = message.Remove(0, handleMessage.Length);
        }

        private string createLicensePlate(string licensePlate)
        {
            licensePlate = licensePlate.Replace("0x", "");
            string license = "";
            licensePlate.Where(x => !char.IsWhiteSpace(x)).ToList().ForEach(x => license += x);
            string newLicense = "";
            int count = 0;

            foreach(var c in license)
            {
                count++;

                newLicense += c;

                if (count % 4 == 0 && count != 16)
                {
                    newLicense += "-";
                }
            }

            return newLicense;
        }

        private void requestTimeout(object sender, ElapsedEventArgs e)
        {
            timeoutTimer.Stop();
            CloseConnection();
            Console.WriteLine(string.Format("Arduino with comport: {0} is stopped due an error.", ComPort));
        }
    }
}
