
namespace TelegramChatHistoryJSONReader
{
    public class Message
    {
        public int id { get; set; }

        public string type { get; set; }

        public string date { get; set; }

        public string from { get; set; }

        public int from_id { get; set; }

        public int reply_to_message_id { get; set; }

        public string text { get; set; }

    }
}
