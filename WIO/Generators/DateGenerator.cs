using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIO.Generators
{
    class DateGenerator
    {
        public DateTime CreateDateFromString(string date)
        {
            var dateComponents = date.Split('/');
            return new DateTime(DateTime.UtcNow.Year, int.Parse(dateComponents[1]), int.Parse(dateComponents[0]));
        }
    }
}
