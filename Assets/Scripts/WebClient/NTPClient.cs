using System;
using System.Net;
using System.Net.Sockets;

namespace Clock.WebClient
{
    public static class NTPClient
    {
        private const string googleTimeURL = "time.google.com";
        private const int googleTimePort = 123;

        public static DateTime GetGoogleTimeTime()
        {
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            var endPoint = new IPEndPoint(Dns.GetHostEntry(googleTimeURL).AddressList[0], googleTimePort);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(endPoint);
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }
            var intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 
                          | (ulong)ntpData[43];
            var fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 
                            | (ulong)ntpData[47];
            var milliseconds = intPart * 1000 + fractPart * 1000 / 0x100000000L;
            return (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds).ToLocalTime();
        }
    }
}