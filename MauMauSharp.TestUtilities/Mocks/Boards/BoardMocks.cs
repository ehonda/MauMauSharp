using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MauMauSharp.Boards;
using MauMauSharp.Cards;
using Moq;

namespace MauMauSharp.TestUtilities.Mocks.Boards
{
    [PublicAPI]
    public static class BoardMocks
    {
        public static Mock<IBoard> WithPlayedAndSupply(
            IEnumerable<Card> played, IEnumerable<Card> supply)
        {
            var playedStack = new Stack<Card>(played);
            var supplyStack = new Stack<Card>(supply);
            var mock = new Mock<IBoard>();

            mock
                .Setup(m => m.TopPlayedCard())
                .Returns(() => playedStack.Peek());

            mock
                .Setup(m => m.PlayCard(It.IsAny<Card>()))
                .Callback<Card>(card => playedStack.Push(card));

            mock
                .Setup(m => m.DrawCardFromSupply())
                .Returns(() => supplyStack.Pop());

            return mock;
        }

        public static Mock<IBoard> WithPlayed(IEnumerable<Card> played)
            => WithPlayedAndSupply(played, Enumerable.Empty<Card>());

        public static Mock<IBoard> WithTopPlayedCard(Card card)
            => WithPlayed(new[] { card });

        // TODO: WithSupply? Do we want to allow empty top?
    }
}
