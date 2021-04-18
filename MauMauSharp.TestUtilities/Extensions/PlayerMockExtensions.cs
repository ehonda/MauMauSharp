﻿using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
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

        public static Mock<IPlayer> ShapeShiftingJackInto(this Mock<IPlayer> player, Suit suit)
        {
            player
                .Setup(p => p.NameSuitToShapeShiftJackInto())
                .Returns(suit);
            return player;
        }
    }
}
