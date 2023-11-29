


//Мы пишем простое чат-приложение способное передавать сообщения с компьютера на компьютер. 
//Начнем с разработки модели сообщений для нашего чата. 
//Договоримся что у каждого пользователя может быть свой ник-нейм - уникальное имя. 
//Ему можно будет передать сообщение, состоящее из даты, никнейма отправителя  и текста сообщения. 
//Как мог бы выглядеть класс представляющий сообщение в этом случае.

using System.Net.Sockets;
using System.Net;
using System.Text;

namespace web1
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            Message msg = new Message() { Text = "Hellow", DateTime = DateTime.Now, NickNameFrom = "Artem", NickNameTo = "All" };
            string json = msg.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msgDeserialized = Message.DeserializeMessageToJson(json);
        }

        public void Server(string name)
        { 
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("The server is waiting for the client");
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                if(buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);
                Message? message = Message.DeserializeMessageToJson(messageText);
                Console.WriteLine(message);
            }

        }


        //    public bool SentMessage(string message)
        //    {
        //        using (Socket listner = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //        {
        //            var remoteEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
        //            listner.Blocking = true;
        //            listner.Bind(remoteEndpoint);
        //            listner.Listen(100);

        //            Console.WriteLine("wait");
        //            var socket = listner.Accept();

        //            Console.WriteLine("connected");
        //            listner.Close();
        //        }
        //  } 
    }

}
