using System;

namespace Core
{
    public class GameEngine : IGameEngine
    {
        public GamePlayer GetWinner(Game game)
        {
            if (game.Player1.ChosenElement.Beats(game.Player2.ChosenElement))
            {
                return game.Player1;
            }
            return game.Player2;
        }

        public Element GetRandomElement()
        {
            var values = Enum.GetValues(typeof(Element));
            var random = new Random();
            var indices = random.Next(values.Length);
            return (Element)values.GetValue(indices);
        }
    }
}