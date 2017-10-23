using System.Dynamic;
using System.Text.RegularExpressions;

namespace WorkItOut.UnitTest
{
    public class Exercise
    {
        public string Name { get; set; }
        public Set Set { get; set; }

        public Exercise()
        {

        }

        public Exercise(string name, Set set)
        {
            Name = name;
            Set = set;
        }


        public void ConvertStringToExercise(string exercise)
        {
            var pattern = @"\s+(?=\d)";
            var result = Regex.Split(exercise, pattern);
            Name = result[0];
            var setComponents = result[1].Split(',');
            Set = new Set(setComponents[0], setComponents[1]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Exercise item))
            {
                return false;
            }
            return Name.Equals(item.Name)
                && Set.Equals(item.Set);
        }
    }
}