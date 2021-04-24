using MauMauSharp.Matches;
using MauMauSharp.TestUtilities.Extensions;
using MauMauSharp.TestUtilities.Mocks.Boards;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using NUnit.Framework;

namespace MauMauSharp.Tests.Matches
{
    [TestFixture]
    public class SingleRoundTests
    {
        [Test]
        public void Players_Draw_The_Specified_Amount_Of_Cards_At_The_Beginning_Of_A_SingleRound()
        {
            var playerA = PlayerMocks.WithInitialHandAndPlaySequence(
                Hand.Empty(), PlaySequence.None());
            var playerB = PlayerMocks.WithInitialHandAndPlaySequence(
                Hand.Empty(), PlaySequence.None());

            var board = BoardMocks
                .WithTopPlayedCardAndSupply(
                    "As",
                    Deck.TopDown(
                        "Ac",
                        "Ad",
                        "Ah"));

            _ = new SingleRound(
                board.Object,
                new [] { (playerA.Object, 1), (playerB.Object, 2) });

            playerA.VerifyCardTakenOnce("Ac");
            playerB.VerifyCardTakenOnce("Ad");
            playerB.VerifyCardTakenOnce("Ah");
        }

        [Test]
        public void Play_Returns_Players_In_The_Order_They_Finished_Playing_In()
        {
            var playerA = PlayerMocks.WithInitialHandAndPlaySequence(
                Hand.Empty(), PlaySequence.From("", "As", "Ad"));
            var playerB = PlayerMocks.WithInitialHandAndPlaySequence(
                Hand.Empty(), PlaySequence.From("8s"));
            var playerC = PlayerMocks.WithInitialHandAndPlaySequence(
                Hand.Empty(), PlaySequence.From("", ""));

            var board = BoardMocks
                .WithTopPlayedCardAndSupply(
                    "Ts",
                    Deck.TopDown(
                        "Ad",
                        "8s",
                        "9c",
                        "As",
                        "Tc"));

            var match = new SingleRound(
                board.Object,
                new[] { (playerA.Object, 1), (playerB.Object, 1), (playerC.Object, 1) });

            var players = match.Play();
            Assert.That(players, Is.EqualTo(new []
            {
                playerB.Object, playerA.Object, playerC.Object
            }));
        }
    }
}
