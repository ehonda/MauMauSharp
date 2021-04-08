using MauMauSharp.Cards;
using MauMauSharp.Games;

namespace MauMauSharp.Players
{
    public interface IPlayer
    {
        // TODO: Use Maybe<Card> here
        public Card? PassOrPlayCard(GameState gameState);
    }
}
