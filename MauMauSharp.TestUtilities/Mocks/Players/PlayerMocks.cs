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
                .Setup(player => player.PassOrPlayCard(It.IsAny<GameState>()))
                .Returns(card);
            return mock;
        }

        public static Mock<IPlayer> PlayingCard(string card)
            => PlayingCard(Parsers.Fluent.Card.From(card));

        public static Mock<IPlayer> Passing()
            => PlayingCard((Card)null!);
    }
}
