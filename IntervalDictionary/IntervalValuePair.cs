namespace IntervalDictionary
{
    using System;

    public struct IntervalValuePair<TBound, TValue>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        public IntervalValuePair(IInterval<TBound> interval, TValue value)
            : this()
        {
            Interval = interval;
            Value = value;
        }

        public IInterval<TBound> Interval { get; private set; }
        public TValue Value { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Interval, Value);
        }
    }
}
