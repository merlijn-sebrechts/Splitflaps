using System;
using Microsoft.SPOT;

using TwitterSplitflaps.Datalayer.Twitter;
using TwitterSplitflaps.Datalayer.Splitflap;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using System.Threading;

namespace TwitterSplitflaps.Business
{
    class OfflineProgram
    {
        OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
        private SplitflapRail rail;

        public OfflineProgram()
        {
            led.Write(false);
            // Initialize splitflaps
            rail = new SplitflapRail(8);


            // Start the main loop
            MainLoop();
        }

        private void MainLoop()
        {
            while (true)
            {

                led.Write(true);



                rail.Show("IKDOEICTT");
                Thread.Sleep(10000);

                led.Write(false);

                rail.Show("PPPPPPPP");
            }
        }
    }
}
