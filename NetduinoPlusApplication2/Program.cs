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
        public static void Main()
        {
            // write your code here 
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);


            // Defines the first SPI slave device with pin 10 as SS
            SPI.Configuration Device1 = new SPI.Configuration(
                Pins.GPIO_PIN_D10, // SS-pin
                false,             // SS-pin active state
                0,                 // The setup time for the SS port
                 0,                 // The hold time for the SS port
                true,              // The idle state of the clock
                false,             // The sampling clock edge
                1000,              // The SPI clock rate in KHz
                 SPI_Devices.SPI1   // The used SPI bus (refers to a MOSI MISO and SCLK pinset)
            );


            // Initializes the SPI bus, with the first slave selected
            SPI SPIBus = new SPI(Device1);

            /*
            Here you can talk with Slave 1
             * http://support2.microchip.com/KBSearch/KB_StdProb.aspx?ID=SQ6UJ9A00A2VV
            */
            byte[] WriteBuffer = new byte[1];




            // default adress
            WriteBuffer[0] = 0x40;
            SPIBus.Write(WriteBuffer);
            // register IOCON
            WriteBuffer[0] = 0x0A;
            SPIBus.Write(WriteBuffer);
            // register set HAEN=1
            WriteBuffer[0] = 0x28;
            SPIBus.Write(WriteBuffer);

            // chip adress
            WriteBuffer[0] = 0x42;
            SPIBus.Write(WriteBuffer);
            // register IODIRA
            WriteBuffer[0] = 0x00;
            SPIBus.Write(WriteBuffer);
            // set port A as outputs
            WriteBuffer[0] = 0x00;
            SPIBus.Write(WriteBuffer);

            // chip adress
            WriteBuffer[0] = 0x42;
            SPIBus.Write(WriteBuffer);
            // register GPIOA
            WriteBuffer[0] = 0x12;
            SPIBus.Write(WriteBuffer);
            // set port A as outputs
            WriteBuffer[0] = 0xA6;
            SPIBus.Write(WriteBuffer);








            //// default adress
            //WriteBuffer[0] = 0x40;
            //SPIBus.Write(WriteBuffer);
            //// register IOCON
            //WriteBuffer[0] = 0x0A;
            //SPIBus.Write(WriteBuffer);
            //// register set HAEN=1
            //WriteBuffer[0] = 0x28;
            //SPIBus.Write(WriteBuffer);

            //// chip adress
            //WriteBuffer[0] = 0x42;
            //SPIBus.Write(WriteBuffer);
            //// register IODIRA
            //WriteBuffer[0] = 0x00;
            //SPIBus.Write(WriteBuffer);
            //// set port A as outputs
            //WriteBuffer[0] = 0x00;
            //SPIBus.Write(WriteBuffer);

            //// chip adress
            //WriteBuffer[0] = 0x42;
            //SPIBus.Write(WriteBuffer);
            //// register GPIOA
            //WriteBuffer[0] = 0x12;
            //SPIBus.Write(WriteBuffer);
            //// set port A as outputs
            //WriteBuffer[0] = 0xA6;
            //SPIBus.Write(WriteBuffer);

            while (true)
            {

                led.Write(true); // turn on the LED 
                Thread.Sleep(500); // sleep for 250ms 
                led.Write(false); // turn off the LED 
                Thread.Sleep(500); // sleep for 250ms 
            }
            // Start the main loop









        }
    }
}