using System.Linq;
using Mastermind.Core;
using NUnit.Framework;

namespace Mastermind.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            MastermindEngine mstrm = new MastermindEngine();

            mstrm.SecretCombination = new Combination(new[]
                {AttemptColor.Blue, AttemptColor.Red, AttemptColor.Green, AttemptColor.Green});

            var colors1 = new Combination(new[]
                {AttemptColor.Green, AttemptColor.Red, AttemptColor.Magenta, AttemptColor.Green});
            
            var colors2 = new Combination(new[]
                {AttemptColor.Green, AttemptColor.Blue, AttemptColor.Blue, AttemptColor.Blue});
            
            var colors3 = new Combination(new[]
                {AttemptColor.Blue, AttemptColor.Red, AttemptColor.Red, AttemptColor.Red});

            var colors4 = new Combination(new[]
                            {AttemptColor.Blue, AttemptColor.Red, AttemptColor.Green, AttemptColor.Green});
            

            Assert.True(mstrm.Validate(colors1).CorrectPosition == 2);
            Assert.True(mstrm.Validate(colors1).CorrectColor == 1);
            
            Assert.True(mstrm.Validate(colors2).CorrectPosition == 0);
            Assert.True(mstrm.Validate(colors2).CorrectColor == 3);
            
            Assert.True(mstrm.Validate(colors3).CorrectPosition == 2);
            Assert.True(mstrm.Validate(colors3).CorrectColor == 0);
            
            Assert.True(mstrm.Validate(colors4).GameWon);
            Assert.False(mstrm.Validate(colors4).GameLost);
            
            
            
            
        }
    }
}