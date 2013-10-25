using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SplitflapsFrontend.Datalayer.Ethernet
{
    class TCPClient
    {

        #region Members

        private TcpClient client;
        private NetworkStream clientStream;

        #endregion

        public void Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            }

            catch (Exception e)
            {
            }
            clientStream = client.GetStream();
        }

        public void SendToServer(string tweet)
        {

            if (client.Connected)
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] encodedTweet = encoding.GetBytes(tweet);

                byte[] dataToWrite = new byte[encodedTweet.Length + 1];
                dataToWrite[0] = (byte)RequestResponse.SHOW_NEW_TWEET;
                Array.Copy(encodedTweet, 0, dataToWrite, 1, encodedTweet.Length);

                try
                {
                    clientStream.Write(dataToWrite, 0, dataToWrite.Length);
                }

                catch (Exception e)
                {
                }
            }
        }

        public enum RequestResponse : byte
        {
            NOP = 0,
            SHOW_NEW_TWEET = 1
        }
    }
}
