/// Author: Viktor Rusnak
/// Date created: 2016-04-05

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoBrick.EV3;

namespace LegoMindstormForms
{
    /// <summary>
    /// Initialization of the Lego Mindstorm EV3.
    /// </summary>
    public partial class MainForm : Form
    {
        private int counter;

        /// <summary>
        /// Initiates the program.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitGUI();
            Run();
        }

        /// <summary>
        /// Initiates the GUI.
        /// </summary>
        private void InitGUI()
        {
            this.Text = "Step Counter";
            this.Show();
        }

        /// <summary>
        /// Starts the movement of the lever.
        /// </summary>
        private void Run()
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
                lblStepCounter.Text = "Error: \n" + ex.Message;
            }
            finally
            {
                ev3.Connection.Close();
                lblStepCounter.Text = "Success\nSteps: " + counter;
                Environment.Exit(0);
            }
        }
    }
}
