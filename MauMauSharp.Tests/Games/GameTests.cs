using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.TestUtilities.Data.TurnContexts;
using MauMauSharp.TestUtilities.Extensions;
using MauMauSharp.TestUtilities.Mocks.Boards;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Game = MauMauSharp.TestUtilities.Mocks.Fluent.Game;

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
                p => p.PassOrPlayCard(It.IsAny<GameState>()),
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

            player.VerifyCardTakenOnce("As");
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

            playerA.VerifyCardTakenOnce("As");
            playerB.VerifyCardTakenOnce("Qh");
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

            playerA.VerifyCardTakenOnce("As");
            playerB.VerifyCardTakenOnce("Qh");
            playerA.VerifyCardTakenOnce("7d");
        }

        [Test]
        public void The_Starting_Turn_Is_Regular()
        {
            var playerA = PlayerMocks.Passing();
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.TopDown(
                        "As",
                        "Qh",
                        "7d")),
                new[] { playerA });

            game.NextTurn();

            playerA.Verify(
                p => p.PassOrPlayCard(
                    It.Is<GameState>(gameState
                        => gameState.PlayableCards.SequenceEqual(
                            RegularData.ExpectedPlayableCards("Qc"), null))),
                Times.Once);
        }

        [Test]
        public void Playing_A_Non_Playable_Card_Throws()
        {
            var playerA = PlayerMocks.PlayingCard("8s");
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.Empty()),
                new[] { playerA });

            Assert.That(
                () => game.NextTurn(),
                Throws.TypeOf<InvalidOperationException>()
                    .And.Message.Contains("not playable").IgnoreCase);
        }

        [Test]
        public void Player_A_Plays_Seven_And_Player_B_Has_To_Draw_Two_Cards()
        {
            var playerA = PlayerMocks.PlayingCard("7c");
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

            playerB.VerifyCardTakenOnce("As");
            playerB.VerifyCardTakenOnce("Qh");
        }

        [Test]
        public void Player_A_Plays_An_Ace_And_Player_B_Has_To_Pass()
        {
            var playerA = PlayerMocks.PlayingCard("Ac");
            var playerB = PlayerMocks.Passing();
            var game = Game.FromMocks(
                BoardMocks.WithTopPlayedCardAndSupply(
                    "Qc",
                    Deck.TopDown(
                        "As")),
                new[] { playerA, playerB });

            game.NextTurn();
            game.NextTurn();

            playerB.Verify(
                p => p.TakeCard(It.IsAny<MauMauSharp.Cards.Card>()),
                Times.Never);
        }

        [Test]
        public void Player_A_Plays_Jack_And_Player_B_Plays_The_Named_Suit()
        {
            var playerA = PlayerMocks
                .PlayingCard("Jd")
                .ShapeShiftingJackInto(Suit.Hearts);

            var playerB = PlayerMocks.PlayingCard("8h");

            var board = BoardMocks.WithTopPlayedCardAndSupply(
                "Qc",
                Deck.TopDown(
                    "As"));

            var game = Game.FromMocks(
                board,
                new[] { playerA, playerB });

            game.NextTurn();
            game.NextTurn();

            Assert.That(board.Object.TopPlayedCard(), Is.EqualTo(Card.From("8h")));
        }

        [Test]
        public void Player_A_Gets_To_Name_Suit_And_Play_A_Card_On_An_Initial_Jack_On_The_Board()
        {
            var playerA = PlayerMocks
                .PlayingCard("8h")
                .ShapeShiftingJackInto(Suit.Hearts);

            var board = BoardMocks.WithTopPlayedCardAndSupply(
                "Jc",
                Deck.Empty());

            var game = Game.FromMocks(
                board,
                new[] { playerA });

            game.NextTurn();

            playerA.Verify(p => p.NameSuitToShapeShiftJackInto(), Times.Once);
            Assert.That(board.Object.TopPlayedCard(), Is.EqualTo(Card.From("8h")));
        }

        [Test]
        public void Player_A_Has_To_Pass_On_Initial_Ace_And_Player_B_Plays_A_Card()
        {
            var playerA = PlayerMocks.Passing();
            var playerB = PlayerMocks.PlayingCard("8c");

            var board = BoardMocks.WithTopPlayedCardAndSupply(
                "Ac",
                Deck.Empty());

            var game = Game.FromMocks(
                board,
                new[] { playerA, playerB });

            game.NextTurn();
            game.NextTurn();
            
            playerA.Verify(p => p.TakeCard(It.IsAny<MauMauSharp.Cards.Card>()), Times.Never);
            Assert.That(board.Object.TopPlayedCard(), Is.EqualTo(Card.From("8c")));
        }

        [Test]
        public void Player_A_Has_To_Draw_Two_Cards_On_Initial_Seven()
        {
            var playerA = PlayerMocks.Passing();

            var board = BoardMocks.WithTopPlayedCardAndSupply(
                "7c",
                Deck.TopDown(
                    "As",
                    "Ad"));

            var game = Game.FromMocks(
                board,
                new[] { playerA });

            game.NextTurn();

            playerA.VerifyCardTakenOnce("As");
            playerA.VerifyCardTakenOnce("Ad");
            Assert.That(board.Object.TopPlayedCard(), Is.EqualTo(Card.From("7c")));
        }
    }
}
