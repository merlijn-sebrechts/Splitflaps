using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using NetduinoPlusApplication2;

namespace NetduinoPlusApplication1
{
    public class Program
    {


        public static void Main()
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





            Rail rail = new Rail();
            rail.Test();


        }
    }
}