using System;
using Xunit;


namespace WorkItOut.UnitTest
{

    public class SimpleTextProcessorShould
    {
        [Fact]
        public void SeparateOutDateWeightAndExerciseComponents()
        {
            const string simpleInput = "[DATE]\n[WEIGHT]\n[EXERCISE]";
            var simpleTextProcessor = new SimpleTextProcessor();
            var resultDictionary = simpleTextProcessor.SeparateComponents(simpleInput);

            resultDictionary.TryGetValue(InputComponent.Date, out var actual);
            Assert.Equal("[DATE]", actual);

            resultDictionary.TryGetValue(InputComponent.Weight, out actual);
            Assert.Equal("[WEIGHT]", actual);

            resultDictionary.TryGetValue(InputComponent.Exercise, out actual);
            Assert.Equal("[EXERCISE]", actual);
        }

        [Fact]
        public void ReturnTheDateWhenProvidedAShortenedDate()
        {
            const string shortenedDate = "20/10";
            var simpleTextProcessor = new SimpleTextProcessor();
            var date = simpleTextProcessor.ProcessDate(shortenedDate);
            var expected = new DateTime(DateTime.UtcNow.Year, 10, 20);
            Assert.Equal(expected, date);
        }

    }
}
