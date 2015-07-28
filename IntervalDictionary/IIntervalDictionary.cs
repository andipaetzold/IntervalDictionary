namespace IntervalDictionary
{
    using System;
    using System.Collections.Generic;

    public interface IIntervalDictionary<TBound, TValue> : ICollection<IntervalValuePair<TBound, TValue>>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        ICollection<Interval<TBound>> Intervals { get; }
        ICollection<TValue> Values { get; }
        TValue this[IInterval<TBound> interval] { get; set; }
        TValue this[TBound key] { get; set; }

        void Add(IInterval<TBound> interval, TValue value);

        bool ContainsInterval(IInterval<TBound> interval);

        bool ContainsKey(TBound key);

        bool ContainsValue(TValue value);

        bool Remove(IInterval<TBound> interval);

        bool Remove(TBound key);

        TValue GetValue(IInterval<TBound> interval);

        TValue GetValue(TBound key);

        bool TryGetValue(IInterval<TBound> interval, out TValue value);

        bool TryGetValue(TBound key, out TValue value);
    }
}
