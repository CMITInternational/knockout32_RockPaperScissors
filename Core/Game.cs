using System;

namespace Core
{
    public class Game
    {
        public Game(GamePlayer player1, GamePlayer player2)
        {
            if (player1 == null) throw new ArgumentNullException("player1");
            if (player2 == null) throw new ArgumentNullException("player2");

            Player1 = player1;
            Player2 = player2;
        }

        public GamePlayer Player1 { get; private set; }
        public GamePlayer Player2 { get; private set; }
    }
}