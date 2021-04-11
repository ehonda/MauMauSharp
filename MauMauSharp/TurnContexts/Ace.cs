using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;
using System;
using System.Collections.Immutable;

namespace MauMauSharp.TurnContexts
{
    public class Ace : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; } = ImmutableArray<Card>.Empty;

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; } = 0;

        private readonly Card _topPlayedCard;

        public Ace(Card topPlayedCard)
        {
            if (topPlayedCard is not { Rank: Rank.Ace })
                throw new ArgumentException(
                    $"Can't construct Ace turn context with non-Ace top played card: {topPlayedCard}");

            _topPlayedCard = topPlayedCard;
        }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer)
            => playedCard switch
            {
                null => new Regular(_topPlayedCard),

                _ => throw new InvalidOperationException(
                    $"Can't play a card on an Ace turn: {playedCard}")
            };
    }
}
