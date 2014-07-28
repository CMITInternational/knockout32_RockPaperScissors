using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Core.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameConstructorShouldThowExceptionIfPlayer1IsNull()
        {
            var nullArgumentException =
                Assert.Throws<ArgumentNullException>(() => new Game(player1: null, player2: new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false)));

            Assert.That(nullArgumentException.ParamName, Is.EqualTo("player1"));
        }

        [Test]
        public void GameConstructorShouldThowExceptionIfPlayer2IsNull()
        {
            var nullArgumentException =
                Assert.Throws<ArgumentNullException>(() => new Game(player1: new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false), player2: null));

            Assert.That(nullArgumentException.ParamName, Is.EqualTo("player2"));
        }

        [Test]
        public void GameConstructorShouldSetPlayer1()
        {
            var game = new Game(player1: new GamePlayer("P1", chosenElement: Element.Scissors, isComputer: false), player2: new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false));

            Assert.That(game.Player1.Name, Is.EqualTo("P1"));
            Assert.That(game.Player1.ChosenElement, Is.EqualTo(Element.Scissors));
        }

        [Test]
        public void GameConstructorShouldSetPlayer2()
        {
            var game = new Game(player1: new GamePlayer("P1", chosenElement: Element.Scissors, isComputer: false), player2: new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false));

            Assert.That(game.Player2.Name, Is.EqualTo("P2"));
            Assert.That(game.Player2.ChosenElement, Is.EqualTo(Element.Rock));
        }
    }
}
