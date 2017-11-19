using System;
using System.Collections.Generic;
using UnitsNet.Units;
using WIO.Generator;
using WIO.Generators;
using WIO.Models;

namespace WorkItOut.UnitTest
{
    public class SimpleTextProcessor
    {
        public SimpleTextConfiguration SimpleTextConfiguration { set; get; }

        #region constructor with default values
      public SimpleTextProcessor()
        {
            SimpleTextConfiguration = new SimpleTextConfiguration
            {
                WorkoutOrdering = "D/W/E",
                LineSeparator = '\n'
            };
        }       
        #endregion
  
        public Workout ProcessWorkout(string workout)
        {
            var ordering = SimpleTextConfiguration.WorkoutOrdering;
            // TODO Ordering dictates the component's arrangement

            var workoutComponents = SeparateComponents(workout);
            return ProcessGymComponents(workoutComponents);
        }

        public Dictionary<GymComponent, string> SeparateComponents(string simpleInput)
        {
            var inputArray = simpleInput.Split(SimpleTextConfiguration.LineSeparator);
            return new Dictionary<GymComponent, string>
            {
                {GymComponent.Date, inputArray[0]},
                {GymComponent.Weight, inputArray[1]},
                {GymComponent.Exercises, inputArray[2]}
            };
        }

        public Workout ProcessGymComponents(Dictionary<GymComponent, string> workoutComponents)
        {
            workoutComponents.TryGetValue(GymComponent.Date, out var date);       
            workoutComponents.TryGetValue(GymComponent.Weight, out var weight);
            workoutComponents.TryGetValue(GymComponent.Exercises, out var exercise);
            return new Workout
            {
                Date = ProcessDate(date),
                Weight = ProcessWeight(weight),
                Exercises = ProcessExercise(exercise)
            };
        }

        //TODO This can be removed when interfaces are created
        public DateTime ProcessDate(string date)
        {
            var dateGenerator = new DateGenerator();
            return dateGenerator.CreateDateFromString(date);
        }

        private Weight ProcessWeight(string weight)
        {
            var weightGenerator = new WeightGenerator();
            return weightGenerator.CreateWeightFromString(weight);
        }

        public List<Exercise> ProcessExercise(string exercises)
        {
            var exerciseGenerator = new ExerciseGenerator();
            return exerciseGenerator.CreateExerciseCollection(exercises);
        }
        // TODO ^^
    }
}