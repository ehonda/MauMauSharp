using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using Sprache;
using System;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Cards
{
    public static class Grammar
    {
        private static Parser<Rank> Rank()
            => Enum
                .GetValues<Rank>()
                .Zip(Enum.GetValues<Rank>().Select(Encoding.RankEncoding))
                .Select(rankAndEncoding => Parse.Char(rankAndEncoding.Second).Return(rankAndEncoding.First))
                .Aggregate(Parse.Or);

        private static Parser<Suit> Suit()
            => Enum
                .GetValues<Suit>()
                .Zip(Enum.GetValues<Suit>().Select(Encoding.SuitEncoding))
                .Select(suitAndEncoding => Parse.Char(suitAndEncoding.Second).Return(suitAndEncoding.First))
                .Aggregate(Parse.Or);

        public static Parser<Card> Card() =>
            from rank in Rank()
            from suit in Suit()
            select new Card(rank, suit);
    }
}
