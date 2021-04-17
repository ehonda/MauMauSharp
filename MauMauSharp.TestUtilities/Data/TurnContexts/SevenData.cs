using CyclicEnumerators;
using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TurnContexts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace MauMauSharp.TestUtilities.Data.TurnContexts
{
    [PublicAPI]
    public static class SevenData
    {
        public static IEnumerable<Card> AllSevens()
            => Enum
                .GetValues<Suit>()
                .Select(suit => new Card(Rank.Seven, suit));

        // TODO: Better name!
        public static IEnumerable<ITurnContext> NthConsecutiveSevenTurnOneToCount(int count)
            => Enumerable
                .Range(1, count)
                .Select(NthConsecutiveSevenTurn);

        public static ITurnContext NthConsecutiveSevenTurn(int count)
        {
            var sevens = ConsecutiveSevens(count).ToImmutableArray();
            return sevens
                .Skip(1)
                .Aggregate(
                    new Seven(sevens.First()) as ITurnContext,
                    (turn, card) => turn.NextTurnContext(card, PlayerMocks.Arbitrary().Object));
        }

        // TODO: Better name!
        public static IEnumerable<IEnumerable<Card>> ConsecutiveSevensOneToCount(int count)
            => Enumerable
                .Range(1, count)
                .Select(ConsecutiveSevens);

        private static IEnumerable<Card> ConsecutiveSevens(int count)
            => AllSevens()
                .Cycle()
                .Take(count);
    }
}
