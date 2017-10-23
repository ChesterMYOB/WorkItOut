using System;
using System.Collections.Generic;

namespace WorkItOut.UnitTest
{
    public class Workout
    {
        public DateTime Date { set; get; }
        public double Weight { set; get; }
        public List<Exercise> Exercises { set; get; }
    }
}