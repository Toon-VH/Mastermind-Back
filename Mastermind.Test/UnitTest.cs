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


            Assert.AreEqual(2 , mstrm.Validate(colors1).CorrectPosition);
            Assert.AreEqual(1 , mstrm.Validate(colors1).CorrectColor);

            Assert.AreEqual(0 , mstrm.Validate(colors2).CorrectPosition);
            Assert.AreEqual(2 , mstrm.Validate(colors2).CorrectColor);

            Assert.AreEqual(2 , mstrm.Validate(colors3).CorrectPosition);
            Assert.AreEqual(0 , mstrm.Validate(colors3).CorrectColor);

            Assert.True(mstrm.Validate(colors4).GameWon);
            Assert.False(mstrm.Validate(colors4).GameLost);
        }

        [Test]
        public void Test2()
        {
            MastermindEngine mstrm = new MastermindEngine();
            mstrm.SecretCombination = new Combination(new[]
                {AttemptColor.Yellow, AttemptColor.Green, AttemptColor.Magenta, AttemptColor.Green});

            var colors1 = new Combination(new[]
                {AttemptColor.Green, AttemptColor.Yellow, AttemptColor.Blue, AttemptColor.Magenta});
            var colors2 = new Combination(new[]
                {AttemptColor.Magenta, AttemptColor.Blue, AttemptColor.Yellow, AttemptColor.Green});

            Assert.AreEqual(0 , mstrm.Validate(colors1).CorrectPosition);
            Assert.AreEqual(3 , mstrm.Validate(colors1).CorrectColor);

            Assert.AreEqual(1 , mstrm.Validate(colors2).CorrectPosition);
            Assert.AreEqual(2 , mstrm.Validate(colors2).CorrectColor);
        }
        
        [Test]
        public void Test3()
        {
            MastermindEngine mstrm = new MastermindEngine();
            mstrm.SecretCombination = new Combination(new[]
                {AttemptColor.Green, AttemptColor.Red, AttemptColor.Blue, AttemptColor.Red});

            var colors1 = new Combination(new[]
                {AttemptColor.Yellow, AttemptColor.Blue, AttemptColor.Red, AttemptColor.Green});
            
            var colors2 = new Combination(new[]
                {AttemptColor.Blue, AttemptColor.Yellow, AttemptColor.Green, AttemptColor.Cyan});

            Assert.AreEqual(0,mstrm.Validate(colors1).CorrectPosition);
            Assert.AreEqual(3 , mstrm.Validate(colors1).CorrectColor);
            
            Assert.AreEqual(0 , mstrm.Validate(colors2).CorrectPosition);
            Assert.AreEqual(2 , mstrm.Validate(colors2).CorrectColor);
            
        }
    }
}