using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;

namespace MauMauSharp.TestUtilities.Extensions
{
    [PublicAPI]
    public static class PlayerMockExtensions
    {
        public static void VerifyPlayedOnTopCardOnce(this Mock<IPlayer> player, Card topPlayedCard)
        {
            player.Verify(p => p.PassOrPlayCard(It.Is<GameState>(
                g => g.BoardState.TopPlayedCard == topPlayedCard)), Times.Once);
        }

        public static void VerifyPlayedOnTopCardOnce(this Mock<IPlayer> player, string topPlayedCard)
            => player.VerifyPlayedOnTopCardOnce(Parsers.Fluent.Card.From(topPlayedCard));

        public static void VerifyCardTakenOnce(this Mock<IPlayer> player, Card card)
        {
            player.Verify(p => p.TakeCard(card), Times.Once);
        }

        public static void VerifyCardTakenOnce(this Mock<IPlayer> player, string card)
            => player.VerifyCardTakenOnce(Parsers.Fluent.Card.From(card));

        public static Mock<IPlayer> ShapeShiftingJackInto(this Mock<IPlayer> player, Suit suit)
        {
            player
                .Setup(p => p.NameSuitToShapeShiftJackInto())
                .Returns(suit);
            return player;
        }
    }
}
