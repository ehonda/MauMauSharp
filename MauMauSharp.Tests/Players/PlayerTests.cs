using System;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;
using NUnit.Framework;
using System.Collections.Immutable;
using System.Linq;

using FCard = MauMauSharp.TestUtilities.Parsers.Fluent.Card;

namespace MauMauSharp.Tests.Players
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void If_A_Player_Passes_Null_Is_Returned()
        {
            // TODO: PlayerIO Mocks
            var playerIo = new Mock<IPlayerIO>();
            playerIo
                .Setup(p => p.ChooseCardToPlayOrPass(
                    It.IsAny<GameState>(),
                    It.IsAny<ImmutableArray<Card>>()))
                .Returns<Card?>(null);

            var player = new Player(playerIo.Object, Enumerable.Empty<Card>());

            // TODO: Arbitrary GameState
            Assert.That(player.PassOrPlayCard(new(new(new(Rank.King, Suit.Clubs), 0))), Is.Null);
        }

        [Test]
        public void If_A_Player_Chooses_To_Play_A_Card_That_Is_Not_In_Hand_An_Exception_Is_Thrown()
        {
            // TODO: PlayerIO Mocks
            var playerIo = new Mock<IPlayerIO>();
            playerIo
                .Setup(p => p.ChooseCardToPlayOrPass(
                    It.IsAny<GameState>(),
                    It.IsAny<ImmutableArray<Card>>()))
                .Returns(FCard.From("Qc"));

            var player = new Player(playerIo.Object, Enumerable.Empty<Card>());

            Assert.That(() => player.PassOrPlayCard(new(new(new(Rank.King, Suit.Clubs), 0))),
                Throws.TypeOf<InvalidOperationException>()
                    .And.Message.Contains("hand").IgnoreCase);
        }
    }
}
