using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingGarage.Core.Classes
{
    public enum ParkingLotType { Small = 1, Medium = 2, Large = 3 }

    [DataContract]
    public class Category
    {
        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int Width { get; set; }

        public ParkingLotType Type { get { return FindParkingLotType(); } }

        public Category()
        {

        }

        public Category(int length, int width)
        {
            Length = length;
            Width = width;
        }

        private ParkingLotType FindParkingLotType()
        {
            ParkingLotType type;
            if (Length < 15 && Width < 15) type = ParkingLotType.Small;
            if (Length < 25 && Width < 25) type = ParkingLotType.Medium;
            else type = ParkingLotType.Large;

            return type;
        }

        public static Category FindBestCategory(Car car, List<Category> categories)
        {
            return categories.OrderBy(x => x.Length).FirstOrDefault(x => car.Length < (x.Length - 10) && car.Width < (x.Width - 10));
        }
    }
}
