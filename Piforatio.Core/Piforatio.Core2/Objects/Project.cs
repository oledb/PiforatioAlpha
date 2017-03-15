using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Project : ICoreObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ProjectType? Type { get; set; }
        public string Comment { get; set; }
        public ICollection<Objective> Objectives { get; set; }

        public void Update(ICoreObject @new)
        {
            var newP = @new as Project;
            if (!string.IsNullOrEmpty(newP.Name))
                Name = newP.Name;
            if (newP.Type != null)
                Type = newP.Type;
            if (!string.IsNullOrEmpty(newP.Comment))
                Comment = newP.Comment;
        }
    }
}
