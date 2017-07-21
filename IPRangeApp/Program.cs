using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace IPRangeApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: iprangeapp <startIp> <endIp>");
                return;
            }

            try
            {
                var ips = GetIPInRange(args[0], args[1]);
                foreach (var ipAddress in ips)
                {
                    Console.WriteLine(ipAddress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static List<IPAddress> GetIPInRange(string startIp, string endIp)
        {
            int start = BitConverter.ToInt32(startIp.Split('.').Reverse().Select(byte.Parse).ToArray(), 0);
            int end = BitConverter.ToInt32(endIp.Split('.').Reverse().Select(byte.Parse).ToArray(), 0);
            List<IPAddress> addresses = new List<IPAddress>();
            for (int i = start; i <= end; i++)
            {
                byte[] bytes = BitConverter.GetBytes(i);
                addresses.Add(new IPAddress(new[] { bytes[3], bytes[2], bytes[1], bytes[0] }));
            }

            return addresses;
        }
    }
}
