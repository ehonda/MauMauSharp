using MauMauSharp.Cards;
using MauMauSharp.Players;
using System.Collections.Immutable;

namespace MauMauSharp.TurnContexts
{
    public class Ace : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; } = ImmutableArray<Card>.Empty;

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; } = 0;

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer) => null;
    }
}
