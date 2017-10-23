using System;
using System.Collections.Generic;

namespace WorkItOut.UnitTest
{
    public class SimpleTextProcessor
    {
        public SimpleTextConfiguration SimpleTextConfiguration { set; get; }
        public List<Workout> ProcessInput(string workout)
        {
            var workoutComponents = SeparateComponents(workout);
            workoutComponents.TryGetValue(InputComponent.Date, out var date);
            workoutComponents.TryGetValue(InputComponent.Weight, out var weight);
            workoutComponents.TryGetValue(InputComponent.Exercise, out var exercise);
            return null;
        }


        public Dictionary<InputComponent, string> SeparateComponents(string simpleInput)
        {
            var inputArray = simpleInput.Split('\n');
            return new Dictionary<InputComponent, string>
            {
                {InputComponent.Date, inputArray[0]},
                {InputComponent.Weight, inputArray[1]},
                {InputComponent.Exercise, inputArray[2]}
            };
        }

        public DateTime ProcessDate(string date)
        {
            var dateComponents = date.Split('/');
            return new DateTime(DateTime.UtcNow.Year, int.Parse(dateComponents[1]), int.Parse(dateComponents[0]));
        }

        public Exercise ProcessExercise(string workout)
        {
            var exercise = new Exercise();
            exercise.ConvertStringToExercise(workout);
            return exercise;
        }
    }
}