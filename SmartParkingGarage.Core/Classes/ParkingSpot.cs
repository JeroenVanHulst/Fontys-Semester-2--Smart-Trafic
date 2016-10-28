using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Core.Classes
{
    [DataContract]
    public class ParkingSpot
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public Car Car { get; set; }

        [DataMember]
        public bool ParkedCorrect { get; set; }

        public bool IsReserved { get { return Car != null; } }

        public ParkingSpot()
        {

        }

        public ParkingSpot(int length, int width, string name)
        {
            Length = length;
            Width = width;
            Name = name;
            Category = new Category(length, width);
        }
    }
}
