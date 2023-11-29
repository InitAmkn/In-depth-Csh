
using System.Net.Sockets;
using System.Net;
using System.Text;
using web1;

namespace webClient1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            SentMessage(args[0], args[1]);
        }


        public static void SentMessage(string From, string ip)
        {

            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);


            while (true)
            {
                string messageText;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите сообщение.");
                    messageText = Console.ReadLine();

                }
                while (string.IsNullOrEmpty(messageText));

                Message message = new Message() { Text = messageText, NickNameFrom = From, NickNameTo = "Server", DateTime = DateTime.Now };
                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);
            }

        }
    }
}