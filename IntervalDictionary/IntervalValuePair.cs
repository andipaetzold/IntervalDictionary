namespace Paetzold.Collections.IntervalDictionary
{
    using System;

    /// <summary>
    ///     Defines an interval/value pair that can be set or retrieved.
    /// </summary>
    /// <typeparam name="TBound">The type of the bounds.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public struct IntervalValuePair<TBound, TValue>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IntervalValuePair{TBound,TValue}" /> structure with the specified
        ///     interval and value.
        /// </summary>
        /// <param name="interval">The object defined in each interval/value pair.</param>
        /// <param name="value">The definition associated with interval.</param>
        public IntervalValuePair(IInterval<TBound> interval, TValue value)
            : this()
        {
            Interval = interval;
            Value = value;
        }

        /// <summary>
        ///     Gets the interval in the interval/value pair.
        /// </summary>
        public IInterval<TBound> Interval { get; }

        /// <summary>
        ///     Gets the value in the interval/value pair.
        /// </summary>
        public TValue Value { get; }

        /// <summary>
        ///     Returns a string representation of the <see cref="IntervalValuePair{TKey,TValue}" />, using the string
        ///     representations of the interval and value.
        /// </summary>
        /// <returns>
        ///     A string representation of the <see cref="IntervalValuePair{TKey,TValue}" />, which includes the string
        ///     representations of the interval and value.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString() => $"{Interval}: {Value}";
    }
}
