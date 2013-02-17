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

    class Driver
    {
        public static readonly char[] Characters = new char[] { 
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            '>',
            '-',
            '/',
            ':',
            ' ',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '.',
        };

        private byte[] currentPositionList;


        DriverChip driverChip;

        public Driver(Microsoft.SPOT.Hardware.SPI spi, byte address)
        {
            currentPositionList = new byte[8];

            for (int i = 0; i < currentPositionList.Length; i++ )
            {
                currentPositionList[i] = 0;
            }

            this.driverChip = new DriverChip(spi, address);
        }

        public void Show(string text)
        {
            // Make text to be exactly number of flaps. If shorter, add spaces as padding.
            if (text.Length > 8)
            {
                text = text.Substring(0, 8);
            }
            else if (text.Length < 8)
            {
                int paddLength = 8 - text.Length;

                for (int i = 0; i < paddLength; i++)
                {
                    text += " ";
                }
            }



            // while not all chars are shown
            bool allShown = false;
            do
            {
                // foreach char in row
                allShown = true;
                for (byte charIndex = 0; charIndex < (8); charIndex++)
                {
                    // if char is not shown, do 1 step and check again.
                    char test1 = text[charIndex];
                    char test2 = Characters[currentPositionList[charIndex]];
                    if (text[charIndex] != Characters[currentPositionList[charIndex]])
                    {
                        driverChip.flap(charIndex);
                        if (text[charIndex] != Characters[currentPositionList[charIndex]])
                        {
                            allShown = false;
                        }
                    }
                }

                //wait to enable flaps to complete turn
                Thread.Sleep(100);
            } while (!allShown);

        }

        public void Test()
        {
            driverChip.Test(Characters.Length);
        }
    }
}
