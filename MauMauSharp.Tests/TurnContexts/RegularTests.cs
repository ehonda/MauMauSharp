using MauMauSharp.Cards;
using MauMauSharp.TurnContexts;
using NUnit.Framework;
using System.Linq;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class RegularTests
    {
        [Test]
        public void One_Card_Is_To_Draw_On_A_Regular_Turn_Pass()
        {
            var regular = new Regular(Enumerable.Empty<Card>());
            Assert.That(regular.CardsToDrawOnPass, Is.EqualTo(1));
        }
    }
}
