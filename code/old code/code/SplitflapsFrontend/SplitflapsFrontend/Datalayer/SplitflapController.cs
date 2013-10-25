using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SplitflapsFrontend.Datalayer.Ethernet;

namespace SplitflapsFrontend.Datalayer
{
    class SplitflapController
    {

        TCPClient tcpClient;

        public SplitflapController()
        {
            tcpClient = new TCPClient();

            // TODO: Fill in proper IP
            ConnectTCP("127.0.0.1", 3000);
        }

        public void ConnectTCP(string ip, int port)
        {
            tcpClient.Connect(ip, port);
        }

        public void Show(string tweet)
        {
            tcpClient.SendToServer(tweet);
        }
    }
}
