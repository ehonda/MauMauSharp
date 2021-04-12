using CyclicEnumerators;
using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Data.TurnContexts
{
    [PublicAPI]
    public static class SevenData
    {
        public static IEnumerable<Card> ConsecutiveSevens(int count)
            => Enum
                .GetValues<Suit>()
                .Select(suit => new Card(Rank.Seven, suit))
                .Cycle()
                .Take(count);
    }
}
