using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.WPF
{
    public class MessageMaker : Notifier
    {
        private string _message;

        public MessageMaker()
        {
            Message = "Hello, user!";
        }

        public void Send(string message)
        {
            Message = message;      
        }

        public string Message
        {
            get
            {
                return _message;
            }
            private set
            {
                _message = value;
                NotifyPropertyChanged("Message");
            }
        }
    }
}
