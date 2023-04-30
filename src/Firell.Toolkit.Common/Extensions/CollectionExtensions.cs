using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Firell.Toolkit.Common.Extensions;

public static class CollectionExtensions
{
    /// <summary>
    /// Creates a <see cref="ObservableCollection{T}"/> from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
        return new ObservableCollection<T>(source);
    }

    /// <summary>
    /// Adds the elements of the sequence to the end of the collection.
    /// </summary>
    /// <param name="values">The elements that should be added to the end of the <see cref="ICollection{T}"/>.</param>
    public static void AddRange<T>(this ICollection<T> source, params T[] values)
    {
        foreach (T item in values)
        {
            source.Add(item);
        }
    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the collection.
    /// </summary>
    /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ICollection{T}"/>.</param>
    public static void AddRange<T>(this ICollection<T> source, IEnumerable<T>? collection)
    {
        if (collection != null)
        {
            foreach (T item in collection)
            {
                source.Add(item);
            }
        }
    }

    /// <summary>
    /// Shuffles the elements in the sequence using the Fisher-Yates algorithm.
    /// </summary>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        Random random = new Random();

        List<T> buffer = source.ToList();
        for (int i = 0; i < buffer.Count; i++)
        {
            int j = random.Next(i, buffer.Count);
            yield return buffer[j];

            buffer[j] = buffer[i];
        }
    }

    /// <summary>
    /// Iterate over the elements in the sequence while performing a certain action.
    /// </summary>
    /// <param name="action">A action to perform on each iteration.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }

    /// <summary>
    /// Determines whether a nullable sequence isn't null and contains any elements.
    /// </summary>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source)
    {
        return source == null || !Enumerable.Any(source);
    }

    /// <summary>
    /// Determines whether a nullable sequence isn't null and any elements satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source, Func<T, bool> predicate)
    {
        return source == null || !Enumerable.Any(source, predicate);
    }

    /// <summary>
    /// Returns the elements of the sequence or the type parameter's default value if the sequence is null.
    /// </summary>
    public static IEnumerable<T> DefaultIfNull<T>(this IEnumerable<T>? source)
    {
        return source ?? Enumerable.Empty<T>();
    }
}