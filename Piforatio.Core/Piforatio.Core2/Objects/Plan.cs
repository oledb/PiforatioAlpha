using System;

namespace Piforatio.Core2
{
    public class Plan : ICoreObject
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Objective Objective { get; set; }

        public void Update(ICoreObject @new)
        {
            var plan = @new as Plan;
            if (plan.Date != default(DateTime))
                Date = plan.Date;
            if (plan.Objective != null)
                Objective = plan.Objective; 
        }
    }
}
