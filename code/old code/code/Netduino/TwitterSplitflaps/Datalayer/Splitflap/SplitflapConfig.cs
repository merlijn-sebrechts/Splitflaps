using System;
using Microsoft.SPOT;
using System.Collections;

using TwitterSplitflaps.Datalayer.I2C;

namespace TwitterSplitflaps.Datalayer.Splitflap
{
    class SplitflapConfig
    {

        public static readonly string[] Characters = new string[] { 
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "pijlke",
            "-",
            "/",
            ":",
            " ",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            ".",
        };

        private const byte maxPosition = 39;
        private byte portExpanderAddress;
        private byte currentPosition;
        private PortExpanderPlug.Sides side;
        private byte portExpanderBit;
        private bool row2;

        public byte CurrentPosition
        {
            get { return this.currentPosition; }
            set
            {
                this.currentPosition = value;

                if (value > maxPosition)
                {
                    this.currentPosition = 0;
                }
                else if (value < 0)
                {
                    this.currentPosition = maxPosition;
                }
            }
        }
        
        public byte PortExpanderAddress { 
            get { 
                return this.portExpanderAddress; 
            } 
        }

        /// <summary>
        /// bit 0 - 7
        /// </summary>
        public byte PortExpanderBit { 
            get { 
                return this.portExpanderBit;
            } 
        }
        
        public PortExpanderPlug.Sides Side { 
            get { 
                return this.side; 
            } 
        }

        public bool Row2
        {
            get
            {
                return this.row2;
            }
        }

        public SplitflapConfig(byte currentPosition, byte portExpanderAddress, byte portExpanderBit, PortExpanderPlug.Sides side, bool row2)
        {
            this.CurrentPosition = currentPosition;
            this.portExpanderAddress = portExpanderAddress;
            this.portExpanderBit = portExpanderBit;
            this.side = side;
            this.row2 = row2;
        }

        public override string ToString()
        {
            return Characters[this.currentPosition];
        }
    }
}
