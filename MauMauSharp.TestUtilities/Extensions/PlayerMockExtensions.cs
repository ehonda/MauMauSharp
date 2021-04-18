using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Players;
using Moq;

namespace MauMauSharp.TestUtilities.Extensions
{
    [PublicAPI]
    public static class PlayerMockExtensions
    {
        public static void VerifyCardTakenOnce(this Mock<IPlayer> player, Card card)
        {
            player.Verify(p => p.TakeCard(card), Times.Once);
        }

        public static void VerifyCardTakenOnce(this Mock<IPlayer> player, string card)
            => player.VerifyCardTakenOnce(Parsers.Fluent.Card.From(card));
    }
}
