using System;

namespace Piforatio.WPF
{
    public class MyDateTime : IDateTime
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
