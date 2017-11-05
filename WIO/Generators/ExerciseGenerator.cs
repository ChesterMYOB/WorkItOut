using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkItOut.UnitTest;

namespace WIO.Generator
{
    public class ExerciseGenerator
    {

        //This is just psudo-code
        //public List<Exercise> CreateExercises(string exercises)
        //{
            // Separate out the exercises
            // Separate out the name and the sets - reps - wight
            // Group reps and sets and add them to the list which becomes the reps
            // Create the exercise object with a name and it's sets
            // Repeat and return the list of exercises
        //    return null;
        //}





        public List<Exercise> CreateExercises(string exercises)
        {         
            var exerciseList = new List<Exercise>();
            var exerciseArray = exercises.Split('\n');
            foreach (var exercise in exerciseArray)
            {
                exerciseList.Add(CreateExercise(exercise));
            }
            return exerciseList;
        }

        public Exercise CreateExercise(string exercise)
        {
            var newCharacterPattern = @"\s+(?=\d)"; // Separate by new char
            var exerciseComponents = Regex.Split(exercise, newCharacterPattern);
            var singleExercise = new Exercise
            {
                Name = exerciseComponents[0],
                Sets = ConvertSets(exerciseComponents[1])
            };
            return singleExercise;
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
