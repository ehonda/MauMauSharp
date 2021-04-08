using MauMauSharp.Boards;
using MauMauSharp.TestUtilities.Mocks.Cards.Shufflers;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using NUnit.Framework;

namespace MauMauSharp.Tests.Boards
{
    [TestFixture]
    public class BoardTests
    {
        // TODO: Probabilistic tests, see explanation:
        //          We should replace these tests that care about shuffling by
        //          probabilistic tests, because we want to view Board as a black box.
        //          Right now, we require the shuffle method to be called a specific
        //          number of times, but we shouldn't care about that from the outside.
        //          To be independent of the implementation, all we want to test
        //          is that from the outside, we can observe the cards have been shuffled
        //          (at least once) when we expect them to be - and for that,
        //          we need probabilistic tests.

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

            Assert.That(
                board.DrawCardFromSupply(),
                Is
                    .EqualTo(Card.From("Kc"))
                    .Or.EqualTo(Card.From("Kd"))
                    .Or.EqualTo(Card.From("Qh")));
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

        // TODO: This test could be more exhaustive:
        //          - Check that BoardState first component is TopPlayedCard()
        //          - Check that expected supply number matches for various supply pile sizes
        [Test]
        public void The_Correct_BoardState_Is_Returned()
        {
            var board = new Board(
                Deck.TopDown(
                    "Kc"),
                ShufflerMocks.Reversing().Object);

            Assert.That(board.GetState(), Is.EqualTo(new BoardState(Card.From("Kc"), 0)));
        }
    }
}
