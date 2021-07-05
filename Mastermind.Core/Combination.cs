namespace Mastermind.Core
{
    public class Combination
    {
        public AttemptColor[] Colors { get; set; }

        public Combination()
        {
            
        }
        
        public Combination(AttemptColor[] colors)
        {
            Colors = colors;
        }
    }
}