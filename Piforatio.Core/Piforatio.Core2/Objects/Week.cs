using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Week : ICoreObject
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public string Achivments { get; set; }

        public void Update(ICoreObject @new)
        {
            var week = @new as Week;
            if (!string.IsNullOrEmpty(week.Achivments))
                Achivments = week.Achivments;
            if (week.StartDate != default(DateTime))
                StartDate = week.StartDate;
        }
    }
}
