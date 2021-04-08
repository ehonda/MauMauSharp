using MauMauSharp.Games;
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
        public void The_Starting_Player_Can_Pass_Or_Play_A_Card_On_The_First_Turn()
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
                p => p.PassOrPlayCard(It.IsAny<GameState>()),
                Times.Once);
        }

        [Test]
        public void The_Starting_Player_Is_Passed_The_Current_BoardState_For_Their_Decision()
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
                p => p.PassOrPlayCard(new(new(Card.From("Kc"), 0))),
                Times.Once);
        }
    }
}
