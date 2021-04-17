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
            nameof(SevenData.NthConsecutiveSevenTurnOneToCount),
            new object[] { 5 })]
        public void Only_Sevens_Can_Be_Played_On_A_Seven_Turn(ITurnContext turn)
        {
            Assert.That(turn, Is.TypeOf<Seven>());
            Assert.That(turn.PlayableCards, Is.EquivalentTo(SevenData.AllSevens()));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Two_N_Cards_Are_Drawn_On_Pass_After_N_Consecutive_Seven_Turns(int count)
        {
            var turn = SevenData.NthConsecutiveSevenTurn(count);

            Assert.That(turn, Is.TypeOf<Seven>());
            Assert.That(turn.CardsToDrawOnPass, Is.EqualTo(2 * count));
        }
    }
}
