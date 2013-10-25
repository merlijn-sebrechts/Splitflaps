using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

using TwitterSplitflaps.Datalayer.I2C;
using System.Text;

namespace TwitterSplitflaps.Datalayer.Splitflap
{
    class SplitflapRail
    {
        private SplitflapConfig[] splitflapList;
        private PortExpanderPlug[] portExpanderplugList;
        private const int NUMBER_OF_ROWS = 2;
        OutputPort OutputPortRow2 = new OutputPort(Pins.GPIO_PIN_D0, false);

        public SplitflapRail(int length)
        {
            //check if testing configuration. If so,, do test
            if (length == 8)
            {
                this.splitflapList = new SplitflapConfig[8]
            {
                new SplitflapConfig(0, 0x20, 7, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 6, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 5, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 4, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 3, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 2, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 1, PortExpanderPlug.Sides.A, false),
                new SplitflapConfig(0, 0x20, 0, PortExpanderPlug.Sides.A, false),
            };

                this.portExpanderplugList = new PortExpanderPlug[1]
            {
                new PortExpanderPlug(0x20, false)
            };
            }
            else
            {
                this.splitflapList = new SplitflapConfig[length];

                //foreach splitflap in splitflaplist, create new splitflap
                for (int flapIndex = 0; flapIndex < splitflapList.Length; flapIndex++)
                {
                    this.splitflapList[flapIndex] = new SplitflapConfig(
                        0,
                        (byte)((((flapIndex % (splitflapList.Length / NUMBER_OF_ROWS))) / 16) + 32), // 0 0 1 0 0 A2 A1 A0
                        (byte)(flapIndex % 8),
                        (PortExpanderPlug.Sides)((flapIndex % 16) / 8),
                        (flapIndex / (splitflapList.Length / NUMBER_OF_ROWS)) == 1
                    );
                }


                int plugCount = (int)System.Math.Ceiling((((float)splitflapList.Length / (float)NUMBER_OF_ROWS) / (float)16));
                this.portExpanderplugList = new PortExpanderPlug[plugCount * 2];

                //foreach portExpanderplug
                for (int plugIndex = 0; plugIndex < portExpanderplugList.Length; plugIndex++)
                {
                    OutputPortRow2.Write(plugIndex / NUMBER_OF_ROWS == 1);
                    portExpanderplugList[plugIndex] = new PortExpanderPlug((byte)(plugIndex + 32), plugIndex / NUMBER_OF_ROWS == 1);
                };
            }
        }

        public void Show(string text)
        {
            // Make text to be exactly number of flaps. If shorter, add spaces.
            if (text.Length > splitflapList.Length)
            {
                text = text.Substring(0, splitflapList.Length);
            }
            else if (text.Length < splitflapList.Length)
            {
                int paddLength = splitflapList.Length - text.Length;

                for (int i = 0; i < paddLength; i++)
                {
                    text += " ";
                }
            }

            // foreach row
            int flapsPerRow = splitflapList.Length / 2;
            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                // while not all chars are shown
                bool allShown = false;
                do
                {
                    // foreach char in row
                    allShown = true;
                    for (int charIndex = rowIndex * flapsPerRow; charIndex < ((rowIndex + 1) * flapsPerRow); charIndex++)
                    {
                        // if char is not shown, do 1 step and check again.
                        string test1 = (text[charIndex] + "");
                        string test2 = SplitflapConfig.Characters[charIndex];
                        if ((text[charIndex] + "") != SplitflapConfig.Characters[splitflapList[charIndex].CurrentPosition])
                        {
                            GoOne(splitflapList[charIndex]);
                            if ((text[charIndex] + "") != SplitflapConfig.Characters[splitflapList[charIndex].CurrentPosition])
                            {
                                allShown = false;
                            }
                        }
                        string test4 = test1 + test2;
                    }

                    //wait to enable flaps to complete turn
                    Thread.Sleep(100);
                } while (!allShown);
            }
        }

        private void GotoCharacter(int characterPosition, SplitflapConfig splitflapConfig)
        {

            while (splitflapConfig.CurrentPosition != characterPosition)
            {
                Thread.Sleep(100);
                GoOne(splitflapConfig);
            }
        }

        private void GoOne(SplitflapConfig splitflapConfig)
        {
            foreach(PortExpanderPlug portExpanderPlug in portExpanderplugList)
            {
                if((portExpanderPlug.Address == splitflapConfig.PortExpanderAddress) && (portExpanderPlug.Row2 == splitflapConfig.Row2))
                {
                    OutputPortRow2.Write(portExpanderPlug.Row2);

                    //get current byte
                    byte value = 0;
                    if(splitflapConfig.Side == PortExpanderPlug.Sides.A)
                    {
                        value = portExpanderPlug.CurrentByteA;
                    } else {
                        value = portExpanderPlug.CurrentByteB;
                    }

                    // toggle bit
                    value ^= (byte)(1 << splitflapConfig.PortExpanderBit);

                    // write new byte
                    portExpanderPlug.WriteToPins(value, splitflapConfig.Side);

                    splitflapConfig.CurrentPosition++;
                    break;
                }
            }
        }

        public void SetCurrentPositions(string text)
        {
            
            if (text.Length > splitflapList.Length)
            {
                text = text.Substring(0, splitflapList.Length - 1);
            }

            int indexText = 0;

            foreach (SplitflapConfig config in splitflapList)
            {
                // Get value from SplitflapConfig.Characters
                for (int characterPosition = 0; characterPosition < SplitflapConfig.Characters.Length; characterPosition++)
                {
                    if ((text[indexText] + "") == SplitflapConfig.Characters[characterPosition])
                    {
                        config.CurrentPosition = (byte)characterPosition;
                        indexText++;
                        break;
                    }
                }

                if (text.Length == indexText) break;       
            }
        }

        /// <summary>
        /// Method used to make up for increase in the split flap positions.
        /// Method called after booting and after first show.
        /// </summary>
        /// <param name="forward">Whether or not the method is called after boot</param>
        public void IncreasePositions(bool boot)
        {

            // On boot
            if (boot)
            {
                foreach (SplitflapConfig config in splitflapList)
                {
                    // Depending on the position the splitflap is on, it will go forward 1 or 2 while booting/initializing the splitflaps
                    if (config.CurrentPosition % 2 == 0) config.CurrentPosition++;

                }
            }

            // On first show
            else
            {
                foreach (SplitflapConfig config in splitflapList)
                {
                    // Depending on the position the splitflap is on, it will go forward 1 or 2 while booting/initializing the splitflaps
                    if (config.CurrentPosition % 2 != 0) config.CurrentPosition++;
                }
            }
        }

        public override string ToString()
        {

            StringBuilder splitflapString = new StringBuilder();

            foreach (SplitflapConfig config in splitflapList)
            {
                splitflapString.Append(config.ToString());
            }

            return splitflapString.ToString();
        }
    }
}
