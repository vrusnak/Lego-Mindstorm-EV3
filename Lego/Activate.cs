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

                ////Reset the EV3
                //ev3.MotorA.MoveTo(20, 50, false);

                for (int i = 0; i < 10; i++)
                {
                    ev3.MotorA.On(30, 70, true);
                    System.Threading.Thread.Sleep(1000);
                    ev3.MotorA.On(-30, 70, true);
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
