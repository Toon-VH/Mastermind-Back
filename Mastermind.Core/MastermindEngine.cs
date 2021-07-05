using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Core
{
    public class MastermindEngine
    {
        public Combination SecretCombination { get; set; }
        public List<ValidatedCombination> Attempts { get; set; }

        public MastermindEngine()
        {
            Attempts = new List<ValidatedCombination>();
        }

        public void Start()
        {
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

            var indexes = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                if (SecretCombination.Colors[i] == Attempts.Last().Colors[i])
                {
                    indexes.Add(i);
                    correctPositions++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (indexes.Contains(i)) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (indexes.Contains(j)) continue;

                    if (SecretCombination.Colors[i] == Attempts.Last().Colors[j])
                    {
                        correctColors++;
                        break;
                    }
                }
            }
            Attempts.Last().Result = new Result(correctPositions, correctColors, Attempts.Count >= 9 ? true : false);
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
            return (AttemptColor)rdm;
        }
    }
}