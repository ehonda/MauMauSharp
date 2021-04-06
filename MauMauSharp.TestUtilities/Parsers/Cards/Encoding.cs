using System;
using MauMauSharp.Cards.Enums;

namespace MauMauSharp.TestUtilities.Parsers.Cards
{
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

        public static char SuitEncoding(Suit suit)
            => suit switch
            {
                Suit.Spades => 's',
                Suit.Hearts => 'h',
                Suit.Diamonds => 'd',
                Suit.Clubs => 'c',
                _ => throw new ArgumentException($"Can't encode unknown suit: {suit}")
            };
    }
}
