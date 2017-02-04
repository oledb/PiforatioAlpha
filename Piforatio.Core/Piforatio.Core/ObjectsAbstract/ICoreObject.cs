using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface ICoreObject
    {
        void Update(ICoreObject obj);
    }
}
