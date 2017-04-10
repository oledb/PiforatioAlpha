namespace Piforatio.WPF
{
    public class MessageSender : Notifier
    {
        private string _message;

        public MessageSender()
        {
            Message = "Hello, user!";
        }

        public virtual void Send(string message)
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
