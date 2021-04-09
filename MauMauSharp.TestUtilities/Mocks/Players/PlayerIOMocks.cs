using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;
using System.Collections.Immutable;

namespace MauMauSharp.TestUtilities.Mocks.Players
{
    [PublicAPI]
    public static class PlayerIOMocks
    {
        public static Mock<IPlayerIO> ChoosingCardToPlay(Card card)
        {
            var playerIO = new Mock<IPlayerIO>();
            playerIO
                .Setup(p => p.ChooseCardToPlayOrPass(
                    It.IsAny<GameState>(),
                    It.IsAny<ImmutableArray<Card>>()))
                .Returns(card);

            return playerIO;
        }

        public static Mock<IPlayerIO> Passing()
            => ChoosingCardToPlay(null!);
    }
}
