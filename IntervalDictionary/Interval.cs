namespace IntervalDictionary
{
    using System;

    public class Interval<TBound> : IInterval<TBound>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        public Interval(TBound lowerBound, TBound upperBound)
        {
            // sort lower and upper bound
            if (lowerBound.CompareTo(upperBound) <= 0)
            {
                LowerBound = lowerBound;
                UpperBound = upperBound;
            }
            else
            {
                LowerBound = upperBound;
                UpperBound = lowerBound;
            }
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

        public int CompareTo(TBound other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IInterval<TBound> other)
        {
            throw new NotImplementedException();
        }
    }
}
