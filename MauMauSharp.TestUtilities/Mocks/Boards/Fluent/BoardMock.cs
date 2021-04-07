using MauMauSharp.Boards;
using MauMauSharp.Cards;
using Moq;
using System.Collections.Generic;

namespace MauMauSharp.TestUtilities.Mocks.Boards.Fluent
{
    public static class BoardMock
    {
        public static Mock<IBoard> WithTopPlayedCard(this Mock<IBoard> board, Card card)
        {
            board.Setup(b => b.TopPlayedCard()).Returns(card);
            return board;
        }

        public static Mock<IBoard> WithSupply(this Mock<IBoard> board, IEnumerable<Card> cards)
        {
            var supply = new Stack<Card>(cards);
            board.Setup(b => b.DrawCardFromSupply()).Returns(() => supply.Pop());
            return board;
        }
    }
}
