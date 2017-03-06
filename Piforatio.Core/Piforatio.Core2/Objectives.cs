using System;
using System.Collections.ObjectModel;

namespace Piforatio.Core2
{
    public class Objectives : BaseArray<Objective>
    {
        public Objectives() : base() { }

        public ReadOnlyCollection<Objective> GetObjectives(string template)
        {
            return Get(o => o.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public ReadOnlyCollection<Objective> GetObjectives(string template, ObjectiveStatus status)
        {
            return Get(o => o.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) >= 0 && o.Status == status);
        }
    }
}
