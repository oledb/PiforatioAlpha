using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piforatio.Core2
{
    public class Objective
    {
        public int ObjectiveID { get; set; }
        public string Name { get; set; }
        public int? Project_ProjectID { get; set; }
        [ForeignKey("Project_ProjectID")]
        public Project Project { get; set; }
        public ObjectiveStatus? Status { get; set; }
        public  ICollection<Quant> Quants { get; set; }
    }
}
