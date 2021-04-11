using MauMauSharp.Cards.Enums;
using MauMauSharp.TestUtilities.Data.TurnContexts;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using NUnit.Framework;
using System;
using Deck = MauMauSharp.Cards.Decks.Deck;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class RegularTests
    {
        [Test]
        public void NextTurnContext_Throws_ArgumentException_On_Unknown_Played_Card()
            => Assert.Catch<ArgumentException>(
                () => new Regular(Card
                    .From("8s"))
                    .NextTurnContext(
                        TurnContextsData.SomeUnknownCard,
                        PlayerMocks.Arbitrary().Object));

        [Test]
        public void One_Card_Is_To_Draw_On_A_Regular_Turn_Pass()
        {
            var regular = new Regular(Card.From("8s"));
            Assert.That(regular.CardsToDrawOnPass, Is.EqualTo(1));
        }

        [Test]
        public void If_A_Regular_Turn_Is_Passed_The_Next_Turn_Is_Regular_With_The_Same_Playable_Cards()
        {
            var first = new Regular(Card.From("8s"));
            var second = first.NextTurnContext(null, PlayerMocks.Arbitrary().Object);

            Assert.That(second, Is.TypeOf<Regular>());
            Assert.That(first.PlayableCards, Is.EqualTo(second.PlayableCards));
        }

        // TODO: Parameterize this test over all starting cards
        [TestCaseSource(
            typeof(TurnContextsData),
            nameof(TurnContextsData.RegularCardsOfSuit),
            new object[] { Suit.Spades })]
        public void Regular_Cards_Of_The_Same_Suit_Can_Be_Played_And_Lead_To_A_Regular_Next_Turn(
            MauMauSharp.Cards.Card cardToPlay)
        {
            var regular = new Regular(Card.From("8s"));
            var next = regular.NextTurnContext(cardToPlay, PlayerMocks.Arbitrary().Object);

            Assert.That(Deck.AllCardsOfSuit(Suit.Spades), Is.SubsetOf(next.PlayableCards));
            Assert.That(Deck.AllCardsOfRank(cardToPlay.Rank), Is.SubsetOf(next.PlayableCards));
            Assert.That(Deck.AllCardsOfRank(Rank.Jack), Is.SubsetOf(next.PlayableCards));
        }
    }
}
