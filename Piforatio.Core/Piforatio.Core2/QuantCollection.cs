using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ReadOnlyCollection<Quant> GetQuants(DateTime date)
        {
            var result = (from q in _list
                          where DateTime.Compare(q.Time.Date, date.Date) == 0
                          orderby q.Time
                          select q).ToList();

            return result.AsReadOnly();
        }

        public ReadOnlyCollection<Quant> GetQuants(int week)
        {
            return GetQuants(new DateTime(2017, 02, 27));
        }
    }
}
