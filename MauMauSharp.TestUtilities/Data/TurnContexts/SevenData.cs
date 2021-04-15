using CyclicEnumerators;
using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace MauMauSharp.TestUtilities.Data.TurnContexts
{
    [PublicAPI]
    public static class SevenData
    {
        // TODO: Better name!
        public static IEnumerable<IEnumerable<Card>> ConsecutiveSevensOneToCount(int count)
            => Enumerable
                .Range(1, count)
                .Select(ConsecutiveSevens);

        private static IEnumerable<Card> ConsecutiveSevens(int count)
            => Enum
                .GetValues<Suit>()
                .Select(suit => new Card(Rank.Seven, suit))
                .Cycle()
                .Take(count);
    }
}
