using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace web1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server();
        }


        public static void Server()
        {
          

            Console.WriteLine("Сервер ждет сообщение от клиента");
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            
            while (true)
            {  
                Console.WriteLine();
               
                byte[] buffer = udpClient.Receive(ref iPEndPoint);

                if (buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);

                Message message = Message.DeserializeFromJson(messageText);
                message.Print();

                Message message1 = new Message()
                {
                    Text = Message.AnswerОк,
                    IdFrom = "Server",
                    NicknameTo = message.IdFrom,
                    DateTime = DateTime.Now
                };
                string json1 = message1.SerializeMessageToJson();

                UdpClient udpClient1 = new UdpClient(0);
                IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Parse(message.IdFrom), 0);
                byte[] data = Encoding.UTF8.GetBytes(json1);
                udpClient1.Send(data, data.Length, iPEndPoint1);

            }
        }

    }
}