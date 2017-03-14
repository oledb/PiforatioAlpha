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
            int id = 0;
            fake.Create(new Objective()
            {
                ID = id++,
                Name = "Read book about Mvc",
                Status = ObjectiveStatus.InProgress,
                Project = Mvc
            });
            fake.Create(new Objective()
            {
                ID = id++,
                Name = "Create test site using Mvc",
                Status = ObjectiveStatus.NotStarted,
                Project = Mvc
            });
            fake.Create(new Objective()
            {
                ID = id++,
                Name = "Find work",
                Status = ObjectiveStatus.Completed,
                Project = Upwork
            });
            fake.Create(new Objective()
            {
                ID = id++,
                Name = "Receive prepay",
                Status = ObjectiveStatus.NotStarted,
                Project = Upwork
            });

            return fake;
        }
    }
}
