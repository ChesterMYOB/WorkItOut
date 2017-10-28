using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;


namespace WorkItOut.UnitTest
{

    public class SimpleTextProcessorShould
    {
        private readonly SimpleTextProcessor _simpleTextProcessor;
        public SimpleTextProcessorShould()
        {
            _simpleTextProcessor = new SimpleTextProcessor();
        }

        [Fact]
        public void ReturnDictionaryOfWorkoutComponents_WhenSeparatorIsNewLine()
        {
            const string simpleInput = "[DATE]\n" + "[WEIGHT]\n" + "[EXERCISE]";
            var gymSessionComponents = _simpleTextProcessor.SeparateComponents(simpleInput);

            gymSessionComponents.TryGetValue(GymComponent.Date, out var date);
            Assert.Equal("[DATE]", date);

            gymSessionComponents.TryGetValue(GymComponent.Weight, out var weight);
            Assert.Equal("[WEIGHT]", weight);

            gymSessionComponents.TryGetValue(GymComponent.Exercises, out var exercise);
            Assert.Equal("[EXERCISE]", exercise);
        }

        [Fact]
        public void ReturnADateTime_WhenStringDateIsProcessed()
        {
            const string monthDayDate = "20/10";
            var date = _simpleTextProcessor.ProcessDate(monthDayDate);

            var expected = new DateTime(DateTime.UtcNow.Year, 10, 20);
            Assert.Equal(expected, date);
        }

        [Fact]
        public void ReturnAOneSetWorkout_WhenSingleSetWorkoutIsProcessed()
        {
            const string simpleExercise = "Exercise 10,100";
            var exercise = _simpleTextProcessor.ProcessExercise(simpleExercise);

            var expected = new List<Exercise> {
                new Exercise{
                    Name = "Exercise",
                    Sets = new List<StrengthSet>
                    {
                        new StrengthSet(10, 100)
                    }
                }
            };
            CollectionAssert.AreEqual(expected, exercise);
        }

        [Fact]
        public void ReturnTwoWorkouts_WhenTwoWorkoutsAreProcessed()
        {
            const string simpleExercise = "Exercise 10,100";
            var exercise = _simpleTextProcessor.ProcessExercise(simpleExercise);

            var expected = new List<Exercise> {
                new Exercise{
                    Name = "Exercise",
                    Sets = new List<StrengthSet>
                    {
                        new StrengthSet(10, 100)
                    }
                }
            };
            CollectionAssert.AreEqual(expected, exercise);
        }

        [Fact]
        public void ReturnAWorkout_WhenAWorkoutWithMultiWordNameIsProcessed()
        {
            const string simpleExercise = "Another Exercise 10,100";
            var exercise = _simpleTextProcessor.ProcessExercise(simpleExercise);

            var expected = new List<Exercise> {
                new Exercise{
                    Name = "Another Exercise",
                    Sets = new List<StrengthSet>
                    {
                        new StrengthSet(10, 100)
                    }
                }
            };
            CollectionAssert.AreEqual(expected, exercise);
        }

        [Fact]
        public void ReturnAThreeSetWorkout_WhenTripleSetWorkoutIsProcessed()
        {
            const string simpleExercise = "Exercise 10,100,20,200,30,300";
            var exercise = _simpleTextProcessor.ProcessExercise(simpleExercise);

            var expected = new List<Exercise> {
                new Exercise{
                    Name = "Exercise",
                    Sets = new List<StrengthSet>
                    {
                        new StrengthSet(10, 100),
                        new StrengthSet(20, 200),
                        new StrengthSet(30, 300)
                    }
                }
            };
            CollectionAssert.AreEqual(expected, exercise);
        }
    }
}
