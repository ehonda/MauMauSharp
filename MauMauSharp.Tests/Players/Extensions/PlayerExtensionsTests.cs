using MauMauSharp.Players.Extensions;
using MauMauSharp.TestUtilities.Mocks.Boards;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using Moq;
using NUnit.Framework;

namespace MauMauSharp.Tests.Players.Extensions
{
    [TestFixture]
    public class PlayerExtensionsTests
    {
        [Test]
        public void Taking_N_Cards_Draws_N_Times_From_The_Supply()
        {
            var player = PlayerMocks.Arbitrary();
            var board = BoardMocks.WithTopPlayedCardAndSupply(
                Card.From("Qc"),
                Deck.TopDown(
                    "As",
                    "Ad",
                    "Ah"));

            player.Object.TakeNCardsFrom(board.Object, 3);

            player.Verify(
                p => p.TakeCard(Card.From("As")),
                Times.Once);

            player.Verify(
                p => p.TakeCard(Card.From("Ad")),
                Times.Once);

            player.Verify(
                p => p.TakeCard(Card.From("Ah")),
                Times.Once);
        }
    }
}
