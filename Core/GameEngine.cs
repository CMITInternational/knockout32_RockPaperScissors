using System;

namespace Core
{
    public class GameEngine : IGameEngine
    {
        private static int lastIndeces = 0;

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
            int indices;
            var values = Enum.GetValues(typeof(Element));
            var random = new Random();
            while ((indices = random.Next(values.Length)) == lastIndeces)
            {
                continue;
            }
            lastIndeces = indices;
            return (Element)values.GetValue(indices);
        }
    }
}