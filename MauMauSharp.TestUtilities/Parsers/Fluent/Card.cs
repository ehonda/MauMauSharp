using JetBrains.Annotations;
using MauMauSharp.TestUtilities.Parsers.Cards;
using Sprache;

namespace MauMauSharp.TestUtilities.Parsers.Fluent
{
    [PublicAPI]
    public static class Card
    {
        public static MauMauSharp.Cards.Card From(string card)
            => Grammar.Card().Parse(card);
    }
}
