using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoBrick.EV3;

namespace Lego
{
    class Activate
    {
        private int counter;

        private sbyte speed = 30;
        private sbyte reverseSpeed = -30;

        private UInt32 degrees = 110;
        private UInt32 reverseDegrees = 110;

        /// <summary>
        /// Starts the movement of the lever.
        /// </summary>
        public void Run()
        {
            var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("com7"); //Bluetooth
            //var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("usb"); //USB
            //var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("wifi"); //WiFi

            try
            {
                ev3.Connection.Open();

                ev3.MotorA.ResetTacho();

                //while (true)
                //{
                //    Console.WriteLine("enter speed: ");
                //    string inputSpeed = Console.ReadLine();
                //    Console.WriteLine("enter degree: ");
                //    string inputDegree = Console.ReadLine();

                //    sbyte currSpeed;
                //    sbyte.TryParse(inputSpeed, out currSpeed);

                //    UInt32 degree;
                //    UInt32.TryParse(inputDegree, out degree);

                //    ev3.MotorA.On(currSpeed, degree, true);
                //}

                for (int i = 0; i < 5; i++)
                {
                    ev3.MotorA.On(speed, degrees, true);
                    System.Threading.Thread.Sleep(1000);
                    counter++;

                    ev3.MotorA.On(reverseSpeed, reverseDegrees, true);
                    System.Threading.Thread.Sleep(1000);
                    counter++;
                }

                System.Threading.Thread.Sleep(3000);
                ev3.MotorA.Off();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \n" + ex.Message);
            }
            finally
            {
                ev3.Connection.Close();
                Console.WriteLine("Success\nSteps: " + counter);
                Environment.Exit(0);
            }
        }
    }
}
