namespace Paetzold.Collections.IntervalDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class IntervalDictionary<TBound, TValue> : IIntervalDictionary<TBound, TValue>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        private readonly ICollection<IntervalValuePair<TBound, TValue>> intervalValuePairs;

        public IntervalDictionary()
        {
            intervalValuePairs = new List<IntervalValuePair<TBound, TValue>>();
        }

        public IEnumerator<IntervalValuePair<TBound, TValue>> GetEnumerator()
        {
            return intervalValuePairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IntervalValuePair<TBound, TValue> item)
        {
            if (intervalValuePairs.Any(pair => pair.Interval.Intersects(item.Interval)))
            {
                throw new ArgumentException("An element with the same interval already exists.");
            }

            intervalValuePairs.Add(item);
        }

        public void Clear()
        {
            intervalValuePairs.Clear();
        }

        public bool Contains(IntervalValuePair<TBound, TValue> item)
        {
            return intervalValuePairs.Contains(item);
        }

        public void CopyTo(IntervalValuePair<TBound, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            foreach (var pair in intervalValuePairs)
            {
                array[arrayIndex++] = pair;
            }
        }

        public bool Remove(IntervalValuePair<TBound, TValue> item)
        {
            throw new NotImplementedException();
        }

        public int Count => intervalValuePairs.Count;
        public bool IsReadOnly => false;

        public ICollection<IInterval<TBound>> Intervals
        {
            get { return intervalValuePairs.Select(pair => pair.Interval).ToList(); }
        }

        public ICollection<TValue> Values
        {
            get { return intervalValuePairs.Select(pair => pair.Value).ToList(); }
        }

        public TValue this[IInterval<TBound> interval]
        {
            get { return GetValue(interval); }
            set { Add(interval, value); }
        }

        public TValue this[TBound key]
        {
            get { return GetValue(key); }
            set { Add(new Interval<TBound>(key, key), value); }
        }

        public void Add(IInterval<TBound> interval, TValue value)
        {
            if (interval == null)
            {
                throw new ArgumentNullException(nameof(interval));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Add(new IntervalValuePair<TBound, TValue>(interval, value));
        }

        public bool ContainsInterval(IInterval<TBound> interval)
        {
            if (interval == null)
            {
                throw new ArgumentNullException(nameof(interval));
            }

            return intervalValuePairs.Any(pair => pair.Interval.IsSupersetOf(interval));
        }

        public bool ContainsKey(TBound key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return intervalValuePairs.Any(pair => pair.Interval.Contains(key));
        }

        public bool ContainsValue(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return intervalValuePairs.Any(pair => pair.Value.Equals(value));
        }

        public bool Remove(IInterval<TBound> interval)
        {
            if (interval == null)
            {
                throw new ArgumentNullException(nameof(interval));
            }

            throw new NotImplementedException();
        }

        public bool Remove(TBound key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            throw new NotImplementedException();
        }

        public TValue GetValue(IInterval<TBound> interval)
        {
            TValue result;
            if (TryGetValue(interval, out result))
            {
                return result;
            }

            throw new KeyNotFoundException();
        }

        public TValue GetValue(TBound key)
        {
            TValue result;
            if (TryGetValue(key, out result))
            {
                return result;
            }

            throw new KeyNotFoundException();
        }

        public bool TryGetValue(IInterval<TBound> interval, out TValue value)
        {
            if (interval == null)
            {
                throw new ArgumentNullException(nameof(interval));
            }

            value = default(TValue);

            foreach (var pair in intervalValuePairs.Where(pair => pair.Interval.Equals(interval)))
            {
                value = pair.Value;
                return true;
            }

            return false;
        }

        public bool TryGetValue(TBound key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            value = default(TValue);

            foreach (var pair in intervalValuePairs.Where(pair => pair.Interval.Contains(key)))
            {
                value = pair.Value;
                return true;
            }

            return false;
        }
    }
}
