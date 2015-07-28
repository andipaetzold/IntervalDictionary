namespace IntervalDictionary
{
    using System;

    public class Interval<TBound> : IInterval<TBound>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        public Interval(TBound lowerBound, TBound upperBound)
        {
            if (lowerBound == null)
            {
                throw new ArgumentNullException("lowerBound is null");
            }

            if (upperBound == null)
            {
                throw new ArgumentNullException("upperBound is null");
            }

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
            return LowerBound.CompareTo(bound) <= 0 && UpperBound.CompareTo(bound) >= 0;
        }

        public bool Intersects(IInterval<TBound> other)
        {
            return Contains(other.LowerBound) || other.Contains(LowerBound);
        }

        public int CompareTo(TBound other)
        {
            if (other.CompareTo(LowerBound) < 0)
            {
                return -1;
            }

            if (other.CompareTo(UpperBound) > 0)
            {
                return 1;
            }

            return 0;
        }

        public bool Equals(IInterval<TBound> other)
        {
            return LowerBound.Equals(other.LowerBound) && UpperBound.Equals(other.UpperBound);
        }
    }
}
