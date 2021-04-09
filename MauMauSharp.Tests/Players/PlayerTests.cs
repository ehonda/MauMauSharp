using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Data.Games;
using MauMauSharp.TestUtilities.Mocks.Players;
using NUnit.Framework;
using System;
using System.Linq;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using Card = MauMauSharp.Cards.Card;

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
                Deck.Empty());

            Assert.That(
                player.PassOrPlayCard(GameStateData.WithArbitraryValues()),
                Is.Null);
        }

        [Test]
        public void If_A_Player_Chooses_To_Play_A_Card_That_Is_Not_In_Hand_An_Exception_Is_Thrown()
        {
            var player = new Player(
                PlayerIOMocks.ChoosingCardToPlay("Qc").Object,
                Deck.Empty());

            Assert.That(
                () => player.PassOrPlayCard(GameStateData.WithArbitraryValues()),
                Throws.TypeOf<InvalidOperationException>()
                    .And.Message.Contains("hand").IgnoreCase);
        }
    }
}
