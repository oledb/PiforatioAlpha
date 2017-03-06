using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Plan : ICoreObject
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Objective Objective { get; set; }

        public void Update(ICoreObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
