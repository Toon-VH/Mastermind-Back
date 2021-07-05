namespace Mastermind.Core
{
    public class Result
    {
        public int CorrectPosition { get; set; }
        public int CorrectColor { get; set; }
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }

        public Result(int correctPosition, int correctColor, bool gameLost)
        {
            CorrectPosition = correctPosition;
            CorrectColor = correctColor;
            GameWon = CorrectPosition == 4 ? true : false;
            GameLost = gameLost;
        }
    }
}