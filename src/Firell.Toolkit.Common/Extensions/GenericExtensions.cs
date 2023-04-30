namespace Firell.Toolkit.Common.Extensions;

public enum ComparableMatch { Inclusive, Exclusive }

public static class GenericExtensions
{
    /// <summary>
    /// Determines whether a object in a specified sequence equals to the current object.
    /// </summary>
    /// <param name="values">The sequence of objects to compare with the current object.</param>
    public static bool Equals<T>(this T source, params T[] values)
    {
        return values.Contains(source);
    }

    /// <summary>
    /// Determines whether the current object is in range of two specified objects.
    /// </summary>
    public static bool InRange<T>(this T source, T start, T end, ComparableMatch match = ComparableMatch.Inclusive) where T : IComparable<T>
    {
        if (match == ComparableMatch.Exclusive)
        {
            return source.CompareTo(start) > 0 && source.CompareTo(end) < 0;
        }

        return source.CompareTo(start) >= 0 && source.CompareTo(end) <= 0;
    }
}
