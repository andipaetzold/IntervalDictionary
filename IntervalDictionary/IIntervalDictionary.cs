namespace IntervalDictionary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a generic collection of interval/value pairs.
    /// </summary>
    /// <typeparam name="TBound">The type of bounds of the intervals in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public interface IIntervalDictionary<TBound, TValue> : ICollection<IntervalValuePair<TBound, TValue>>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        /// <summary>
        ///     Gets and <see cref="ICollection{T}" /> containing the values in the
        ///     <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </summary>
        ICollection<IInterval<TBound>> Intervals { get; }

        /// <summary>
        ///     Gets and <see cref="ICollection{T}" /> containing the <see cref="IInterval{TBound}" /> in the
        ///     <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </summary>
        ICollection<TValue> Values { get; }

        /// <summary>
        ///     Gets or sets the value associated with the specified interval.
        /// </summary>
        /// <param name="interval">The interval whose value to get or set.</param>
        /// <returns>The value of the element with the specified interval.</returns>
        TValue this[IInterval<TBound> interval] { get; set; }

        /// <summary>
        ///     Gets or sets the value associated with the specified interval that contains the specified key.
        /// </summary>
        /// <param name="key">The key of the interval whose value to get or set.</param>
        /// <returns>The value of the element with the interval that contains the specified key.</returns>
        TValue this[TBound key] { get; set; }

        /// <summary>
        ///     Adds an element with the provided interval and value to the <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </summary>
        /// <param name="interval">The object to use as the interval of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        void Add(IInterval<TBound> interval, TValue value);

        /// <summary>
        ///     Determines whether the <see cref="IIntervalDictionary{TBound,TValue}" /> contains an element with the specified
        ///     interval.
        /// </summary>
        /// <param name="interval">The interval to locate in the <see cref="IIntervalDictionary{TBound,TValue}" />.</param>
        /// <returns>true if the interval is found in the <see cref="IIntervalDictionary{TBound,TValue}" />; otherwise, false.</returns>
        bool ContainsInterval(IInterval<TBound> interval);

        /// <summary>
        ///     Determines whether the <see cref="IIntervalDictionary{TBound,TValue}" /> contains an element with an interval that
        ///     contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="IIntervalDictionary{TBound,TValue}" />.</param>
        /// <returns>true if the key is found in the <see cref="IIntervalDictionary{TBound,TValue}" />; otherwise, false.</returns>
        bool ContainsKey(TBound key);

        /// <summary>
        ///     Determines whether the <see cref="IIntervalDictionary{TBound,TValue}" /> contains an element with the specified
        ///     value.
        /// </summary>
        /// <param name="value">The value to locate in the <see cref="IIntervalDictionary{TBound,TValue}" />.</param>
        /// <returns>true if the value is found in the <see cref="IIntervalDictionary{TBound,TValue}" />; otherwise, false.</returns>
        bool ContainsValue(TValue value);

        /// <summary>
        ///     Removes the element with the specified interval from the <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </summary>
        /// <param name="interval">The interval of the element to remove.</param>
        /// <returns>
        ///     true if the element is successfully removed; otherwise, false. This method also returns false if interval was
        ///     not found in the original <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </returns>
        bool Remove(IInterval<TBound> interval);

        /// <summary>
        ///     Removes the element with an interval that contains the specified key from the
        ///     <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </summary>
        /// <param name="key">The key of the interval of the element to remove.</param>
        /// <returns>
        ///     true if the element is successfully removed; otherwise, false. This method also returns false if key was not
        ///     found in the original <see cref="IIntervalDictionary{TBound,TValue}" />.
        /// </returns>
        bool Remove(TBound key);

        /// <summary>
        ///     Gets the value associated with the specified interval.
        /// </summary>
        /// <param name="interval">The interval whose value to get.</param>
        /// <returns>The value of the element with the specified interval.</returns>
        TValue GetValue(IInterval<TBound> interval);

        /// <summary>
        ///     Gets the value associated with the specified interval that contains the specified key.
        /// </summary>
        /// <param name="key">The key of the interval whose value to get.</param>
        /// <returns>The value of the element with the interval that contains the specified key.</returns>
        TValue GetValue(TBound key);

        /// <summary>
        ///     Gets the value associated with the specified interval.
        /// </summary>
        /// <param name="interval">The interval whose value to get.</param>
        /// <param name="value">
        ///     When this method returns, the value associated with the specified interval, if the interval is
        ///     found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     true if the object that implements <see cref="IIntervalDictionary{TBound,TValue}" /> contains an element with
        ///     the specified interval; otherwise, false.
        /// </returns>
        bool TryGetValue(IInterval<TBound> interval, out TValue value);

        /// <summary>
        ///     Gets the value associated with the specified interval that contains the specified key.
        /// </summary>
        /// <param name="key">The key of the interval whose value to get.</param>
        /// <param name="value">
        ///     When this method returns, the value associated with the interval that contains the specified key, if
        ///     the interval is found; otherwise, the default value for the type of the value parameter. This parameter is passed
        ///     uninitialized.
        /// </param>
        /// <returns>
        ///     true if the object that implements <see cref="IIntervalDictionary{TBound,TValue}" /> contains an element with
        ///     the interval that contains the specified key; otherwise, false.
        /// </returns>
        bool TryGetValue(TBound key, out TValue value);
    }
}
