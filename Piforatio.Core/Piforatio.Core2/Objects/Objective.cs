﻿using System.Collections.Generic;

namespace Piforatio.Core2
{
    public class Objective
    {
        public int ObjectiveID { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public ObjectiveStatus? Status { get; set; }
        public  ICollection<Quant> Quants { get; set; }
    }
}
