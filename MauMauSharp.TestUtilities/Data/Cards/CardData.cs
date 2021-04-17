using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Data.Cards
{
    // TODO: There's some duplication between this and main projects' Deck class - Unify!
    [PublicAPI]
    public static class CardData
    {
        public static IEnumerable<Card> AllCards()
            => Enum
                .GetValues<Suit>()
                .SelectMany(suit => Enum
                    .GetValues<Rank>()
                    .Select(rank => new Card(rank, suit)));

        public static IEnumerable<Card> AllCardsOfRank(Rank rank)
            => Enum
                .GetValues<Suit>()
                .Select(suit => new Card(rank, suit));

        public static IEnumerable<Card> AllButRank(Rank rank)
            => AllCards().Except(AllCardsOfRank(rank));
    }
}
