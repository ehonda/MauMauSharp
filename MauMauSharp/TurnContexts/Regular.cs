using MauMauSharp.Cards;
using MauMauSharp.Players;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MauMauSharp.TurnContexts
{
    public class Regular : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; } = 1;

        public Regular(IEnumerable<Card> playableCards)
        {
            PlayableCards = playableCards.ToImmutableArray();
        }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer)
            => playedCard switch
            {
                null => new Regular(PlayableCards)
            };
    }
}
