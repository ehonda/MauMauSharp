using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.TurnContexts;
using System.Collections.Generic;

namespace MauMauSharp.TestUtilities.Data.TurnContexts
{
    public static class RegularData
    {
        private static Rank SomeUnknownRank { get; } = (Rank)55555;

        public static Card SomeUnknownCard { get; } = new(SomeUnknownRank, Suit.Spades);

        public static IEnumerable<Card> RegularCardsOfSuit(Suit suit)
            => new Card[]
            {
                new(Rank.King, suit),
                new(Rank.Queen, suit),
                new(Rank.Ten, suit),
                new(Rank.Nine, suit),
                new(Rank.Eight, suit),
            };

        public static IEnumerable<Card> ExpectedPlayableCards(Card topPlayedCard)
            => new Regular(topPlayedCard).PlayableCards;

        public static IEnumerable<Card> ExpectedPlayableCards(string topPlayedCard)
            => ExpectedPlayableCards(Parsers.Fluent.Card.From(topPlayedCard));
    }
}
