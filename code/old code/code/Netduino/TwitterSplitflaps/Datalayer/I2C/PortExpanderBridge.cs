using System;
using Microsoft.SPOT;
using System.Collections;

namespace TwitterSplitflaps.Datalayer.I2C
{
    class PortExpanderBridge
    {
        private const byte[] DEFAULT_EXPANDER_PLUG_LIST = null;
        private ArrayList portExpanderPlugList;

        /// <summary>
        /// makes portExpanderPlugs with given addresses
        /// </summary>
        /// <param name="addressList"></param>
        public PortExpanderBridge(byte[] addressList)
        {
            foreach(byte address in addressList)
            {
                portExpanderPlugList.Add(new PortExpanderPlug(address));
            }
        }

        /// <summary>
        /// makes portExpanderPlugs from default list
        /// </summary>
        public PortExpanderBridge()
            : this(DEFAULT_EXPANDER_PLUG_LIST)
        {
        }

        /// <summary>
        /// write testbyte to port A of first portExpander
        /// </summary>
        /// <param name="b"></param>
        public void writeTestByte(byte b)
        {
            ((PortExpanderPlug)portExpanderPlugList[0]).WriteA(b);
        }
    }
}
