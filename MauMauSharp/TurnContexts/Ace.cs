using MauMauSharp.Cards;
using MauMauSharp.Players;
using System.Collections.Immutable;

namespace MauMauSharp.TurnContexts
{
    public class Ace : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer) => null;
    }
}
