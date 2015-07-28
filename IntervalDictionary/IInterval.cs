namespace IntervalDictionary
{
    using System;

    public interface IInterval<TBound> : IComparable<TBound>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        TBound LowerBound { get; set; }
        TBound UpperBound { get; set; }

        bool Contains(TBound bound);

        bool Intersects(IInterval<TBound> other);

        bool IsSubsetOf(IInterval<TBound> other);

        bool IsSupersetOf(IInterval<TBound> other);

        IInterval<TBound> Intersect(IInterval<TBound> other);

        IInterval<TBound> Union(IInterval<TBound> other);

        IInterval<TBound> Subtract(IInterval<TBound> other);
    }
}
