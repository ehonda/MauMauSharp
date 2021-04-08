using MauMauSharp.Cards;
using MauMauSharp.Games;
using System.Collections.Immutable;

namespace MauMauSharp.Players
{
    public interface IPlayer
    {
        public ImmutableArray<Card> Hand { get; }

        // TODO: Use Maybe<Card> here
        public Card? PassOrPlayCard(GameState gameState);
    }
}
