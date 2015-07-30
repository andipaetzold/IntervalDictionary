namespace Paetzold.Collections.IntervalDictionary
{
    using System;

    /// <summary>
    ///     Represents an interval between two bounds.
    /// </summary>
    /// <typeparam name="TBound">The type of the bounds.</typeparam>
    public class Interval<TBound> : IInterval<TBound>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Interval{TBound}" /> class with a lower and an upper bound.
        /// </summary>
        /// <param name="lowerBound">The initial lower bound of the interval.</param>
        /// <param name="upperBound">The initial upper bound of the interval.</param>
        /// <exception cref="ArgumentNullException">Lower or upper bound is null.</exception>
        public Interval(TBound lowerBound, TBound upperBound)
        {
            if (lowerBound == null)
            {
                throw new ArgumentNullException("lowerBound", "lowerBound is null");
            }

            if (upperBound == null)
            {
                throw new ArgumentNullException("upperBound", "upperBound is null");
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

        /// <summary>
        ///     Gets or sets the lower bound of the interval.
        /// </summary>
        public TBound LowerBound { get; set; }

        /// <summary>
        ///     Gets or sets the upper bound of the interval.
        /// </summary>
        public TBound UpperBound { get; set; }

        /// <summary>
        ///     Determines whether <paramref name="key" /> is between <see cref="LowerBound" /> and <see cref="UpperBound" /> of
        ///     the interval.
        /// </summary>
        /// <param name="key">
        ///     The key to check the interval for.
        /// </param>
        /// <returns>
        ///     true if key is between <see cref="LowerBound" /> and <see cref="UpperBound" />; otherwise, false.
        /// </returns>
        public bool Contains(TBound key)
        {
            return LowerBound.CompareTo(key) <= 0 && UpperBound.CompareTo(key) >= 0;
        }

        /// <summary>
        ///     Determines whether the interval intersects with an other interval.
        /// </summary>
        /// <param name="other">
        ///     The interval to check for intersection with the current interval.
        /// </param>
        /// <returns>
        ///     true if the interval intersects with an other interval; otherwise, false.
        /// </returns>
        public bool Intersects(IInterval<TBound> other)
        {
            return Contains(other.LowerBound) || other.Contains(LowerBound);
        }

        public bool IsSubsetOf(IInterval<TBound> other)
        {
            return other.Contains(LowerBound) && other.Contains(UpperBound);
        }

        public bool IsSupersetOf(IInterval<TBound> other)
        {
            return Contains(other.LowerBound) && Contains(other.UpperBound);
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

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", LowerBound, UpperBound);
        }
    }
}
