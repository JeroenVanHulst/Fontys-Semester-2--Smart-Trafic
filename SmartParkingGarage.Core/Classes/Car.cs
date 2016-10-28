using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Core.Classes
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public string LicencePlate { get; set; }

        public Car()
        {

        }

        public Car(int length, int width, string licencePlate)
        {
            Length = length;
            Width = width;
            LicencePlate = licencePlate;
        }

        public override string ToString()
        {
            return string.Format("Car, Length: {0}, Width: {1}, License plate: {2}", Length, Width, LicencePlate);
        }
    }
}
