using ALoRa.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Dynamic;

namespace ALoRa.ConsoleApp
{
    class Program
    {
        private static string appID = "20180102";
        private static string accessKey = "ttn-account-v2.PAUZXYPrQB7VVhB3x_55OsfZrdAQX5S42nxExNSYk_E";
        private static string region = "eu";
        static void Main(string[] args)
        {
            Console.WriteLine("\nALoRa ConsoleApp - A The Things Network C# Library\n");

            var app = new TTNApplication(appID, accessKey, region);
            app.MessageReceived += App_MessageReceived;
            System.Threading.Thread.Sleep(1000);
        }

        private static void App_MessageReceived(TTNMessage obj)
        {
            PrepareForDb(obj);
            Console.WriteLine("Data has been added to the DB");
        }

        private static void PrepareForDb(TTNMessage obj)
        {
            //Table Apps
            string appId =  appID;
            //Table Devices
            string deviceID = obj.DeviceID;
            DateTime lastSeen = DateTime.Now;
            //Table Data
            DateTime? timestamp = obj.Timestamp;
            var ascii = obj.Payload != null ? BitConverter.ToString(obj.Payload) : string.Empty;
            string payload = AsciiToString(ascii);
            string[] data = GetData(payload);
            Console.WriteLine("AppId: "+appId+ " deviceID: "+deviceID+" last seen: "+lastSeen+" timestamp: "+timestamp+" payload: "+payload+" A: "+data[0]+" B: "+data[1]);
        }

        private static string[] GetData(string payload)
        { 
            String[] separator = { ":",",","{","}","A", "B","\"" };
            int count = 20;

            String[] strlist = payload.Split(separator, count,StringSplitOptions.RemoveEmptyEntries);

            return new string[2] { strlist[0], strlist[1] };
        }

        private static string AsciiToString(string ascii)
        {
            ascii = ascii.Replace("-", "");
            byte[] raw = new byte[ascii.Length / 2];
            string payload = "";
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(ascii.Substring(i * 2, 2), 16);
                payload += Convert.ToChar(raw[i]).ToString();
            }

            return payload;
        }
    }
}
