using MauMauSharp.Cards.Enums;
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
    }
}
