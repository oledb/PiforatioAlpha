using System;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    public class FakeContextFactory : IContextFactory
    {
        public PiforatioContext Create()
        {
            throw new NotImplementedException();
        }
    }
}
