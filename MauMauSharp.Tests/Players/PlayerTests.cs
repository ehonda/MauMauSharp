using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Data.Games;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using NUnit.Framework;
using System;

namespace MauMauSharp.Tests.Players
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void If_A_Player_Passes_Null_Is_Returned()
        {
            var player = new Player(
                PlayerIOMocks.Passing().Object,
                Hand.Empty());

            Assert.That(
                player.PassOrPlayCard(GameStateData.WithArbitraryValues()),
                Is.Null);
        }

        [Test]
        public void If_A_Player_Chooses_To_Play_A_Card_That_Is_Not_In_Hand_An_Exception_Is_Thrown()
        {
            var player = new Player(
                PlayerIOMocks.ChoosingCardToPlay("Qc").Object,
                Hand.Empty());

            Assert.That(
                () => player.PassOrPlayCard(GameStateData.WithArbitraryValues()),
                Throws.TypeOf<InvalidOperationException>()
                    .And.Message.Contains("hand").IgnoreCase);
        }

        [Test]
        public void If_A_Player_Chooses_To_Play_A_Card_From_Hand_It_Is_Returned_And_Removed_From_Hand()
        {
            var player = new Player(
                PlayerIOMocks.ChoosingCardToPlay("Qc").Object,
                Hand.From("Qc Kc"));

            var card = player.PassOrPlayCard(GameStateData.WithArbitraryValues());

            Assert.That(card, Is.EqualTo(Card.From("Qc")));
            
            Assert.That(player.Hand, Has.Length.EqualTo(1));
            Assert.That(player.Hand, Does.Contain(Card.From("Kc")));
            Assert.That(player.Hand, Does.Not.Contain(Card.From("Qc")));
        }

        [Test]
        public void Taking_A_Card_Adds_That_Card_To_The_Players_Hand()
        {
            var player = new Player(
                PlayerIOMocks.Passing().Object,
                Hand.Empty());

            player.TakeCard(Card.From("Qc"));

            Assert.That(player.Hand, Has.Length.EqualTo(1));
            Assert.That(player.Hand, Does.Contain(Card.From("Qc")));
        }
    }
}
