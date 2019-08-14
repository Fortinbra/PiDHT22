using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Native;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.RaspberryIO.Abstractions.Native;
using Unosquare.RaspberryIO.Peripherals;
using Unosquare.WiringPi;
using System.Threading.Tasks;

namespace PiDHT22
{
    class Program
    {
        static void Main(string[] args)
        {
            Pi.Init<BootstrapWiringPi>();
            var sensor = DhtSensor.Create(DhtType.Dht22, Pi.Gpio[BcmPin.Gpio04]);

            sensor.OnDataAvailable += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Temperature + "C " + eventArgs.HumidityPercentage + "%");
            };
            sensor.Start();
            while (sensor.IsRunning)
            {
                //Console.WriteLine(sensor.ToString());
            }
            Console.WriteLine(Pi.Info.ToString());
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render(Pi.Info.BoardModel.ToString()));

        }
    }
}
