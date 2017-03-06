using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Plans : BaseArray<Plan>
    {
        public List<Plan> GetPlans(DateTime date)
        {
            return Get(p => p.Date.Date == date.Date);
        }
    }
}
