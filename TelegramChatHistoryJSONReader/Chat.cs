using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramChatHistoryJSONReader
{
    class Chat
    {
        public string name { get; set; }
        public string type { get; set; }
        public long id { get; set; }
        public List<Message> messages { get; set; }
    }
}
