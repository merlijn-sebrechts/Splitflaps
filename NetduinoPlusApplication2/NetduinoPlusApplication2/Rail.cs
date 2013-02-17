using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using NetduinoPlusApplication2;

namespace NetduinoPlusApplication2
{
    class Rail
    {
        Microsoft.SPOT.Hardware.SPI spi;

        Driver driver;
        //Driver driver2;
        Driver driver3;
        //Driver driver4;

        public Rail()
        {
            spi = new SPI(new SPI.Configuration(Pins.GPIO_PIN_D10, false, 200, 400, false, true, 100, SPI_Devices.SPI1));
            // write HAEN
            spi.Write(new byte[] { 0x40, 0x0A, 0x28 });


            driver = new Driver(spi, 0x42);
            driver3 = new Driver(spi, 0x4A);
            //driver = new Driver(spi, 0x42);
            //driver = new Driver(spi, 0x42);
        }

        public void Test()
        {
            while (true)
            {
                driver.Test();
                driver3.Test();
            }
        }
    }
}
