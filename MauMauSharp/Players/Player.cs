using MauMauSharp.Cards;
using MauMauSharp.Games;

namespace MauMauSharp.Players
{
    public abstract class Player : IPlayer
    {
        /// <inheritdoc />
        public Card? PassOrPlayCard(GameState gameState) => null;
    }
}