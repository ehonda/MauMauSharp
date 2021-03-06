using JetBrains.Annotations;
using MauMauSharp.Cards;
using MauMauSharp.Cards.Shufflers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MauMauSharp.TestUtilities.Mocks.Cards.Shufflers
{
    [PublicAPI]
    public static class ShufflerMocks
    {
        public static Mock<IShuffler> NonShuffling() => NonShuffling<Card>();

        public static Mock<IShuffler> NonShuffling<T>()
            => FromShuffleFunction<T>(elements => elements);

        public static Mock<IShuffler> Reversing() => Reversing<Card>();

        public static Mock<IShuffler> Reversing<T>()
            => FromShuffleFunction<T>(elements => elements.Reverse());

        private static Mock<IShuffler> FromShuffleFunction<T>
            (Func<IEnumerable<T>, IEnumerable<T>> shuffleFunction)
        {
            var mock = new Mock<IShuffler>();
            mock.Setup(shuffler => shuffler
                    .Shuffle(It.IsAny<IEnumerable<T>>()))
                .Returns(shuffleFunction);

            return mock;
        }
    }
}
