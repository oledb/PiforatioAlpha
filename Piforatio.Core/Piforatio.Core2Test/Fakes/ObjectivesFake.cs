using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class ObjectivesFake
    {
        public static Objectives Create(Projects projects)
        {
            var factory = new FakeContextFactory();
            var Mvc = projects.GetSingle(p => p.Name == "MVC");
            var Upwork = projects.GetSingle(p => p.Name == "Upwork");
            var fake = new Objectives(factory);
            fake.Create(new Objective()
            {
                Name = "Read book about Mvc",
                Status = ObjectiveStatus.InProgress,
                Project = Mvc
            });
            fake.Create(new Objective()
            {
                Name = "Create test site using Mvc",
                Status = ObjectiveStatus.NotStarted,
                Project = Mvc
            });
            fake.Create(new Objective()
            {
                Name = "Find work",
                Status = ObjectiveStatus.Completed,
                Project = Upwork
            });
            fake.Create(new Objective()
            {
                Name = "Receive prepay",
                Status = ObjectiveStatus.NotStarted,
                Project = Upwork
            });

            return fake;
        }
    }
}
