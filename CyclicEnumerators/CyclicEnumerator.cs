using System;
using System.Collections;
using System.Collections.Generic;

namespace CyclicEnumerators
{
    public class CyclicEnumerator<T> : IEnumerator<T>
    {
        private readonly Func<IEnumerator<T>> _baseGenerator;
        private IEnumerator<T> _base;

        public CyclicEnumerator(Func<IEnumerator<T>> baseGenerator)
        {
            _baseGenerator = baseGenerator;
            _base = _baseGenerator();
        }

        // TODO: Reuse code from non generic version
        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_base.MoveNext() is false)
            {
                _base = _baseGenerator();
                // TODO: Throw if _base.MoveNext() returns false again?
                _base.MoveNext();
            }

            Current = _base.Current;
            return true;
        }

        // TODO: This should not be implemented according to C# standard
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
        private readonly Func<IEnumerator> _baseGenerator;
        private IEnumerator _base;

        public CyclicEnumerator(Func<IEnumerator> baseGenerator)
        {
            _baseGenerator = baseGenerator;
            _base = _baseGenerator();
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_base.MoveNext() is false)
            {
                // TODO: Can't use this method, it is unsupported!
                _base = _baseGenerator();
                // TODO: Throw if _base.MoveNext() returns false again?
                _base.MoveNext();
            }

            Current = _base.Current;
            return true;
        }

        // TODO: This should not be implemented according to C# standard
        /// <inheritdoc />
        public void Reset()
        {
            _base.Reset();
        }

        /// <inheritdoc />
        public object? Current { get; private set; }
    }
}
