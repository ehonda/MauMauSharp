using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Enums;
using MauMauSharp.Games;
using MauMauSharp.Players;
using MauMauSharp.TestUtilities.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MauMauSharp.TestUtilities.Mocks.Players
{
    [PublicAPI]
    public static class PlayerMocks
    {
        public static Mock<IPlayer> WithInitialHandAndPlaySequence(
            IEnumerable<Card> hand,
            IEnumerable<Card?> playSequence)
        {
            var mock = new Mock<IPlayer>();
            var handList = hand.ToList();

            mock
                .Setup(player => player.Hand)
                .Returns(() => handList.ToImmutableArray());

            mock
                .Setup(player => player.TakeCard(It.IsAny<Card>()))
                .Callback<Card>(card => handList.Add(card));
            
            // TODO: Is the warning about never disposing enumerator a false positive?
            var playSequenceEnumerator = playSequence.GetEnumerator();
            mock
                .Setup(player => player.PassOrPlayCard(It.IsAny<GameState>()))
                .Returns(() =>
                {
                    if (playSequenceEnumerator.MoveNext() is false)
                        throw new InvalidOperationException("Play sequence was exhausted.");

                    var cardToPlay = playSequenceEnumerator.Current;

                    if (cardToPlay is not null && handList.Contains(cardToPlay) is false)
                        throw new InvalidOperationException(
                            $"Card in play sequence is not in hand: {cardToPlay}");

                    if (cardToPlay is not null)
                        handList.Remove(cardToPlay);

                    return cardToPlay;
                });

            return mock;
        }

        public static Mock<IPlayer> PlayingCard(Card card)
        {
            var mock = WithArbitraryNonEmptyHand();
            mock
                .Setup(player => player.PassOrPlayCard(It.IsAny<GameState>()))
                .Returns(card);
            return mock;
        }

        public static Mock<IPlayer> PlayingCard(string card)
            => PlayingCard(Parsers.Fluent.Card.From(card));

        public static Mock<IPlayer> Passing()
            => PlayingCard((Card)null!);

        public static Mock<IPlayer> Arbitrary() => WithArbitraryNonEmptyHand();

        public static Mock<IPlayer> ShapeShiftingJackInto(Suit suit)
            => WithArbitraryNonEmptyHand().ShapeShiftingJackInto(suit);

        public static Mock<IPlayer> WithArbitraryNonEmptyHand()
        {
            var mock = new Mock<IPlayer>();
            mock
                .Setup(player => player.Hand)
                .Returns(ImmutableArray.Create(Parsers.Fluent.Card.From("8s")));
            return mock;
        }
    }
}
