using System.Collections;
using System.Collections.Generic;

namespace CyclicEnumerators
{
    public class CyclicEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _base;

        public CyclicEnumerable(IEnumerable<T> @base) => _base = @base;

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
            => new CyclicEnumerator<T>(() => _base.GetEnumerator());

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CyclicEnumerable : IEnumerable
    {
        private readonly IEnumerable _base;

        public CyclicEnumerable(IEnumerable @base) => _base = @base;

        /// <inheritdoc />
        public IEnumerator GetEnumerator()
            => new CyclicEnumerator(() => _base.GetEnumerator());
    }
}
