using MauMauSharp.Cards;
using MauMauSharp.Cards.Decks;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.TurnContexts
{
    public class Regular : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; } = 1;

        public Regular(Card topPlayedCard)
            => PlayableCards = Deck
                .AllCardsOfSuit(topPlayedCard.Suit)
                .Concat(Deck
                    .AllCardsOfRank(topPlayedCard.Rank))
                .Concat(Deck
                    .AllCardsOfRank(Rank.Jack))
                .Distinct()
                .ToImmutableArray();

        private Regular(IEnumerable<Card> playableCards)
        {
            PlayableCards = playableCards.ToImmutableArray();
        }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer)
            => playedCard switch
            {
                null => new Regular(PlayableCards),

                {
                    Rank: Rank.King
                    or Rank.Queen
                    or Rank.Ten
                    or Rank.Nine
                    or Rank.Eight
                } => new Regular(playedCard)
            };
    }
}
