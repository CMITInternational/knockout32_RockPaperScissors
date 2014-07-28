using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class GameEngineTests
    {
        private GameEngine engineUnderTest;

        [SetUp]
        public void Setup()
        {
            engineUnderTest = new GameEngine();
        }

        [Test]
        public void FindWinnerShouldEvaluateGameAndReturnWinner()
        {
            var rock = new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false);
            var scissors = new GamePlayer(name: "P1", chosenElement: Element.Scissors, isComputer: false);

            var winner = engineUnderTest.GetWinner(new Game(scissors,rock));

            Assert.That(winner.Name, Is.EqualTo("P2"));
        }
    }
}
