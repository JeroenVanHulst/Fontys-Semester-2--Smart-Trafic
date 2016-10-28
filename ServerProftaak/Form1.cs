using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.ServerProftaak
{
    public partial class Form1 : Form
    {
        ServerToEntrance entre;
        public Form1()
        {
            InitializeComponent();
            entre = new ServerToEntrance();
        }

        private void btnAddDummyCars_Click(object sender, EventArgs e)
        {
            carList.Items.Clear();
            Car carOne = new Car(2, 1, "31-XD-BK");
            Car carTwo = new Car(3, 2, "28-OB-CZ");
            Car carThree = new Car(4, 3, "07-LA-AT");
            entre.Add(carOne);
            entre.Add(carTwo);
            entre.Add(carThree);

            foreach(Car car in entre.Cars)
            {
                carList.Items.Add(car);
            }
        }

        private void btnAddParkingspot_Click(object sender, EventArgs e)
        {
            Parkingspots.Items.Clear();
            Parkinglot parking = new Parkinglot("Spot one", 3, 2) { Type = parkingLotType.small };
            Parkinglot parkingTwo = new Parkinglot("Spot two", 4, 3) { Type = parkingLotType.medium };
            Parkinglot parkingThree = new Parkinglot("Spot three",5, 4) { Type = parkingLotType.large };
            entre.Add(parking);
            entre.Add(parkingTwo);
            entre.Add(parkingThree);

            foreach(Parkinglot park in entre.ParkedCars)
            {
                Parkingspots.Items.Add(park);
            }
        }

        private void buttonAddCarToParkingLot_Click(object sender, EventArgs e)
        {
            Parkingspots.Items.Clear();

            if (carList.SelectedItem != null)
            {
                Car car = carList.SelectedItem as Car;
                entre.AddCarToAParkingLot(car.LicencePlate);
            }

            foreach (Parkinglot park in entre.ParkedCars)
            {
                Parkingspots.Items.Add(park);
            }
        }

        private void btnShowFreeSpots_Click(object sender, EventArgs e)
        {
            lbFreeSpots.Items.Clear();
            List<Parkinglot> tempList = new List<Parkinglot>();
            tempList = entre.ReturnFreeSpots();

            foreach(Parkinglot lot in tempList)
            {
                lbFreeSpots.Items.Add(lot);
            }
        }

        
    }
}
