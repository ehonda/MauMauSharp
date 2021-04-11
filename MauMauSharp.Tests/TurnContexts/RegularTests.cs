﻿using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using NUnit.Framework;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class RegularTests
    {
        [Test]
        public void One_Card_Is_To_Draw_On_A_Regular_Turn_Pass()
        {
            var regular = new Regular(Card.From("8s"));
            Assert.That(regular.CardsToDrawOnPass, Is.EqualTo(1));
        }

        [Test]
        public void If_A_Regular_Turn_Is_Passed_The_Next_Turn_Is_Regular_With_The_Same_Playable_Cards()
        {
            var first = new Regular(Card.From("8s"));
            var second = first.NextTurnContext(null, PlayerMocks.Arbitrary().Object);

            Assert.That(second, Is.TypeOf<Regular>());
            Assert.That(first.PlayableCards, Is.EqualTo(second.PlayableCards));
        }
    }
}
