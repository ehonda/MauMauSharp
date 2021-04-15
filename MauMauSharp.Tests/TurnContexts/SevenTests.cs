using MauMauSharp.TestUtilities.Data.TurnContexts;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class SevenTests
    {
        [Test]
        public void Seven_Construction_Throws_If_Constructed_From_A_Non_Seven()
            => Assert.Catch<ArgumentException>(() =>
            {
                _ = new Seven(Card.From("Td"));
            });

        [TestCaseSource(
            typeof(SevenData),
            nameof(SevenData.ConsecutiveSevensOneToCount),
            new object[] { 5 })]
        public void Two_N_Cards_Are_Drawn_On_Pass_After_N_Consecutive_Seven_Turns(
            IEnumerable<MauMauSharp.Cards.Card> sevens)
        {
            var sevensArray = sevens.ToImmutableArray();

            var nthTurn = sevensArray
                .Skip(1)
                .Aggregate(
                    new Seven(sevensArray.First()) as ITurnContext,
                    (turn, card) => turn.NextTurnContext(card, PlayerMocks.Arbitrary().Object));

            Assert.That(nthTurn.CardsToDrawOnPass, Is.EqualTo(2 * sevensArray.Count()));
        }
    }
}
