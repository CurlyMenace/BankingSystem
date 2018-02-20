using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.VisualBasic.FileIO;
namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Message.EmailMessage> email = new List<Message.EmailMessage>();
        List<Message.SMSMessage> sms = new List<Message.SMSMessage>();
        List<Message.TweetMessage> tweet = new List<Message.TweetMessage>();
        List<Message.SIRMessage> sirEmail = new List<Message.SIRMessage>();

        private void sendMsg()
        {
            string header = null;
            string sender = senderBox.Text;
            string topic = topicBox.Text;
            string message = messageBox.Text;
            int messageID = 100000000;
            if(smsButton.IsChecked == true)
            {
                header = "S" + messageID;
                messageID++;

            }
            else if(emailBtn.IsChecked == true)
            {
                header = "E" + messageID;
                messageID++;

            }

            using (var writer = new StreamWriter(@"F:\kek.csv", true))
            {
                var lineToSave = string.Format("{0},{1},{2},{3}", header, sender, topic, message);
                
                writer.WriteLine(lineToSave + writer.NewLine);
                writer.Flush();
            }
        }
        private void readMsg()
        {
            var lines = File.ReadLines(@"F:\kek.csv");

            foreach(string line in lines)
            {
                char splitChar = ',';
                string getLines = line;
                string[] splitLines = getLines.Split(splitChar);
                if(splitLines[0].Contains("E"))
                {
                    email.Add(new Message.EmailMessage(splitLines[0], splitLines[1], splitLines[2], splitLines[3]));
                    
                }
                else if (splitLines[0].Contains("SE"))
                {
                    sirEmail.Add(new Message.SIRMessage(splitLines[0], splitLines[1], splitLines[2], splitLines[3]));
                }
                else if(splitLines[0].Contains("S"))
                {
                    sms.Add(new Message.SMSMessage(splitLines[0], splitLines[1], splitLines[2]));
                }
                else if(splitLines[0].Contains("T"))
                {
                    tweet.Add(new Message.TweetMessage(splitLines[0], splitLines[1], splitLines[2]));
                }

                msgReader.Text = mewsage();

            }

        }

        public string mewsage()
        {
            string message = null;

            for (int i = 0; i < email.Count; i++)
            {
                message +="\n" + email.ElementAt(i).MessageHeader + email.ElementAt(i).MessageSender + 
                    email.ElementAt(i).MessageTopic + email.ElementAt(i).MessageText;
            }

            for(int i = 0; i < sms.Count; i++)
            {
                message += "\n" + sms.ElementAt(i).MessageHeader + sms.ElementAt(i).MessageSender
                    + sms.ElementAt(i).MessageText;            
            }

            for (int i = 0; i < sirEmail.Count; i++)
            {
                message += "\n" + sirEmail.ElementAt(i).MessageHeader + sirEmail.ElementAt(i).MessageSender +
                       sirEmail.ElementAt(i).MessageTopic + sirEmail.ElementAt(i).MessageText;
            }

            for (int i = 0; i < tweet.Count; i++)
            {
                message += "\n" + tweet.ElementAt(i).MessageHeader + tweet.ElementAt(i).MessageSender
                    + tweet.ElementAt(i).MessageText;
            }

            return message;
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            sendMsg();
            readMsg();
        }
    }
}
