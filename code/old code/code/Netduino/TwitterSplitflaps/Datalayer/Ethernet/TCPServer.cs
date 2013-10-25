using System;
using Microsoft.SPOT;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

namespace TwitterSplitflaps.Datalayer.Ethernet
{
    class TCPServer
    {

        #region Members

        private Socket socketListener;
        private Socket socketClient;

        private bool receivingData;
        
        public delegate void NewTweet(string text);
        public event NewTweet OnNewTweet;

        #endregion

        /// <summary>
        /// Constructor for TCPServer.
        /// Initializes a new TCPServer instance which listens on the specified port.
        /// </summary>
        /// <param name="port">The port on which the socket needs to listen</param>
        public TCPServer(int port)
        {
            socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));           
        }

        /// <summary>
        /// Listens for a client connections.
        /// Run this in another thread.
        /// </summary>
        public void Listen() 
        {
            socketListener.Listen(100);

            // This is a blocking call so you best run this function threadded
            socketClient = socketListener.Accept();
            receivingData = true;
            Receive();
        }

        /// <summary>
        /// Recieves data on the client socket
        /// Raises the OnNewTweet event when usable data has been received.
        /// </summary>
        private void Receive()
        {

            while (receivingData)
            {
                // Make a buffer in which we recieve the new tweet
                // The length is determined by having 
                byte[] buffer = new byte[1024];

                // This is a blocking call so you best run this function threadded
                try {
                    socketClient.Receive(buffer);
                } 
                
                catch (Exception e) 
                {
                }

                // If there's data..
                if ((RequestResponse)buffer[0] != RequestResponse.NOP)
                {
                    if ((RequestResponse)buffer[0] == RequestResponse.SHOW_NEW_TWEET)
                    {
                        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                        char[] characters = encoding.GetChars(buffer);

                        StringBuilder sb = new StringBuilder();
                        
                        for (int i = 1; i < characters.Length; i++)
                        {
                            if (characters[i] > 31) sb.Append(characters[i]);
                        }

                        if (OnNewTweet != null) OnNewTweet(sb.ToString());
                    }
                }

                // No data, connection probaly has been closed or an exception occured
                // Probaly not ideal but..
                // TODO: Add relistening for client
                else
                {
                    receivingData = false;
                }
            }
        }
    }

    public enum RequestResponse : byte 
    { 
        NOP = 0,
        SHOW_NEW_TWEET = 1
    }
}
