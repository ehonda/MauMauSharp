using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Parsers.Fluent
{
    [PublicAPI]
    public static class PlaySequence
    {
        public static IEnumerable<MauMauSharp.Cards.Card?> From(
            params string?[] passesOrPlays)
            => passesOrPlays
                .Select(passOrPlay => string.IsNullOrEmpty(passOrPlay)
                    ? null
                    : Card.From(passOrPlay));
    }
}
