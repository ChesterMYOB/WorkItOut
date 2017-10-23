using System;
using Xunit;


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
        public void ReturnSeparatedOutDateWeightAndExerciseComponents()
        {
            const string simpleInput = "[DATE]\n[WEIGHT]\n[EXERCISE]";          
            var resultDictionary = _simpleTextProcessor.SeparateComponents(simpleInput);

            resultDictionary.TryGetValue(InputComponent.Date, out var actual);
            Assert.Equal("[DATE]", actual);

            resultDictionary.TryGetValue(InputComponent.Weight, out actual);
            Assert.Equal("[WEIGHT]", actual);

            resultDictionary.TryGetValue(InputComponent.Exercise, out actual);
            Assert.Equal("[EXERCISE]", actual);
        }

        [Fact]
        public void ReturnADateTime_WhenProvidedAShortenedDate()
        {
            const string shortenedDate = "20/10";
            var date = _simpleTextProcessor.ProcessDate(shortenedDate);

            var expected = new DateTime(DateTime.UtcNow.Year, 10, 20);
            Assert.Equal(expected, date);
        }

        [Fact]
        public void ReturnAnExerciseObject_WhenASimpleExerciseIsProcessed()
        {
            const string simpleExercise = "Exercise 10,100";
            var exercise = _simpleTextProcessor.ProcessExercise(simpleExercise);

            var expected = new Exercise("Exercise", new Set("10", "100"));
            Assert.Equal(expected, exercise);
        }

    }
}
