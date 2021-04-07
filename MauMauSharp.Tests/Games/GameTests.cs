using MauMauSharp.Boards;
using MauMauSharp.Games;
using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Mocks.Boards.Fluent;
using MauMauSharp.TestUtilities.Mocks.Cards.Shufflers;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using Moq;
using NUnit.Framework;

namespace MauMauSharp.Tests.Games
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void The_Starting_Player_Is_Requested_To_Play_A_Card_On_The_First_Turn()
        {
            var player = new Mock<IPlayer>();
            player
                .Setup(p => p.RequestCardToPlay(It.IsAny<GameState>()))
                .Returns(Card.From("Qc"));

            var game = new Game(
                new Mock<IBoard>()
                    .WithTopPlayedCard(Card.From("Kc"))
                    .Object,
                //// TODO: Provide BoardMock in a desired state in TestUtilities
                //new(
                //    Deck.TopDown(
                //        "Kc",
                //        "Kd"),
                //    ShufflerMocks.NonShuffling().Object),
                new[] { player.Object });

            game.NextTurn();

            player.Verify(
                p => p.RequestCardToPlay(It.IsAny<GameState>()),
                Times.Once);
        }
    }
}
