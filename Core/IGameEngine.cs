namespace Core
{
    public interface IGameEngine
    {
        GamePlayer GetWinner(Game game);
        Element GetRandomElement();
    }
}