using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class GamePlayerTests
    {
        [Test]
        public void GamePlayerShouldThrowExceptionIfNameIsNull()
        {
            var nullArgumentException =
                Assert.Throws<ArgumentNullException>(() => new GamePlayer(name: null, chosenElement: Element.Rock, isComputer: false));

            Assert.That(nullArgumentException.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void GamePlayerConstructorShouldSetName()
        {
            var gamePlayer = new GamePlayer(name: "P1", chosenElement: Element.Rock, isComputer: false);

            Assert.That(gamePlayer.Name, Is.EqualTo("P1"));
        }

        [Test]
        public void GamePlayerConstructorShouldSetChosenElement()
        {
            var gamePlayer = new GamePlayer(name: "P1", chosenElement: Element.Rock, isComputer: false);

            Assert.That(gamePlayer.ChosenElement, Is.EqualTo(Element.Rock));
        }
    }
}
