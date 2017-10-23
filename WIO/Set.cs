namespace WorkItOut.UnitTest
{
    public class Set
    {
        public string Repetitions { set; get; }
        public string Weight { set; get; }

        public Set(string repetitions, string weight)
        {
            Repetitions = repetitions;
            Weight = weight;
        }

        public Set()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Set item))
            {
                return false;
            }
            return Repetitions.Equals(item.Repetitions)
                   && Weight.Equals(item.Weight);
        }
    }
}