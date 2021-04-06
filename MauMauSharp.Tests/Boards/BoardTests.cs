using MauMauSharp.Boards;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.TestUtilities.Mocks.Cards.Shufflers;
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
                // TODO: Parser for easy creation
                new Card[]
                {
                    new(Rank.King, Suit.Clubs),
                    new(Rank.King, Suit.Diamonds)
                },
                ShufflerMocks.Reversing().Object);

            Assert.That(board.TopPlayedCard(), Is.EqualTo(new Card(Rank.King, Suit.Clubs)));
        }
    }
}
