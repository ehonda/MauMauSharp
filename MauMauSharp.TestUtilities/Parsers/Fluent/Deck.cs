using JetBrains.Annotations;
using MauMauSharp.TestUtilities.Parsers.Cards;
using Sprache;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Fluent
{
    [PublicAPI]
    public static class Deck
    {
        public static IEnumerable<MauMauSharp.Cards.Card> BottomUp(params string[] cards)
            => cards.Select(card => Grammar.Card().Parse(card));

        public static IEnumerable<MauMauSharp.Cards.Card> TopDown(params string[] cards)
            => BottomUp(cards).Reverse();

        public static IEnumerable<MauMauSharp.Cards.Card> Empty()
            => Enumerable.Empty<MauMauSharp.Cards.Card>();
    }
}
