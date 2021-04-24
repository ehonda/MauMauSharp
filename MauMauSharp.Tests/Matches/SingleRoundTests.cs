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
    }
}
