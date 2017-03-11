using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Quant 
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Objective Objective { get; set; }
        public string Comment { get; set; }
        public int Count { get; set; }
    }
}
