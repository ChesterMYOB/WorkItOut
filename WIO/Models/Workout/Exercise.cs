using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WorkItOut.UnitTest
{
    public class Exercise
    {
        public string Name { get; set; }
        public List<StrengthSet> Sets { get; set; }

        public Exercise()
        {
            Sets = new List<StrengthSet>();
        }

        


        public override bool Equals(object obj)
        {
            if (!(obj is Exercise item))
            {
                return false;
            }
            return Name.Equals(item.Name)
                && Sets.All(item.Sets.Contains);
        }
    }
}