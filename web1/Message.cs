using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace web1
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string NickNameFrom { get; set; }
        public string NickNameTo { get; set; }
        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
        public static Message? DeserializeMessageToJson(string message) => JsonSerializer.Deserialize<Message>(message);

        public override string ToString()
        {
            return $"{DateTime}\n от кого: {NickNameFrom}\nкому:{NickNameTo}\nтекст:{Text}\n";
        }
    }
}
