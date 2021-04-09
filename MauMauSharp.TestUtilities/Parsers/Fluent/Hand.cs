using JetBrains.Annotations;
using MauMauSharp.TestUtilities.Parsers.Cards;
using Sprache;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Fluent
{
    [PublicAPI]
    public static class Hand
    {
        public static IEnumerable<MauMauSharp.Cards.Card> From(string hand)
            => Grammar.Hand().Parse(hand);

        public static IEnumerable<MauMauSharp.Cards.Card> Empty()
            => Enumerable.Empty<MauMauSharp.Cards.Card>();
    }
}
