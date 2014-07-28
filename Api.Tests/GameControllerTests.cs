using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Controllers;
using Core;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace Api.Tests
{
    [TestFixture]
    public class GameControllerTests
    {
        private GameController _controllerUnderTest;
        private IGameEngine _gameEngine;

        [SetUp]
        public void Setup()
        {
            _gameEngine = Substitute.For<IGameEngine>();
            _controllerUnderTest = new GameController(_gameEngine);
        }

        [Test]
        public void GetResultsShouldReturnGameResults()
        {

            var game = new GameViewModel
            {
                Player1 = new GamePlayerViewModel
                {
                    Name = "P1",
                    ChosenElement = Element.Scissors,
                    IsComputer = false
                },
                Player2 = new GamePlayerViewModel
                {
                    Name = "P2",
                    ChosenElement = Element.Rock,
                    IsComputer = false
                }
            };

            _gameEngine.GetWinner(Arg.Any<Game>()).Returns(new GamePlayer(name: "P2", chosenElement: Element.Rock, isComputer: false));

            var results = _controllerUnderTest.GetResults(game);

            Assert.That(results.GameWinner.Name, Is.EqualTo("P2"));
            Assert.That(results.GameWinner.ChosenElement, Is.EqualTo(Element.Rock));

            Assert.That(results.GamePlayed.Player1.Name, Is.EqualTo("P1"));
            Assert.That(results.GamePlayed.Player1.ChosenElement, Is.EqualTo(Element.Scissors));

            Assert.That(results.GamePlayed.Player2.Name, Is.EqualTo("P2"));
            Assert.That(results.GamePlayed.Player2.ChosenElement, Is.EqualTo(Element.Rock));
        }

        [Test]
        public void GetResultsShouldSupplyElementForComputerPlayer2()
        {
            var game = new GameViewModel
            {
                Player1 = new GamePlayerViewModel
                {
                    Name = "P1",
                    IsComputer = false,
                    ChosenElement = Element.Scissors
                },
                Player2 = new GamePlayerViewModel
                {
                    Name = "P2",
                    IsComputer = true,
                    ChosenElement = Element.Rock
                }
            };

            _gameEngine.GetRandomElement().Returns(Element.Paper);
            _gameEngine.GetWinner(Arg.Is(GameContaingAPlayerWith(name: "P2", isComputer: true, chosenElement: Element.Paper))).Returns(new GamePlayer(name: "P1", chosenElement: Element.Scissors, isComputer: false));

            var results = _controllerUnderTest.GetResults(game);


            Assert.That(results.GameWinner.Name, Is.EqualTo("P1"));
            Assert.That(results.GameWinner.ChosenElement, Is.EqualTo(Element.Scissors));

            Assert.That(results.GamePlayed.Player1.Name, Is.EqualTo("P1"));
            Assert.That(results.GamePlayed.Player1.ChosenElement, Is.EqualTo(Element.Scissors));

            Assert.That(results.GamePlayed.Player2.Name, Is.EqualTo("P2"));
            Assert.That(results.GamePlayed.Player2.ChosenElement, Is.EqualTo(Element.Paper));
        }

        [Test]
        public void GetResultsShouldSupplyElementForComputerPlayer1()
        {
            var game = new GameViewModel
            {
                Player1 = new GamePlayerViewModel
                {
                    Name = "P1",
                    IsComputer = true,
                    ChosenElement = Element.Rock
                },
                Player2 = new GamePlayerViewModel
                {
                    Name = "P2",
                    IsComputer = false,
                    ChosenElement = Element.Scissors
                }
            };

            _gameEngine.GetRandomElement().Returns(Element.Paper);
            _gameEngine.GetWinner(Arg.Is(GameContaingAPlayerWith(name: "P1", isComputer: true, chosenElement: Element.Paper))).Returns(new GamePlayer(name: "P2", chosenElement: Element.Scissors, isComputer: false));

            var results = _controllerUnderTest.GetResults(game);


            Assert.That(results.GameWinner.Name, Is.EqualTo("P2"));
            Assert.That(results.GameWinner.ChosenElement, Is.EqualTo(Element.Scissors));

            Assert.That(results.GamePlayed.Player1.Name, Is.EqualTo("P1"));
            Assert.That(results.GamePlayed.Player1.ChosenElement, Is.EqualTo(Element.Paper));

            Assert.That(results.GamePlayed.Player2.Name, Is.EqualTo("P2"));
            Assert.That(results.GamePlayed.Player2.ChosenElement, Is.EqualTo(Element.Scissors));
        }

        private Expression<Predicate<Game>> GameContaingAPlayerWith(string name, bool isComputer, Element chosenElement)
        {
            return
                g =>
                    PlayerMatching(g.Player1, name, isComputer, chosenElement) ||
                    PlayerMatching(g.Player2, name, isComputer, chosenElement);
        }

        private bool PlayerMatching(GamePlayer player, string name, bool isComputer, Element chosenElement)
        {
            return player.Name.Equals(name) && player.IsComputer.Equals(isComputer) &&
                   player.ChosenElement.Equals(chosenElement);
        }
    }
}
