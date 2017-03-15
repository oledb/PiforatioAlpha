using System;
using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class ProjectsFake
    {
        public static Projects Create(FakeContextFactory factory)
        {
            var fake = new Projects(factory);
            fake.Create(new Project()
            {
                Name = "MVC",
                Type = ProjectType.Learn,
                Comment = "Learn MVC, frontend and backend"
            });
            fake.Create(new Project()
            {
                Name = "Upwork",
                Type = ProjectType.Work,
                Comment = "Carry out orders"
            });

            return fake;
        }
    }
}
