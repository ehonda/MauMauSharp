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
            var ace = new Ace();
            Assert.That(ace.CardsToDrawOnPass, Is.EqualTo(0));
        }

        [Test]
        public void No_Cards_Are_Playable_On_An_Ace_Turn()
        {
            var ace = new Ace();
            Assert.That(ace.PlayableCards, Is.Empty);
        }
    }
}
