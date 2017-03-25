using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class ObjectivesFake
    {
        public static Objectives Create(FakeContextFactory factory, params Projects[] projects)
        {
            Projects proj;
            if (projects.Length == 0)
                proj = ProjectsFake.Create(factory);
            else
                proj = projects[0];
            var Mvc = proj.ReadSingle(p => p.Name == "MVC");
            var Upwork = proj.ReadSingle(p => p.Name == "Upwork");
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
