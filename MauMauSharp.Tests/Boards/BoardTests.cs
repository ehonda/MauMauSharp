using MauMauSharp.Boards;
using MauMauSharp.TestUtilities.Mocks.Cards.Shufflers;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using NUnit.Framework;

namespace MauMauSharp.Tests.Boards
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void Cards_Are_Shuffled_And_The_Top_Card_Is_Revealed_On_A_Fresh_Board()
        {
            var board = new Board(
                Deck.TopDown(
                    "Kc",
                    "Kd"),
                ShufflerMocks.Reversing().Object);

            Assert.That(board.TopPlayedCard(), Is.EqualTo(Card.From("Kd")));
        }

        [Test]
        public void A_Card_Can_Be_Played_To_And_Will_Then_Be_The_TopPlayedCard()
        {
            var board = new Board(
                Deck.TopDown(
                    "Kc",
                    "Kd"),
                ShufflerMocks.NonShuffling().Object);

            board.PlayCard(Card.From("Qh"));

            Assert.That(board.TopPlayedCard(), Is.EqualTo(Card.From("Qh")));
        }

        [Test]
        public void The_Top_Card_Of_The_Supply_Can_Be_Drawn()
        {
            var board = new Board(
                Deck.TopDown(
                    "Kc",
                    "Kd",
                    "Qh"),
                ShufflerMocks.NonShuffling().Object);

            Assert.That(board.DrawCardFromSupply(), Is.EqualTo(Card.From("Kd")));
        }

        [Test]
        public void If_A_Card_Is_Drawn_From_An_Empty_Supply_It_Will_Be_Replenished_From_The_Shuffled_Played_Tail()
        {
            var board = new Board(
                Deck.TopDown(
                    "Kc"),
                ShufflerMocks.Reversing().Object);

            board.PlayCard(Card.From("Qh"));
            board.PlayCard(Card.From("Ts"));

            var drawnCard = board.DrawCardFromSupply();

            Assert.That(board.TopPlayedCard(), Is.EqualTo(Card.From("Ts")));
            Assert.That(drawnCard, Is.EqualTo(Card.From("Qh")));
        }
    }
}
