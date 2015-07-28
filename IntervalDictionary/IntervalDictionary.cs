namespace IntervalDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class IntervalDictionary<TBound, TValue> : IIntervalDictionary<TBound, TValue>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        public IEnumerator<IntervalValuePair<TBound, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IntervalValuePair<TBound, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IntervalValuePair<TBound, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IntervalValuePair<TBound, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IntervalValuePair<TBound, TValue> item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public ICollection<Interval<TBound>> Intervals { get; private set; }
        public ICollection<TValue> Values { get; private set; }

        TValue IIntervalDictionary<TBound, TValue>.this[IInterval<TBound> interval]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        TValue IIntervalDictionary<TBound, TValue>.this[TBound key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Add(IInterval<TBound> interval, TValue value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsInterval(IInterval<TBound> interval)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TBound key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IInterval<TBound> interval)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TBound key)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(IInterval<TBound> interval)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(TBound key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(IInterval<TBound> interval, out TValue value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TBound key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
