using System;
using System.Collections.Immutable;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;

namespace MauMauSharp.TurnContexts
{
    public class Seven : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; }

        private readonly Card _topPlayedCard;

        public Seven(Card topPlayedCard)
        {
            if (topPlayedCard is not { Rank: Rank.Seven })
                throw new ArgumentException(
                    $"Can't construct Seven turn context with non-Seven top played card: {topPlayedCard}");
            
            _topPlayedCard = topPlayedCard;
        }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer) => null;
    }
}
