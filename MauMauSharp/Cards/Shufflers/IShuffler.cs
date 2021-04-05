using System.Collections.Generic;

namespace MauMauSharp.Cards.Shufflers
{
    public interface IShuffler
    {
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> elements);
    }
}
