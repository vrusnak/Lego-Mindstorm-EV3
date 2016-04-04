using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoBrick.EV3;
using LibUsbDotNet;

namespace MyLegoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("usb"); //USB
            var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("com4"); //Bluetooth
            //var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("wifi"); //WiFi

            try
            {
                ev3.Connection.Open();

                ev3.MotorA.ResetTacho();

                //ev3.MotorA.On(10, 10, true);
                //System.Threading.Thread.Sleep(1000);
                //ev3.MotorA.Off();

                for (int i = 0; i < 10; i++)
                {
                    ev3.MotorA.On(30, 70, true);
                    System.Threading.Thread.Sleep(1000);
                    ev3.MotorA.On(-30, 70, true);
                    System.Threading.Thread.Sleep(1000);
                }
                System.Threading.Thread.Sleep(3000);
                ev3.MotorA.Off();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Press any key to end...");
                Console.ReadKey();
            }
            finally
            {
                ev3.Connection.Close();
            }
        }
    }
}
