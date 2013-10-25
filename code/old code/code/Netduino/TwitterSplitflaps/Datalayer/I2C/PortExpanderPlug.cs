using System;
using Microsoft.SPOT;



namespace TwitterSplitflaps.Datalayer.I2C
{
    class PortExpanderPlug : I2CPlug
    {
        /// <summary>
        /// registers and register addresses (IODIRA - OLATB = 00h - 15h)
        /// CAUTION: adresses only usable if IOCON.BANK = 0
        /// see datasheet P7
        /// </summary>
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

        public enum Sides
        {
            A,
            B
        }



        private bool row2;
        public bool Row2 { get { return this.row2; } }
        private byte currentByteA;
        public byte CurrentByteA { get { return this.currentByteA; } }
        private byte currentByteB;
        public byte CurrentByteB { get { return this.currentByteB; } }

        public PortExpanderPlug(byte expanderPlugAddress, bool row2)
            : base(expanderPlugAddress)
        {
            this.row2 = row2;
            currentByteA = 0;
            currentByteB = 0;
            RunInitialConfig();
        }
 
        private void RunInitialConfig()
        {
            

            // pins to output
            this.WriteToRegister((byte)Registers.IODIRA, 0x00);
            this.WriteToRegister((byte)Registers.IODIRB, 0x00);

            //// internal pullup on
            //this.WriteToRegister((byte)Registers.GPPUA, 0xFF);
            //this.WriteToRegister((byte)Registers.GPPUB, 0xFF);
        }

        public void WriteToPins(byte value, Sides side)
        {
            if (side == Sides.A)
            {
                this.currentByteA = value;
                this.WriteToRegister((byte)Registers.GPIOA, value);
            }
            else
            {
                this.currentByteB = value;
                this.WriteToRegister((byte)Registers.GPIOB, value);
            }
        }
    }
}