using MauMauSharp.Cards;
using MauMauSharp.Games;

namespace MauMauSharp.Players
{
    public interface IPlayer
    {
        public Card RequestCardToPlay(GameState gameState);
    }
}
