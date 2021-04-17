using MauMauSharp.Cards.Enums;
using MauMauSharp.TestUtilities.Data.Cards;
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
            typeof(CardData),
            nameof(CardData.AllButRank),
            new object[] { Rank.Seven })]
        public void Seven_Next_Turn_Throws_On_All_Cards_That_Are_Not_Rank_Seven(
            MauMauSharp.Cards.Card card)
            => Assert.Catch<InvalidOperationException>(() =>
            {
                _ = new Seven(Card.From("7d"))
                    .NextTurnContext(card, PlayerMocks.Arbitrary().Object);
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

        [TestCaseSource(
            typeof(SevenData),
            nameof(SevenData.ConsecutiveSevensOneToCount),
            new object[] { 5 })]
        public void Next_Turn_Is_Regular_From_Top_Played_Card_On_A_Seven_Pass(
            IEnumerable<MauMauSharp.Cards.Card> sevens)
        {
            var sevensArray = sevens.ToImmutableArray();
            var nthTurn = SevenData.ToNthConsecutiveSevenTurn(sevensArray);

            var regular = nthTurn.NextTurnContext(null, PlayerMocks.Arbitrary().Object);

            Assert.That(regular, Is.TypeOf<Regular>());
            Assert.That(
                regular.PlayableCards, 
                Is.EquivalentTo(new Regular(sevensArray.Last()).PlayableCards));
        }
    }
}
