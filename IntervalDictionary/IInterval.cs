namespace IntervalDictionary
{
    using System;

    public interface IInterval<TBound> : IComparable<TBound>, 
                                         IComparable<IInterval<TBound>>, 
                                         IEquatable<IInterval<TBound>>
        where TBound : IComparable<TBound>, IEquatable<TBound>
    {
        TBound LowerBound { get; set; }
        TBound UpperBound { get; set; }

        bool Contains(TBound bound);

        bool Intersects(IInterval<TBound> other);
    }
}
