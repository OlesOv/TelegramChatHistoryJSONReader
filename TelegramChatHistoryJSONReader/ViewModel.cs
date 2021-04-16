using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelegramChatHistoryJSONReader
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ChatMember _selectedChatMember;
        public Dictionary<long, ChatMember> ChatMembers { get; set; }

        public ChatMember SelectedChatMember
        {
            get => _selectedChatMember;
            set
            {
                _selectedChatMember = value;
                OnPropertyChanged();
            }
        }

        public ViewModel(string path)
        {
            ChatMembers = ChatMember.LoadChatFromJSON(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
