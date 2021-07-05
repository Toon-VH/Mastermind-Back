using System;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Mastermind.Core;

namespace Mastermind.Con
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                var mastermind = new MastermindEngine();
                mastermind.Start();
                Print(mastermind);
                var attempt = "";
                Result result;
                do
                {
                    foreach (var value in Enum.GetValues(typeof(AttemptColor)))
                    {
                        Console.ForegroundColor = GetConsoleColor((AttemptColor) value);
                        Console.Write($"({value.ToString()[0]}){value.ToString().Substring(1)}     ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine();

                    Regex regex = new Regex("^[RGBMYC]{4}$", RegexOptions.IgnoreCase);
                    Console.Write("Code: ");
                    attempt = Console.ReadLine();
                    while (!regex.IsMatch(attempt))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Please enter a valid input:");
                        Console.ForegroundColor = ConsoleColor.White;
                        attempt = Console.ReadLine();
                    }

                    result = mastermind.Validate(CodeToCombination(attempt));
                    Console.Clear();
                    Title();
                    Print(mastermind);
                } while (!result.GameLost && !result.GameWon);

                Ending(result, mastermind.SecretCombination);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Do you want to play again? (y/n): ");
                Regex regex2 = new Regex("^[yn]{1}$", RegexOptions.IgnoreCase);
                string answer = Console.ReadLine();
                while (!regex2.IsMatch(answer))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter a valid input:");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                }

                playing = answer == "y" ? true : false;
            }
        }

        private static Combination CodeToCombination(string code)
        {
            Combination combination = new Combination();
            combination.Colors = new AttemptColor[4];

            for (var i = 0; i < code.Length; i++)
            {
                combination.Colors[i] = CharToColor(code[i]);
            }

            return combination;
        }

        private static AttemptColor CharToColor(char color)
        {
            AttemptColor result;
            switch (char.ToUpper(color))
            {
                case 'R':
                    result = AttemptColor.Red;
                    break;
                case 'G':
                    result = AttemptColor.Green;
                    break;
                case 'Y':
                    result = AttemptColor.Yellow;
                    break;
                case 'B':
                    result = AttemptColor.Blue;
                    break;
                case 'M':
                    result = AttemptColor.Magenta;
                    break;
                case 'C':
                    result = AttemptColor.Cyan;
                    break;

                default:
                    result = AttemptColor.Red;
                    break;
            }

            return result;
        }

        private static void Print(MastermindEngine core)
        {
            var counter = 1;
            core.Attempts.ForEach(a =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{counter++}\t");
                a.Colors.ToList().ForEach(ac =>
                {
                    Console.ForegroundColor = GetConsoleColor(ac);
                    Console.Write(ac.ToString()[0] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\tHint {a.Result.CorrectPosition}/{a.Result.CorrectColor}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            });
            var emptyLines = 9 - core.Attempts.Count;
            for (var i = 0; i < emptyLines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{counter++}\t");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                for (var j = 0; j < 4; j++)
                {
                    Console.Write("- ");
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }

        private static ConsoleColor GetConsoleColor(AttemptColor color)
        {
            ConsoleColor result;
            switch (color)
            {
                case AttemptColor.Red:
                    result = ConsoleColor.Red;
                    break;
                case AttemptColor.Green:
                    result = ConsoleColor.Green;
                    break;
                case AttemptColor.Blue:
                    result = ConsoleColor.Blue;
                    break;
                case AttemptColor.Magenta:
                    result = ConsoleColor.Magenta;
                    break;
                case AttemptColor.Yellow:
                    result = ConsoleColor.Yellow;
                    break;
                case AttemptColor.Cyan:
                    result = ConsoleColor.Cyan;
                    break;
                default:
                    result = ConsoleColor.White;
                    break;
            }

            return result;
        }


        private static void Ending(Result result, Combination combination)
        {
            if (result.GameLost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(AsciiStrings.Lost);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(AsciiStrings.Win);
            }

            Console.Write("The code was: ");
            combination.Colors.ToList().ForEach(color => Console.Write(color + " "));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(AsciiStrings.Mastermind);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}