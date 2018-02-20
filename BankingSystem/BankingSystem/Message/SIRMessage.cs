using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Message
{
    public class SIRMessage
    {
        public string MessageHeader { get; set; }

        public string MessageText { get; set; }
        public string MessageSender { get; set; }
        public string MessageTopic { get; set; }

        public SIRMessage(string header, string text, string sender, string topic)
        {
            MessageHeader = header;
            MessageText = text;
            MessageSender = sender;
            MessageTopic = topic;
        }
    }
}
