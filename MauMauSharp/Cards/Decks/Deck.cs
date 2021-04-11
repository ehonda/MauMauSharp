using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MauMauSharp.Cards.Enums;

namespace MauMauSharp.Cards.Decks
{
    public static class Deck
    {
        public static ImmutableArray<Card> PiquetPack { get; }
            = Enum
                .GetValues<Suit>()
                .SelectMany(suit => Enum
                    .GetValues<Rank>()
                    .Select(rank => new Card(rank, suit)))
                .ToImmutableArray();

        public static IEnumerable<Card> AllCardsOfRank(Rank rank)
            => Enum
                .GetValues<Suit>()
                .Select(suit => new Card(rank, suit));

        public static IEnumerable<Card> AllCardsOfSuit(Suit suit)
            => Enum
                .GetValues<Rank>()
                .Select(rank => new Card(rank, suit));
    }
}
