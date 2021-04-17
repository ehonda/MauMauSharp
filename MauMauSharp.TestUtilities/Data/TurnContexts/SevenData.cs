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
        // Example return value (S is one consecutive 7-turn, S S is 2 etc):
        // [ S, S S, S S S ]
        public static IEnumerable<ITurnContext> NthConsecutiveSevenTurnOneToCount(int count)
            => ConsecutiveSevensOneToCount(count)
                .Select(ToNthConsecutiveSevenTurn);

        // Example return value:
        // S S S
        public static ITurnContext NthConsecutiveSevenTurn(int count)
            => ToNthConsecutiveSevenTurn(ConsecutiveSevens(count));

        // TODO: Needed? If not, remove
        // Example conversion:
        // [ 7, 7, 7 ] -> [ S, S S, S S S ]
        public static IEnumerable<ITurnContext> ToSevenTurnSequence(IEnumerable<Card> sevens)
        {
            var sevensArray = sevens.ToImmutableArray();
            return Enumerable
                .Range(1, sevensArray.Length)
                .Select(count => sevensArray.Take(count))
                .Select(ToNthConsecutiveSevenTurn);
        }

        // Example conversion:
        // [ 7, 7, 7 ] -> S S S
        public static ITurnContext ToNthConsecutiveSevenTurn(IEnumerable<Card> sevens)
        {
            var sevensArray = sevens.ToImmutableArray();
            return sevensArray
                .Skip(1)
                .Aggregate(
                    new Seven(sevensArray.First()) as ITurnContext,
                    (turn, card) => turn.NextTurnContext(card, PlayerMocks.Arbitrary().Object));
        }

        // TODO: Better name!
        // Example return value:
        // [ [ 7 ], [ 7, 7 ], [ 7, 7, 7 ] ]
        public static IEnumerable<IEnumerable<Card>> ConsecutiveSevensOneToCount(int count)
            => Enumerable
                .Range(1, count)
                .Select(ConsecutiveSevens);

        // Example return value:
        // [ 7, 7, 7, 7 ]
        private static IEnumerable<Card> ConsecutiveSevens(int count)
            => AllSevens()
                .Cycle()
                .Take(count);
    }
}
