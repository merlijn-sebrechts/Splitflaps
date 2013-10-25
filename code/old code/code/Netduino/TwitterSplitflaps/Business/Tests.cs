////using System;
////using Microsoft.SPOT;
////using Microsoft.SPOT.Hardware;
////using System.Threading;
////using TwitterSplitflaps.Datalayer.Splitflap;
////using SecretLabs.NETMF.Hardware.NetduinoPlus;
////using TwitterSplitflaps.Datalayer.SD;
////using System.Net;
////using TwitterSplitflaps.Datalayer.Twitter;
////using TwitterSplitflaps.Overkoepelend;
////using TwitterSplitflaps.Datalayer.I2C;

////namespace TwitterSplitflaps.Business
////{
////    class Tests
////    {

////        TwitterConnection twitter = new TwitterConnection("%23useit");

//<<<<<<< HEAD
//        public Tests()
//        {
//            //TestInternet();
//            Stopwatch sw = Stopwatch.StartNew();
//            for (int i = 0; i < 100; i++)
//            {
//                sw.Start();
//                // ADD TESTS HERE
//                TestSplitFlap();
//                // ADD TESTS HERE
//                Debug.Print("Elapsed Time: " + sw.ElapsedMinutes + "m " + sw.ElapsedSeconds + "s " + sw.ElapsedMilliseconds + "ms");
//                sw.Reset();
//            }
//            sw.Stop();
//        }
//=======
////        public Tests()
////        {
////            TestInternet();
////            Stopwatch sw = Stopwatch.StartNew();
////            for (int i = 0; i < 100; i++)
////            {
////                sw.Start();
////                // ADD TESTS HERE
////                //TestTweetFetching();
////                TestSplitFlap();
////                // ADD TESTS HERE
////                //Debug.Print("Elapsed Time: " + sw.ElapsedMinutes + "m " + sw.ElapsedSeconds + "s " + sw.ElapsedMilliseconds + "ms");
////                sw.Reset();
////            }
////            sw.Stop();
////        }
//>>>>>>> 7da6700e2fefbbb60b75caaa81eb0eebddd865d1


////        public void TestSDCard() {

////            // Write to file
////            SD.WriteStoredTweet("Tweet");

////            // Read from file
////            string tweet = SD.GetStoredTweet();
////        }

////        public void TestInternet() {
////            while (true)
////            {
////                IPAddress ip = IPAddress.GetDefaultLocalAddress();
////                if (ip != IPAddress.Any) break;
////                Thread.Sleep(1000);
////            }
////        }

////        public void TestTweetFetching() {
////            Tweet t = twitter.GetLatestTweet();
////        }

////        public void TestSplitFlap() {
////            SplitflapRail splitflapRail = new SplitflapRail();

//<<<<<<< HEAD
//            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
//            while (true)
//            {
//                splitflapRail.Show("AAAAAAAA");
//                led.Write(true);

//                splitflapRail.Show("BBBBBBBB");
//                led.Write(false);
//            }
//        }
//=======
////            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
////            while (true)
////            {
////                splitflapRail.Show("A");
////                led.Write(true);
////                Thread.Sleep(1000);
////                splitflapRail.Show("I");
////                led.Write(false);
////                Thread.Sleep(1000);
////            }
////        }
//>>>>>>> 7da6700e2fefbbb60b75caaa81eb0eebddd865d1

////        public void TestI2C()
////        {
////            PortExpanderPlug plug = new PortExpanderPlug(0x20);
////            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

////            // *********
////            // switch outputs MCP from 0 to 1
////            // *********
////            while (true)
////            {
////                led.Write(true);
////                plug.WriteToPins(0xFF, PortExpanderPlug.Sides.A);
////                Thread.Sleep(1000);

////                led.Write(false);
////                plug.WriteToPins(0x00, PortExpanderPlug.Sides.A);
////                Thread.Sleep(1000);

////            }
////        }
////    }
////}
