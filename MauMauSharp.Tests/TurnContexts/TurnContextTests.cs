using MauMauSharp.Cards.Enums;
using MauMauSharp.TestUtilities.Data.TurnContexts;
using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using Moq;
using NUnit.Framework;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class TurnContextTests
    {

        [Test]
        public void FromInitialTopPlayedCard_With_Jack_Lets_Player_ShapeShift_Jack_Into_A_Regular_Turn()
        {
            var player = PlayerMocks.ShapeShiftingJackInto(Suit.Hearts);
            var turn = TurnContext.FromInitialTopPlayedCard(
                Card.From("Jc"),
                player.Object);

            Assert.That(turn, Is.TypeOf<Regular>());
            player.Verify(p => p.NameSuitToShapeShiftJackInto(), Times.Once);
        }

        [Test]
        public void FromInitialTopPlayedCard_With_Ace_Returns_Ace_Turn()
        {
            var player = PlayerMocks.Arbitrary();
            var turn = TurnContext.FromInitialTopPlayedCard(
                Card.From("Ac"),
                player.Object);

            Assert.That(turn, Is.TypeOf<Ace>());
        }

        [Test]
        public void FromInitialTopPlayedCard_With_Seven_Returns_Seven_Turn()
        {
            var player = PlayerMocks.Arbitrary();
            var turn = TurnContext.FromInitialTopPlayedCard(
                Card.From("7c"),
                player.Object);

            Assert.That(turn, Is.TypeOf<Seven>());
        }

        [TestCaseSource(typeof(RegularData), nameof(RegularData.AllRegularCards))]
        public void FromInitialTopPlayedCard_With_Regular_Card_Returns_Regular_Turn(
            MauMauSharp.Cards.Card card)
        {
            var player = PlayerMocks.Arbitrary();
            var turn = TurnContext.FromInitialTopPlayedCard(
                card,
                player.Object);

            Assert.That(turn, Is.TypeOf<Regular>());
        }
    }
}
