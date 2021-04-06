using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using Sprache;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Cards
{
    public static class Grammar
    {
        private static Parser<T> FromCharEncoding<T>(T t, char encoding)
            => Parse.Char(encoding).Return(t);

        private static Parser<T> FromCharEncoding<T>((T Value, char Encoding) valueAndEncoding)
            => FromCharEncoding(valueAndEncoding.Value, valueAndEncoding.Encoding);

        private static Parser<Rank> Rank()
            => Encoding
                .AllRanksWithEncodings
                .Select(FromCharEncoding)
                .Aggregate(Parse.Or);

        private static Parser<Suit> Suit()
            => Encoding
                .AllSuitsWithEncodings
                .Select(FromCharEncoding)
                .Aggregate(Parse.Or);

        public static Parser<Card> Card() =>
            from rank in Rank()
            from suit in Suit()
            select new Card(rank, suit);
    }
}
