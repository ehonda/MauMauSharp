using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;
using System.Collections.Immutable;

namespace MauMauSharp.TestUtilities.Mocks.Players
{
    [PublicAPI]
    public static class PlayerIOMocks
    {
        public static Mock<IPlayerIO> ChoosingCardToPlay(string card)
            => ChoosingCardToPlay(Parsers.Fluent.Card.From(card));

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
            => ChoosingCardToPlay((Card)null!);

        public static Mock<IPlayerIO> ShapeShiftingJackInto(Suit suit)
        {
            var playerIO = new Mock<IPlayerIO>();
            playerIO
                .Setup(p => p.NameSuitToShapeShiftJackInto())
                .Returns(suit);

            return playerIO;
        }
    }
}
