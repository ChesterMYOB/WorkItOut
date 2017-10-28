using System;
using System.Collections.Generic;
using WIO.Models;

namespace WorkItOut.UnitTest
{
    public class Workout
    {
        public DateTime Date { set; get; }
        public Weight Weight { set; get; }
        public List<Exercise> Exercises { set; get; }
    }
}