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
    }
}
