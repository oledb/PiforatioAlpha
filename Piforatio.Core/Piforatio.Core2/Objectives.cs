using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Piforatio.Core2
{
    public class Objectives : BaseArray<Objective>
    {
        public Objectives() : base() { }

        public ReadOnlyCollection<Objective> GetObjectives(string template)
        {
            var result = (from q in list
                          where q.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) > 0
                          select q).ToList();

            return result.AsReadOnly();
        }
    }
}
