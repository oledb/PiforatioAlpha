using System;
using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class ProjectsFake
    {
        public static Projects Create()
        {
            var fake = new Projects();
            int index = 0;
            fake.Add(new Project()
            {
                ID = index++,
                Name = "MVC",
                Type = ProjectType.Learn,
                Comment = "Learn MVC, frontend and backend"
            });
            fake.Add(new Project()
            {
                ID = index++,
                Name = "Upwork",
                Type = ProjectType.Work,
                Comment = "Carry out orders"
            });

            return fake;
        }
    }
}
