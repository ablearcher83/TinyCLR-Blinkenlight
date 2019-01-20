using GHIElectronics.TinyCLR.Devices.Gpio;
using GHIElectronics.TinyCLR.Pins;
using System.Threading;

namespace Blinkenlights
{
    class Program
    {
        static void Main()
        {
            //Get default GPIO controller
            var gpioController = GpioController.GetDefault();
            //Pin numbers circuit from scheamtics, documents ...
            // For GHI Fez Cobra ||| 
            //var gpioPin = gpioController.OpenPin(FEZCobraIII.GpioPin.D33);
            /// For STM32F4 Discovery kit from ST STM32F407G-DISC1
            var gpioPin = gpioController.OpenPin(STM32F4.GpioPin.PD15);
            // For GHI BrainPad 2 
            //var gpioPin = gpioController.OpenPin(BrainPadBP2.GpioPin.PC6);
            //Pin is for sending out data
            gpioPin.SetDriveMode(GpioPinDriveMode.Output);
            for (var i = 0; i < 1000; i++)
            {
                //Set Pin state high meaning voltage will be supplied to component 
                //thats connected.
                //This means Led in our case
                gpioPin.Write(GpioPinValue.High);
                //Wait for 1 second (1000 miliseconds)
                Thread.Sleep(1000);
                //Set Pin state low meaning no voltage will be supplied to component
                //thats connected.
                gpioPin.Write(GpioPinValue.Low);
                Thread.Sleep(1000);
            }
        }
    }
}

