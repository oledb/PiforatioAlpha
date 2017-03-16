using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piforatio.Core2
{
    public class Plan
    {
        public int PlanID { get; set; }
        public DateTime Date { get; set; }
        public int? Objective_ObjectiveID { get; set; }
        [ForeignKey("Objective_ObjectiveID")]
        public Objective Objective { get; set; }
    }
}
