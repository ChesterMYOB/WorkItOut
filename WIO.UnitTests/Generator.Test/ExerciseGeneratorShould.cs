using System.Collections.Generic;
using WIO.Generator;
using Xunit;

namespace WorkItOut.UnitTest
{
    public class ExerciseGeneratorShould
    {
        private readonly ExerciseGenerator _exerciseGenerator;

        public ExerciseGeneratorShould()
        {
            _exerciseGenerator = new ExerciseGenerator();
        }

        [Fact]
        public void CreateAnExercise_SingleWorded_SingleRep()
        {
            const string exercise = "Exercise 10,100";
            var expected = new Exercise
            {
                Name = "Exercise",
                Sets = new List<StrengthSet>
                {
                    new StrengthSet(10,100)
                }
            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAnExercise_MultiWorded_SingleRep()
        {
            const string exercise = "Another Exercise 10,100";
            var expected = new Exercise
            {
                Name = "Another Exercise",
                Sets = new List<StrengthSet>
                {
                    new StrengthSet(10,100)
                }
            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAnExercise_SingleWorded_SeveralSingleReps()
        {
            const string exercise = "Exercise 10,100,20,200,30,300";
            var expected = new Exercise
            {
                Name = "Exercise",
                Sets = new List<StrengthSet>
                {
                    new StrengthSet(10,100),
                    new StrengthSet(20,200),
                    new StrengthSet(30,300)
                }
            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Exercise 1:10,100", 1, 10, 100)]
        [InlineData("Exercise 3:10,100", 3, 10, 100)]
        public void CreateAnExercise_SingleWorded_CombinedRep(string exercise, int sets, double weight, int reps)
        {
            var expected = new Exercise {Name = "Exercise"};
            for (var i = 0; i < sets; i++)
            {
                expected.Sets.Add(new StrengthSet(weight, reps));
            }
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAnExercise_SingleRep_MultiRep()
        {
            const string exercise = "Exercise 10,100,2:20,200";
            var expected = new Exercise
            {
                Name = "Exercise",
                Sets = new List<StrengthSet>
                {
                    new StrengthSet(10,100),
                    new StrengthSet(20,200),
                    new StrengthSet(20,200)
                }
            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAnExercise_MultiRep_SingleRep()
        {
            const string exercise = "Exercise 2:20,200,10,100";
            var expected = new Exercise
            {
                Name = "Exercise",
                Sets = new List<StrengthSet>
                {                 
                    new StrengthSet(20,200),
                    new StrengthSet(20,200),
                    new StrengthSet(10,100)
                }
            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }
    }
}