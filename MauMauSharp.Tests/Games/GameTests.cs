using MauMauSharp.Games;
using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Mocks.Boards;
using MauMauSharp.TestUtilities.Mocks.Players;
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
            var player = PlayerMocks.PlayingCard(Card.From("Qc"));

            var game = new Game(
                BoardMocks
                    .WithTopPlayedCard(Card.From("Kc"))
                    .Object,
                new[]
                {
                    player.Object
                });

            game.NextTurn();

            player.Verify(
                p => p.RequestCardToPlay(It.IsAny<GameState>()),
                Times.Once);
        }
    }
}
