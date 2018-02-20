using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Message
{
    public class TweetMessage
    {
        public string MessageHeader { get; set; }

        public string MessageText { get; set; }
        public string MessageSender { get; set; }

        public TweetMessage(string header, string text, string sender)
        {
            MessageHeader = header;
            MessageText = text;
            MessageSender = sender;
     
        }
    }
}
