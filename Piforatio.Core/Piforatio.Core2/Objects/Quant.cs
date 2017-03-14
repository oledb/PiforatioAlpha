using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Piforatio.Core2
{
    public class Quant 
    {
        [Key]
        public int QuantID { get; set; }
        public DateTime Time { get; set; }
        public Objective Objective { get; set; }
        public string Comment { get; set; }
        public int Count { get; set; }
    }
}
