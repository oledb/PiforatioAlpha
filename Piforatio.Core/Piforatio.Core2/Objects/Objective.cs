namespace Piforatio.Core2
{
    public class Objective
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public ObjectiveStatus? Status { get; set; }
    }
}
