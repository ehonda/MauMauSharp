using System.Collections.Immutable;
using MauMauSharp.Cards;
using MauMauSharp.Players;

namespace MauMauSharp.TurnContexts
{
    public class Seven : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer) => null;
    }
}
