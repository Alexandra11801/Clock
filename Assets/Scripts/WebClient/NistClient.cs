using System;
using System.Globalization;
using System.IO;
using System.Net.Sockets;

namespace Clock.WebClient
{
    public static class NistClient
    {
        private const string nistURL = "time-a-g.nist.gov";
        private const int nistPort = 13;

        public static DateTime GetNISTTime()
        {
            var client = new TcpClient(nistURL, nistPort);
            using (var reader = new StreamReader(client.GetStream()))
            {
                var response = reader.ReadToEnd();
                var responseSplit = response.Split(" ");
                var dateTimeString = responseSplit[1] + " " + responseSplit[2];
                var dateTime = DateTime.ParseExact(dateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                return dateTime.ToLocalTime();
            }
        }
    }
}