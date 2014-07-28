using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class ElementExtensionTests
    {
        [Test]
        public void RockBeatsScissors()
        {
            var rock = Element.Rock;
            var scissors = Element.Scissors;
            Assert.That(rock.Beats(scissors));
        }

        [Test]
        public void ScissorsBeatsPaper()
        {
            var scissors = Element.Scissors;
            var paper = Element.Paper;
            Assert.That(scissors.Beats(paper));
        }

        [Test]
        public void PaperBeatsRock()
        {
            var paper = Element.Paper;
            var rock = Element.Rock;
            Assert.That(paper.Beats(rock));
        }
    }
}
