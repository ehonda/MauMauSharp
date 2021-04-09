using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Mocks.Players;
using NUnit.Framework;
using System;
using System.Linq;

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
                Enumerable.Empty<Card>());

            // TODO: Arbitrary GameState
            Assert.That(player.PassOrPlayCard(new(new(new(Rank.King, Suit.Clubs), 0))), Is.Null);
        }

        [Test]
        public void If_A_Player_Chooses_To_Play_A_Card_That_Is_Not_In_Hand_An_Exception_Is_Thrown()
        {
            var player = new Player(
                PlayerIOMocks.ChoosingCardToPlay("Qc").Object,
                Enumerable.Empty<Card>());

            Assert.That(() => player.PassOrPlayCard(new(new(new(Rank.King, Suit.Clubs), 0))),
                Throws.TypeOf<InvalidOperationException>()
                    .And.Message.Contains("hand").IgnoreCase);
        }
    }
}
