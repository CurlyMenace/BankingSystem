using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Message
{
    public class EmailMessage
    {
        public string MessageHeader { get; set; }

        public string MessageText { get; set; }
        public string MessageSender { get; set; }
        public string MessageTopic { get; set; }

        public EmailMessage(string Header, string Text, string Sender, string Topic)
        {
            MessageHeader = Header;
            MessageSender = Sender;
            MessageTopic = Topic;
            MessageText = Text;
        }
    }
}
