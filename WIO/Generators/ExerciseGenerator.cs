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
        private readonly char _exerciseSeparator = '\n';
        private readonly string _componentSeparator = @"\s+(?=\d)";
        private readonly char _setSeparator = ',';
        private readonly char _multiSetSeparator = ':';

        public List<Exercise> CreateExerciseCollection(string exercises)
        {
            var exerciseArray = exercises.Split(_exerciseSeparator);
            return exerciseArray.Select(CreateExercise).ToList();
        }

        public Exercise CreateExercise(string exercise)
        {
            var exerciseComponents = Regex.Split(exercise, _componentSeparator);
            var createdExercise = new Exercise
            {
                Name = exerciseComponents[0],
                Sets = ExtractSets(exerciseComponents[1])
            };
            return createdExercise;
        }

        private List<StrengthSet> ExtractSets(string sets)
        {
            var strengthSets = new List<StrengthSet>();
            var setComponents = sets.Split(_setSeparator); 
            
            for (var i = 0; i < setComponents.Length; i+=2)
            {
                if (setComponents[i].Contains(_multiSetSeparator))
                {
                    var multiSet = setComponents[i].Split(_multiSetSeparator);
                    var repeats = int.Parse(multiSet[0]);
                    var weight = double.Parse(multiSet[1]);
                    var reps = int.Parse(setComponents[i + 1]);

                    for (var j = 0; j < repeats; j++)
                    {
                        strengthSets.Add(new StrengthSet(weight, reps));
                    }
                }
                else
                {
                    strengthSets.Add(new StrengthSet(double.Parse(setComponents[i]), int.Parse(setComponents[i + 1])));

                }
            }
            return strengthSets;

        }
    }
}
