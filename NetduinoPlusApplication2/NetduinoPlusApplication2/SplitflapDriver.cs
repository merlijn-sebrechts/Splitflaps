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
    class SplitflapDriver
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

        public void Test()
        {
            //http://support2.microchip.com/KBSearch/KB_StdProb.aspx?ID=SQ6UJ9A00A2VV
            //http://wiki.netduino.com/SPI.ashx
            //http://wiki.netduino.com/SPI-Configuration.ashx
            //
            //---MCP---
            //CS   11
            //SCK  12
            //SI   13
            //SO   14
            //
            //---netduino---
            //SCK  D13
            //MISO D12
            //MOSI D11
            //SL   D10
            //
            //---flat cable---
            //GND   1
            //Vdd   2
            //SO    3
            //SI    4
            //SCK   5
            //CS    6
            //
            //---MCP -> output ---
            //B0     8
            //B1     7
            //B2     6
            //B3     5
            //B4     4
            //B5     3
            //B6     2
            //B7     1    
            //A0     9   
            //A1    10
            //A2    11
            //A3    12
            //A4    13
            //A5    14
            //A6    15
            //A7    16

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            SPI.Configuration spiConfig = new SPI.Configuration(Pins.GPIO_PIN_D10, false, 200, 400, false, true, 100, SPI_Devices.SPI1);
            Microsoft.SPOT.Hardware.SPI spi = new SPI(spiConfig);

            // write HAEN
            spi.Write(new byte[] { 0x40, 0x0A, 0x28 });


            // Set banks to output
            spi.Write(new byte[] { 0x42, 0x00, 0x00 });   // Set bank A to output
            spi.Write(new byte[] { 0x42, 0x01, 0x00 });   // Set bank B to output

            while (true)
            {
                spi.Write(new byte[] { 0x42, 0x12, 0x55 });   // Set bank A outputs to high
                spi.Write(new byte[] { 0x42, 0x13, 0xAA });   // Set bank B outputs to high


                led.Write(true); // turn on the LED 
                Thread.Sleep(500); // sleep for 250ms 

                spi.Write(new byte[] { 0x42, 0x12, 0xAA });   // Set bank A outputs to high
                spi.Write(new byte[] { 0x42, 0x13, 0x55 });   // Set bank B outputs to high

                led.Write(false); // turn off the LED 
                Thread.Sleep(500); // sleep for 250ms 
            }
        }
    }
}
