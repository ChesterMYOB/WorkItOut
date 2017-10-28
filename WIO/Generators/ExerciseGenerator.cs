using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkItOut.UnitTest;

namespace WIO.Generator
{
    class ExerciseGenerator
    {
        public List<Exercise> CreateExercisesFromString(string exercises)
        {
            var newCharacterPattern = @"\s+(?=\d)"; // Separate by new char
            var workoutSession = new List<Exercise>();
            var exerciseArray = exercises.Split('\n');
            foreach (string exercise in exerciseArray)
            {
                var exerciseComponents = Regex.Split(exercise, newCharacterPattern);
                var singleExercise = new Exercise
                {
                    Name = exerciseComponents[0],
                    Sets = ConvertSets(exerciseComponents[1])
                };
                workoutSession.Add(singleExercise);

            }
            return workoutSession;
        }



        private List<StrengthSet> ConvertSets(string sets)
        {
            var setComponents = sets.Split(',');
            var strengthSets = new List<StrengthSet>();
            for (int i = 0; i < setComponents.Length; i += 2)
            {
                strengthSets.Add(new StrengthSet(int.Parse(setComponents[i]), double.Parse(setComponents[i + 1])));
            }
            return strengthSets;

        }
    }
}
