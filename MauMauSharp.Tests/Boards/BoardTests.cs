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
        public void Cards_Are_Shuffled_And_The_Top_Card_Revealed_On_A_Fresh_Board()
        {
            var board = new Board(
                Deck.FromStacked(
                    "Kc",
                    "Kd"),
                ShufflerMocks.Reversing().Object);

            Assert.That(board.TopPlayedCard(), Is.EqualTo(Card.From("Kc")));
        }
    }
}
