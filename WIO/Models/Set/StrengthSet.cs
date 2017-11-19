namespace WorkItOut.UnitTest
{
    public class StrengthSet
    {
        public int Repetitions { set; get; }
        public double Weight { set; get; }

        public StrengthSet(double weight, int repetitions)
        {
            Repetitions = repetitions;
            Weight = weight;
        }


        public override bool Equals(object obj)

        {
            if (!(obj is StrengthSet item))
            {
                return false;
            }
            return Repetitions.Equals(item.Repetitions)
                   && Weight.Equals(item.Weight);
        }
    }
}