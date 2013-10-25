using System;
using Microsoft.SPOT;

//I2C classes here
using Microsoft.SPOT.Hardware;
using System.Reflection;

namespace TwitterSplitflaps.Datalayer.I2C
{
    class I2CPlug
    {
        private const int DefaultClockRate = 400;
        private const int TransactionTimeout = 1000;

        private I2CDevice.Configuration i2cConfig;
        private I2CDevice i2cDevice;

        private byte address;
        public byte Address
        { get { return this.address; } }

        protected I2CPlug(byte address)
        {
            this.address = address;
            this.i2cConfig = new I2CDevice.Configuration(this.Address, DefaultClockRate);
            this.i2cDevice = new I2CDevice(this.i2cConfig);
        }

        protected void WriteToRegister(byte register, byte value)
        {
            //TODO: comment when debuggin
#if !NOI2C
            I2CDevice.I2CWriteTransaction confOutputTrans = CreateWriteTransaction(new byte[1] { value }, register, 1);
            int sended = i2cDevice.Execute(new I2CDevice.I2CTransaction[] { confOutputTrans }, 1000);
#endif
        }

        private static I2CDevice.I2CWriteTransaction CreateWriteTransaction(byte[] buffer, uint internalAddress, byte internalAddressSize)
        {
            I2CDevice.I2CWriteTransaction writeTransaction = I2CDevice.CreateWriteTransaction(buffer);
            Type writeTransactionType = typeof(I2CDevice.I2CWriteTransaction);

            FieldInfo fieldInfo = writeTransactionType.GetField("Custom_InternalAddress", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(writeTransaction, internalAddress);

            fieldInfo = writeTransactionType.GetField("Custom_InternalAddressSize", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(writeTransaction, internalAddressSize);

            return writeTransaction;
        }

    }

}