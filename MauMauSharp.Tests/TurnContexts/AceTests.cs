using MauMauSharp.TestUtilities.Mocks.Players;
using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using NUnit.Framework;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class AceTests
    {
        [Test]
        public void Zero_Cards_Are_Drawn_On_An_Ace_Turn_Pass()
        {
            var ace = new Ace(Card.From("Ad"));
            Assert.That(ace.CardsToDrawOnPass, Is.EqualTo(0));
        }

        [Test]
        public void No_Cards_Are_Playable_On_An_Ace_Turn()
        {
            var ace = new Ace(Card.From("Ad"));
            Assert.That(ace.PlayableCards, Is.Empty);
        }

        // TODO: Parameterize over all aces
        [Test]
        public void The_Next_Turn_Is_Regular_From_The_Played_Ace_On_A_Pass()
        {
            var ace = new Ace(Card.From("Ad"));
            var next = ace.NextTurnContext(null, PlayerMocks.Arbitrary().Object);

            Assert.That(next, Is.TypeOf<Regular>());
            Assert.That(
                next.PlayableCards,
                Is.EquivalentTo(new Regular(Card.From("Ad")).PlayableCards));
        }
    }
}
