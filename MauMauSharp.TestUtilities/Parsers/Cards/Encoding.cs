using JetBrains.Annotations;
using MauMauSharp.Cards.Enums;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Cards
{
    [PublicAPI]
    public static class Encoding
    {
        public static char RankEncoding(Rank rank)
            => rank switch
            {
                Rank.Seven => '7',
                Rank.Eight => '8',
                Rank.Nine => '9',
                Rank.Ten => 'T',
                Rank.Jack => 'J',
                Rank.Queen => 'Q',
                Rank.King => 'K',
                Rank.Ace => 'A',
                _ => throw new ArgumentException($"Can't encode unknown rank: {rank}")
            };

        public static ImmutableArray<(Rank, char)> AllRanksWithEncodings { get; }
            = Enum
                .GetValues<Rank>()
                .Zip(Enum
                    .GetValues<Rank>()
                    .Select(RankEncoding))
                .ToImmutableArray();

        public static char SuitEncoding(Suit suit)
            => suit switch
            {
                Suit.Spades => 's',
                Suit.Hearts => 'h',
                Suit.Diamonds => 'd',
                Suit.Clubs => 'c',
                _ => throw new ArgumentException($"Can't encode unknown suit: {suit}")
            };

        public static ImmutableArray<(Suit, char)> AllSuitsWithEncodings { get; }
            = Enum
                .GetValues<Suit>()
                .Zip(Enum
                    .GetValues<Suit>()
                    .Select(SuitEncoding))
                .ToImmutableArray();
    }
}
