using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace NetduinoPlusApplication1
{
    public class Program
    {
        public enum Registers
        {
            IODIRA,
            IODIRB,
            IPOLA,
            IPOLB,
            GPINTENA,
            GPINTENB,
            DEFVALA,
            DEFVALB,
            INTCONA,
            INTCONB,
            IOCONA,
            IOCONB,
            GPPUA,
            GPPUB,
            INTFA,
            INTFB,
            INTCAPA,
            INTCAPB,
            GPIOA,
            GPIOB,
            OLATA,
            OLATB
        };

        public static void Main()
        {
            //http://support2.microchip.com/KBSearch/KB_StdProb.aspx?ID=SQ6UJ9A00A2VV
            //http://wiki.netduino.com/SPI.ashx
            //http://wiki.netduino.com/SPI-Configuration.ashx   

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            SPI.Configuration spiConfig = new SPI.Configuration(Pins.GPIO_PIN_D10, false, 200, 400, false, true, 100, SPI_Devices.SPI1);
            Microsoft.SPOT.Hardware.SPI spi = new SPI(spiConfig);

            //uw moeder is fantastisch

            spi.Write(new byte[] { 0x40, 0x00, 0x00 });   // Set bank A to output
            spi.Write(new byte[] { 0x40, 0x01, 0x00 });   // Set bank B to output

            while (true)
            {
                spi.Write(new byte[] { 0x40, 0x12, 0xff });   // Set bank A outputs to high
                spi.Write(new byte[] { 0x40, 0x13, 0xff });   // Set bank B outputs to high


                led.Write(true); // turn on the LED 
                Thread.Sleep(1500); // sleep for 250ms 
                led.Write(false); // turn off the LED 
                Thread.Sleep(1500); // sleep for 250ms 
            }
        }
    }
}
