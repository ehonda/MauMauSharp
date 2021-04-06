using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.TestUtilities.Parsers.Cards;
using Sprache;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Fluent
{
    [PublicAPI]
    public static class Deck
    {
        public static IEnumerable<Card> FromStacked(params string[] cards)
            => cards.Select(card => Grammar.Card().Parse(card));
    }
}
