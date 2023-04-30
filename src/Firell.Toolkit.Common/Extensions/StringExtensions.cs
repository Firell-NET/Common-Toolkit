using System.Reflection;

namespace Firell.Toolkit.Common.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns the representation of the string to an equivalent enum.
    /// </summary>
    /// <param name="isCaseSensitive">Whether the conversion should be case sensitive or not.</param>
    /// <exception cref="InvalidOperationException"/>
    public static TEnum ToEnum<TEnum>(this string source, bool isCaseSensitive = false) where TEnum : struct
    {
        if (!typeof(TEnum).GetTypeInfo().IsEnum)
        {
            throw new InvalidOperationException("Generic parameter 'TEnum' must be an enum.");
        }

        return (TEnum)Enum.Parse(typeof(TEnum), source, !isCaseSensitive);
    }
}
