using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;

namespace MauMauSharp.TestUtilities.Mocks.Players
{
    [PublicAPI]
    public static class PlayerMocks
    {
        public static Mock<IPlayer> PlayingCard(Card card)
        {
            var mock = new Mock<IPlayer>();
            mock
                .Setup(player => player.RequestCardToPlay(It.IsAny<GameState>()))
                .Returns(card);
            return mock;
        }
    }
}
