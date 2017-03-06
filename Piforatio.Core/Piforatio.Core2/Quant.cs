using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Quant : ICoreObject
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Project { get; set; }
        public Objective Objective { get; set; }
        public string Comment { get; set; }
        public int Count { get; set; }

        public void Update(ICoreObject @new)
        {
            var newQuant = @new as Quant;
            if (newQuant.Time != default(DateTime))
                Time = newQuant.Time;
            if (!string.IsNullOrEmpty(newQuant.Project))
                Project = newQuant.Project;
            if (!string.IsNullOrEmpty(newQuant.Comment))
                Comment = newQuant.Comment;
            if (newQuant.Count != 0)
                Count = newQuant.Count;
        }
    }
}
