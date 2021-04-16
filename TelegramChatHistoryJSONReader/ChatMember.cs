using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TelegramChatHistoryJSONReader
{
    public class ChatMember : INotifyPropertyChanged
    {
        public List<Message> Messages { get; set; }
        private string _name;
        private long _id;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public float AverageMessageLength
        {
            get
            {
                int TotalSymbols = 0;
                foreach (var p in Messages)
                {
                    TotalSymbols += p.text.Length;
                }
                return TotalSymbols / Messages.Count();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static Dictionary<long, ChatMember> LoadChatFromJSON(string path)
        {
            string jsonString = File.ReadAllText(path);
            var chat = JsonSerializer.Deserialize<Chat>(jsonString);
            Dictionary<long, ChatMember> ChatMembers = new();
            foreach (var p in chat.messages)
            {
                if (!ChatMembers.ContainsKey(p.from_id))
                {
                    ChatMembers.Add(p.from_id, new ChatMember { Id = p.from_id, Name = p.from, Messages = new List<Message>() });
                }
                ChatMembers[p.from_id].Messages.Add(p);
            }
            return ChatMembers;
        }
    }
}
