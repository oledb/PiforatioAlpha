using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class QuantCollection
    {
        private List<Quant> _list;
        public QuantCollection()
        {
            _list = new List<Quant>();
        }

        public void Add(Quant quant)
        {
            _list.Add(quant);
        }

        public int Length
        {
            get
            {
                return _list.Count;
            }
        }
    }
}
