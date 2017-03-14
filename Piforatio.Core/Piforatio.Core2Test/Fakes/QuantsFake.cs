using System;
using System.Collections.Generic;
using Piforatio.Core2;

namespace Piforatio.Core2Test.Fakes
{
    public static class QuantsFake
    {
        public static FakeContextFactory factory;
        public static void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
        }
        public static Quants Create(Objectives obj)
        {
            Recreate();
            var learn = obj.ReadObjectives("Read book");
            var testSite = obj.ReadObjectives("Create test")[0];
            var findWork = obj.ReadObjectives("Find work")[0];
            var prepay = obj.ReadObjectives("Receive")[0];
            var fake = new Quants(factory);
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 2, 28, 12, 00, 00),
                Objective = learn,
                Comment = "25 page out of 256",
                Count = 4
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 2, 28, 13, 10, 00),
                Objective = learn,
                Comment = "60 page out of 256",
                Count = 4
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 3, 1, 10, 15, 00),
                Objective = testSite,
                Comment = "Create new empty site",
                Count = 1
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 3, 1, 11, 25, 00),
                Objective = findWork,
                Comment = "try to find",
                Count = 4
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 3, 1, 14, 25, 00),
                Objective = findWork,
                Comment = "try to find",
                Count = 4
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 3, 2, 10, 45, 00),
                Objective = findWork,
                Comment = "try to find",
                Count = 2
            });
            fake.Create(new Quant()
            {
                Time = new DateTime(2017, 3, 2, 11, 25, 00),
                Objective = prepay,
                Comment = "try to get prepay",
                Count = 4
            });

            return fake;
        }
    }
}
