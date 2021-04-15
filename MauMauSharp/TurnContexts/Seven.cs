﻿using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;
using System;
using System.Collections.Immutable;

namespace MauMauSharp.TurnContexts
{
    public class Seven : ITurnContext
    {
        /// <inheritdoc />
        public ImmutableArray<Card> PlayableCards { get; }

        /// <inheritdoc />
        public int CardsToDrawOnPass { get; } = 2;

        private readonly Card _topPlayedCard;

        public Seven(Card topPlayedCard)
        {
            if (topPlayedCard is not { Rank: Rank.Seven })
                throw new ArgumentException(
                    $"Can't construct Seven turn context with non-Seven top played card: {topPlayedCard}");
            
            _topPlayedCard = topPlayedCard;
        }

        private Seven(Card topPlayedCard, int cardsToDrawOnPass)
        {
            _topPlayedCard = topPlayedCard;
            CardsToDrawOnPass = cardsToDrawOnPass + 2;
        }

        /// <inheritdoc />
        public ITurnContext NextTurnContext(Card? playedCard, IPlayer activePlayer)
            => playedCard switch
            {
                { Rank: Rank.Seven } => new Seven(playedCard, CardsToDrawOnPass)
            };
    }
}
