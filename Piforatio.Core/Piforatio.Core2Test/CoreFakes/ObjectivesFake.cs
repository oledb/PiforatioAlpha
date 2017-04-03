using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class ObjectivesFake
    {
        public static Objectives Create(FakeContextFactory factory, params Projects[] projects)
        {
            var proj = projects.Length == 0 ? ProjectsFake.Create(factory) : projects[0];
            var mvc = proj.ReadSingle(p => p.Name == "MVC");
            var upwork = proj.ReadSingle(p => p.Name == "Upwork");
            var fake = new Objectives(factory);
            fake.Create(new Objective
            {
                Name = "Read book about Mvc",
                Status = ObjectiveStatus.InProgress,
                Project = mvc
            });
            fake.Create(new Objective
            {
                Name = "Create test site using Mvc",
                Status = ObjectiveStatus.NotStarted,
                Project = mvc
            });
            fake.Create(new Objective
            {
                Name = "Find work",
                Status = ObjectiveStatus.Completed,
                Project = upwork
            });
            fake.Create(new Objective
            {
                Name = "Receive prepay",
                Status = ObjectiveStatus.NotStarted,
                Project = upwork
            });

            return fake;
        }
    }
}
