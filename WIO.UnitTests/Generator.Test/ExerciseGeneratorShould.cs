using System.Collections.Generic;
using WIO.Generator;
using Xunit;

namespace WorkItOut.UnitTest
{
    public class ExerciseGeneratorShould
    {
        private ExerciseGenerator _exerciseGenerator;

        public ExerciseGeneratorShould()
        {
            _exerciseGenerator = new ExerciseGenerator();
        }

        [Fact]
        public void CreateAnExercise_WhenASingleWordSingleRepExerciseIsProcessed()
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
        public void CreateAnExercise_WhenAMultiWordExerciseIsProcessed()
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
        public void CreateAnExercise_WhenAMultiRepExerciseIsProcessed()
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
        [InlineData("Exercise 1:10,100")]
        [InlineData("Exercise 3:10,100")]
        public void CreateAnExercise_WhenACombinedRepExerciseIsProcessed(string exercise)
        {
            var expected = new Exercise
            {

            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Exercise 10,100,2:20,200")]
        [InlineData("Exercise 2:20,200,10,100")]
        public void CreateAnExercise_WhenASingleRepAndCombinedRepExerciseIsProcessed(string exercise)
        {
            var expected = new Exercise
            {

            };
            var actual = _exerciseGenerator.CreateExercise(exercise);
            Assert.Equal(expected, actual);
        }




    }
}