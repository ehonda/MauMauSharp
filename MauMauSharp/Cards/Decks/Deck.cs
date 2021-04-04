using System;
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
    }
}
