using System.Net;
using System.Net.NetworkInformation;

namespace web3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string sait = "yandex.ru";

            IPAddress[] iPAddress = Dns.GetHostAddresses(sait, System.Net.Sockets.AddressFamily.InterNetwork);

            foreach (var item in iPAddress)
            {
                Console.WriteLine(item);
            }

            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();

            List<Thread> threads = new List<Thread>();
            foreach (var item in iPAddress)
            {
                var thread1 = new Thread(() =>
                {

                    Ping p = new Ping();
                    PingReply pingReply = p.Send(item);
                    pings.Add(item, pingReply.RoundtripTime);
                    Console.WriteLine($"{item} : {pingReply.RoundtripTime}");

                });
                threads.Add(thread1);
                thread1.Start();

            }

            foreach (var item in threads)
            {
                item.Join();
            }

            long minPing = pings.Min(x => x.Value);

            Console.WriteLine(minPing);


        }
    }
}