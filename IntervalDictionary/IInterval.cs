namespace Paetzold.Collections.IntervalDictionary
{
    using System;

    /// <summary>
    ///     Represents an interval between two bounds.
    /// </summary>
    /// <typeparam name="TBound">The type of the bounds.</typeparam>
    public interface IInterval<TBound> : IComparable<TBound>, 
                                         IEquatable<IInterval<TBound>>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        /// <summary>
        ///     Gets or sets the lower bound of the interval.
        /// </summary>
        TBound LowerBound { get; set; }

        /// <summary>
        ///     Gets or sets the upper bound of the interval.
        /// </summary>
        TBound UpperBound { get; set; }

        /// <summary>
        ///     Determines whether <paramref name="key" /> is between <see cref="LowerBound" /> and <see cref="UpperBound" /> of
        ///     the
        ///     interval.
        /// </summary>
        /// <param name="key">
        ///     The key to check the interval for.
        /// </param>
        /// <returns>
        ///     true if key is between <see cref="LowerBound" /> and <see cref="UpperBound" />; otherwise, false.
        /// </returns>
        bool Contains(TBound key);

        /// <summary>
        ///     Determines whether the interval intersects with an other interval.
        /// </summary>
        /// <param name="other">
        ///     The interval to check for intersection with the current interval.
        /// </param>
        /// <returns>
        ///     true if the interval intersects with an other interval; otherwise, false.
        /// </returns>
        bool Intersects(IInterval<TBound> other);

        /// <summary>
        ///     Determines whether the interval is a subset of an other interval.
        /// </summary>
        /// <param name="other">The other interval.</param>
        /// <returns>true if the interval is a subset of an other interval; otherwise, false.</returns>
        bool IsSubsetOf(IInterval<TBound> other);

        /// <summary>
        ///     Determines whether the interval is a superset of an other interval.
        /// </summary>
        /// <param name="other">The other interval</param>
        /// <returns>true if the interval is a superset of an other interval; otherwise, false.</returns>
        bool IsSupersetOf(IInterval<TBound> other);
    }
}
