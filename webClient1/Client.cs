using web1;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebClient
{
    internal class Client
    {
        static void Main(string[] args)
        {
            
            string myNick = "141";
            string ip = "127.0.0.1";
            SendMessage(myNick, ip);
            
        }


        public static void SendMessage(string From, string ip)
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

                Message message = new Message() { 
                    Text = messageText, 
                    IdFrom = From, 
                    NicknameTo = "Server", 
                    DateTime = DateTime.Now };

                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);
         
            }

        }
     
    }
}