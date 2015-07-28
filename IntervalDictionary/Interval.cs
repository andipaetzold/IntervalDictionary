namespace IntervalDictionary
{
    using System;

    public class Interval<TBound> : IInterval<TBound>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        public Interval()
        {
            throw new NotImplementedException();
        }

        public Interval(TBound lowerBound, TBound upperBound)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TBound other)
        {
            throw new NotImplementedException();
        }

        public TBound LowerBound { get; set; }
        public TBound UpperBound { get; set; }

        public bool Contains(TBound bound)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }

        public IInterval<TBound> Intersect(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }

        public IInterval<TBound> Union(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }

        public IInterval<TBound> Subtract(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }
    }
}
