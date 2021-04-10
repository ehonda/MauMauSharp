using System;
using System.Collections;
using System.Collections.Generic;

namespace CyclicEnumerators
{
    public class CyclicEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _base;

        public CyclicEnumerator(IEnumerator<T> @base) => _base = @base;

        // TODO: Reuse code from non generic version
        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_base.MoveNext() is false)
            {
                _base.Reset();
                // TODO: Throw if _base.MoveNext() returns false again?
                _base.MoveNext();
            }

            Current = _base.Current;
            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _base.Reset();
        }

        // CS8766 is wrong here - IEnumerator<T>.Current has [CanBeNull]
        /// <inheritdoc />
        public T? Current { get; private set; }

        /// <inheritdoc />
        object? IEnumerator.Current => Current;

        /// <inheritdoc />
        public void Dispose()
        {
            Console.WriteLine("Disposing cyclic enumerator.");
            _base.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class CyclicEnumerator : IEnumerator
    {
        private readonly IEnumerator _base;

        public CyclicEnumerator(IEnumerator @base) => _base = @base;

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_base.MoveNext() is false)
            {
                _base.Reset();
                // TODO: Throw if _base.MoveNext() returns false again?
                _base.MoveNext();
            }

            Current = _base.Current;
            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _base.Reset();
        }

        /// <inheritdoc />
        public object? Current { get; private set; }
    }
}
