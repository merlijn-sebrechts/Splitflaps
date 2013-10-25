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
    class DriverChip
    {
        Microsoft.SPOT.Hardware.SPI spi;
        byte address;

        byte currentA;
        byte currentB;

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

        public DriverChip(Microsoft.SPOT.Hardware.SPI spi, byte address)
        {
            this.spi = spi;
            this.address = address;



            init();
        }

        public void init()
        {
            // Set banks to output
            spi.Write(new byte[] { address, 0x00, 0x00 });   // Set bank A to output
            spi.Write(new byte[] { address, 0x01, 0x00 });   // Set bank B to output

            this.currentA = 0x55;
            this.currentB = 0xAA;
            spi.Write(new byte[] { address, 0x12, 0x55 });   // Set bank A outputs to start position
            spi.Write(new byte[] { address, 0x13, 0xAA });   // Set bank B outputs to start position
        }

        public void flap(byte flapNr)
        {
            byte chifter = 0x3;
            byte currentByte;

            if (flapNr < 4)
            {
                currentByte = currentA;

                // toggle bit
                byte nextByte = (byte)(currentByte ^ (byte)(chifter << (flapNr * 2)));

                // write new byte
                spi.Write(new byte[] { address, 0x12, nextByte });
                this.currentA = nextByte;
            }
            else
            {
                flapNr = (byte)(flapNr - 4);
                currentByte = currentB;

                // toggle bit
                byte nextByte = (byte)(currentByte ^ (byte)(chifter << (flapNr * 2)));

                // write new byte
                spi.Write(new byte[] { address, 0x13, nextByte });
                this.currentB = nextByte;
            }
            Thread.Sleep(5);
        }

        public void Test(int charLength)
        {
            for (int l = 0; l < charLength; l++)
            {
                //spi.Write(new byte[] { address, 0x12, 0x55 });   
                //spi.Write(new byte[] { address, 0x13, 0xAA });   // Set bank B outputs to high


                // Set bank A outputs to high
                for (byte i = 0; i < 4; i++)
                {
                    flap(i);
                }

                // Set bank B outputs to high
                for (byte i = 4; i < 8; i++)
                {
                    flap(i);
                }
                //wait to flap
                Thread.Sleep(200);


                ////spi.Write(new byte[] { address, 0x12, 0xAA });   // Set bank A outputs to high
                ////spi.Write(new byte[] { address, 0x13, 0x55 });   // Set bank B outputs to high
                //for (byte i = 0; i < 5; i++)
                //{
                //    flap(i);
                //}

                //for (byte i = 4; i < 8; i++)
                //{
                //    flap(i);
                //}



            }
        }
    }
}
