using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Core
{
    public class MastermindEngine
    {

        public int Difficulty { get; set; }
        public Combination SecretCombination { get; set; }
        public List<ValidatedCombination> Attempts { get; set; }

        public MastermindEngine(int difficulty = 9)
        {
            Difficulty = difficulty;
            Attempts = new List<ValidatedCombination>();
            CreateRandomCombination();
        }
        

        public Result Validate(Combination combination)
        {
            int correctPositions = 0;
            int correctColors = 0;

            Attempts.Add(new ValidatedCombination()
            {
                Colors = combination.Colors,
            });
            
            
            var indexesPosition = new List<int>();
            
            var indexesColors = new List<int>();
            
            for (int i = 0; i < 4; i++)
            {
                if (SecretCombination.Colors[i] == Attempts.Last().Colors[i])
                {
                    indexesPosition.Add(i);
                    correctPositions++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (indexesPosition.Contains(i)) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (indexesPosition.Contains(j)) continue;
                    
                    if (indexesColors.Contains(j)) continue;
                    
                    if (SecretCombination.Colors[i] == Attempts.Last().Colors[j])
                    {
                        indexesColors.Add(i);
                        correctColors++;
                        break;
                    }
                }
            }

            Attempts.Last().Result = new Result(correctPositions, correctColors, Attempts.Count >= Difficulty ? true : false);
            return Attempts.Last().Result;
        }


        private void CreateRandomCombination()
        {
            Combination combination = new Combination();
            combination.Colors = new AttemptColor[4];
            for (int i = 0; i < 4; i++)
            {
                combination.Colors[i] = RandomColorPicker();
            }

            SecretCombination = combination;
        }

        private AttemptColor RandomColorPicker()
        {
            var rand = new Random();
            var rdm = rand.Next(0, 6);
            return (AttemptColor) rdm;
        }
    }
}