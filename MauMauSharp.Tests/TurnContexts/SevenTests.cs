using MauMauSharp.TestUtilities.Parsers.Fluent;
using MauMauSharp.TurnContexts;
using NUnit.Framework;
using System;

namespace MauMauSharp.Tests.TurnContexts
{
    [TestFixture]
    public class SevenTests
    {
        [Test]
        public void Seven_Construction_Throws_If_Constructed_From_A_Non_Seven()
            => Assert.Catch<ArgumentException>(() =>
            {
                _ = new Seven(Card.From("Td"));
            });
    }
}
