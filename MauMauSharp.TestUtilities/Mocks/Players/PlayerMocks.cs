﻿using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Games;
using MauMauSharp.Players;
using Moq;

namespace MauMauSharp.TestUtilities.Mocks.Players
{
    [PublicAPI]
    public static class PlayerMocks
    {
        // TODO: Add and use convenience overload taking string
        public static Mock<IPlayer> PlayingCard(Card card)
        {
            var mock = new Mock<IPlayer>();
            mock
                .Setup(player => player.PassOrPlayCard(It.IsAny<GameState>()))
                .Returns(card);
            return mock;
        }
    }
}
