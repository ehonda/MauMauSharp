using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;
using NUnit.Framework;
using System.Collections.Immutable;
using System.Linq;

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
    }
}
