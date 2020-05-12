using ALoRa.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace ALoRa.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\nALoRa ConsoleApp - A The Things Network C# Library\n");

            var app = new TTNApplication("20180102", "ttn-account-v2.PAUZXYPrQB7VVhB3x_55OsfZrdAQX5S42nxExNSYk_E", "eu");
            app.MessageReceived += App_MessageReceived;


            System.Threading.Thread.Sleep(1000);
        }

        private static void App_MessageReceived(TTNMessage obj)
        {
            AddToDb(obj);
            var data = obj.Payload != null ? BitConverter.ToString(obj.Payload) : string.Empty;
            Console.WriteLine($"Message Timestamp: {obj.Timestamp}, Device: {obj.DeviceID}, Topic: {obj.Topic}, Payload: {data}");
        }

        private static void AddToDb(TTNMessage obj)
        {
            var data = obj.Payload != null ? BitConverter.ToString(obj.Payload) : string.Empty;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=lora;";
            string query = "INSERT INTO data(`id`, `timestamp`, `device_id`, `topic`, `payload`) VALUES (NULL, '" + obj.Timestamp + "', '" + obj.DeviceID + "', '" + obj.Topic + "', '" + data + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                Console.WriteLine("data succesfully added to DB");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
