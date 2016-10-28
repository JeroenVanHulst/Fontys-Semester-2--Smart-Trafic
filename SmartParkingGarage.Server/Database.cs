using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using SmartParkingGarage.Core.Classes;

namespace SmartParkingGarage.Server
{
    public class Database
    {
        private static string databaseName = "smartparkinggarage";

        private static string username = "root";

        private static string password = "usbw";

        private static MySqlConnection connection = null;

        public static void CreateConnection()
        {
            string connectionString = string.Format("Server=localhost;Port=3307;database={0};UID={1};password={2}", databaseName, username, password);
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public static Car ReadCar(string licensePlate)
        {
            Car car = null;
            string query = string.Format("SELECT * FROM car WHERE licenseplate ='{0}'", licensePlate);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    car = new Car(reader.GetInt32("Length"), reader.GetInt32("Width"), reader.GetString("licenseplate"));
                }
            }

            return car;
        }

        public static Category ReadCategory(int id)
        {
            Category category = null;
            string query = "SELECT * FROM category WHERE id=" + id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    category = new Category(reader.GetInt32("length"), reader.GetInt32("width"));
                }
            }

            return category;
        }

        public static ParkingSpot ReadParkingSpot(int id)
        {
            ParkingSpot parkingSpot = null;
            string query = "SELECT * FROM parkingspot WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    parkingSpot = new ParkingSpot(reader.GetInt32("length"), reader.GetInt32("width"), reader.GetString("name"));
                }
            }

            return parkingSpot;
        }

        public static List<ParkingSpot> ReadParkingSpots()
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
            List<int> categoryIds = new List<int>();
            string query = "SELECT * FROM parkingspot";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var parkingSpot = new ParkingSpot(reader.GetInt32("length"), reader.GetInt32("width"), reader.GetString("name"));
                    categoryIds.Add(reader.GetInt32("categoryid"));
                    parkingSpots.Add(parkingSpot);
                }
            }

            int i = 0;
            foreach (ParkingSpot parkingSpot in parkingSpots)
            {
                parkingSpot.Category = ReadCategory(categoryIds[i]);
                i++;
            }

            return parkingSpots;
        }

        public static List<Category> ReadCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM category";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    categories.Add(new Category(reader.GetInt32("length"), reader.GetInt32("width")));
                }
            }

            return categories;
        }

        public static void UpdateParkingSpotStatus(int id, bool value)
        {
            string query = string.Format("UPDATE parkingspot SET parkedcorrect={0} WHERE id={1}", value ? 1 : 0, id);

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateParkingSpotAvailable(int id)
        {
            string query = string.Format("UPDATE parkingspot SET licenseplate=''");

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateParkingSpotLicensePlate(ParkingSpot freeParkingSpot)
        {
            string query = string.Format("Update parkingspot SET licenseplate='{0}' WHERE name={1}", freeParkingSpot.Car.LicencePlate, freeParkingSpot.Name);

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
