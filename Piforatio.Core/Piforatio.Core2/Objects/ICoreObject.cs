using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public interface ICoreObject
    {
        int ID { get; set; }
        void Update(ICoreObject obj);
    }
}
