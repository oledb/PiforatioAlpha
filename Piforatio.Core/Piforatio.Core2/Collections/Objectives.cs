using System;
using System.Collections.Generic;

namespace Piforatio.Core2
{
    public class Objectives : BaseArray<Objective>
    {
        public Objectives() : base() { }

        public List<Objective> GetObjectives(string template)
        {
            return Get(o => o.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public List<Objective> GetObjectives(ObjectiveStatus status)
        {
            return Get(o => o.Status == status);
        }
    }
}
