using MauMauSharp.TestUtilities.Mocks.Boards;
using MauMauSharp.TestUtilities.Mocks.Fluent;
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
            var player = PlayerMocks.PlayingCard("Qc");
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCard("Kc"),
                new[] { player });
            
            game.NextTurn();

            player.Verify(
                p => p.PassOrPlayCard(It.IsAny<MauMauSharp.Games.GameState>()),
                Times.Once);
        }

        [Test]
        public void The_Starting_Player_Is_Passed_The_Current_BoardState_For_Their_Decision()
        {
            var player = PlayerMocks.PlayingCard("Qc");
            var board = BoardMocks
                .WithTopPlayedCard("Kc");

            var game = Game.FromMocks(board, new[] { player });

            var stateBeforeTurn = game.GameState;
            game.NextTurn();

            player.Verify(
                p => p.PassOrPlayCard(stateBeforeTurn),
                Times.Once);
        }

        [Test]
        public void If_The_Starting_Player_Passes_They_Have_To_Draw_A_Card()
        {
            var player = PlayerMocks.Passing();
            var board = BoardMocks
                .WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.TopDown(
                        "As",
                        "Qh"));

            var game = Game.FromMocks(board, new[] { player });
            game.NextTurn();

            player.Verify(
                p => p.TakeCard(Card.From("As")),
                Times.Once);
        }

        [Test]
        public void Player_Two_Takes_A_Turn_After_The_Starting_Player()
        {
            var playerA = PlayerMocks.Passing();
            var playerB = PlayerMocks.Passing();
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.TopDown(
                        "As",
                        "Qh")),
                new[] { playerA, playerB });

            game.NextTurn();
            game.NextTurn();

            playerA.Verify(
                p => p.TakeCard(Card.From("As")),
                Times.Once);

            playerB.Verify(
                p => p.TakeCard(Card.From("Qh")),
                Times.Once);
        }

        [Test]
        public void The_Starting_Player_Takes_Another_Turn_After_All_Players_Have_Taken_A_Turn()
        {
            var playerA = PlayerMocks.Passing();
            var playerB = PlayerMocks.Passing();
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.TopDown(
                        "As",
                        "Qh",
                        "7d")),
                new[] { playerA, playerB });

            game.NextTurn();
            game.NextTurn();
            game.NextTurn();

            playerA.Verify(
                p => p.TakeCard(Card.From("As")),
                Times.Once);

            playerB.Verify(
                p => p.TakeCard(Card.From("Qh")),
                Times.Once);

            playerA.Verify(
                p => p.TakeCard(Card.From("7d")),
                Times.Once);
        }
    }
}
