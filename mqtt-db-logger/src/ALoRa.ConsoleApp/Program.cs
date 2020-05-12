using ALoRa.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nALoRa ConsoleApp - A The Things Network C# Library\n");

            var app = new TTNApplication("20180102", "ttn-account-v2.PAUZXYPrQB7VVhB3x_55OsfZrdAQX5S42nxExNSYk_E", "eu");
            app.MessageReceived += App_MessageReceived;

            Console.WriteLine("Press return to exit! HI HI HI HI");
            Console.ReadLine();

            app.Dispose();

            Console.WriteLine("\nAloha, Goodbye, Vaarwel!");

            System.Threading.Thread.Sleep(1000);
        }

        private static void App_MessageReceived(TTNMessage obj)
        {
            var data = obj.Payload != null ? BitConverter.ToString(obj.Payload) : string.Empty;
            Console.WriteLine($"Message Timestamp: {obj.Timestamp}, Device: {obj.DeviceID}, Topic: {obj.Topic}, Payload: {data}");
        }
    }
}
