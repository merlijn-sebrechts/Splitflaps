using System.Threading;
using System.Collections;
using TwitterSplitflaps.Datalayer.Splitflap;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using TwitterSplitflaps.Datalayer.SD;
using TwitterSplitflaps.Datalayer.Ethernet;

namespace TwitterSplitflaps.Business
{
    class MainProgram
    {
        private SplitflapRail rail;
        private TCPServer tcpServer;

        public MainProgram()
        {
       
#if !I2CUnavailable

            // Initialize splitflaps
            
                // Initialize splitflaps

                rail = new SplitflapRail(8);

                // Get tweet from SD
                string sdTweet = SD.GetStoredTweet();


                // Increase one - flaps flip after boot
                rail.IncreasePositions(true);              

                // Increase one - flaps flip after initializing microcontroller
                rail.IncreasePositions(false);

#endif

            // Initialize internet
            
                // Wait till we have internet connection
                OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
                led.Write(true);

                // TODO: Add to check get IP
                // TODO: Fix if not IP is not get after 2 mins or so                

                led.Write(false);

                // Initialize the server on port 3000
                tcpServer = new TCPServer(3000);

                // Hook up the event handler which will fire an event after a new tweet has been received from the client
                tcpServer.OnNewTweet += new TCPServer.NewTweet(ShowNewTweet);

                // Start listening for client connection, after a client has connected it will start receiving
                Thread t = new Thread(new ThreadStart(tcpServer.Listen));
                t.Start();
        }

        private void ShowNewTweet(string text)
        {

#if !I2CUnavailable
            rail.Show(text);
#endif
        }
    }
}
