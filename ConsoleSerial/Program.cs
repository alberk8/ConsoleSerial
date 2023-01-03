
using Microsoft.VisualBasic.FileIO;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.IO.Ports;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Serial World!");

            SerialPort serial = new SerialPort();

            serial.PortName = "COM5";
            serial.BaudRate = 115200;
            serial.StopBits = StopBits.One;
            serial.DataBits = 8;
            serial.Parity = Parity.None;

            //serial.DtrEnable = true;
            //serial.RtsEnable = true;

            serial.Handshake = Handshake.None;
            serial.ReadBufferSize = 2_000;
            serial.DataReceived += Serial_DataReceived;
          
            serial.Open();

            //serial.RtsEnable = false;

            Console.WriteLine("Open");
            Console.ReadLine();

        }

        private static void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
            
            var x = (SerialPort)sender;

            var read = x.ReadExisting();

            Console.WriteLine(read);
         
        }
    }

}