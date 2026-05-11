using System.Collections.Immutable;

namespace QuizApp.Core.Extensions;

public static class ImmutableArrayExtensions
{
    public static ImmutableArray<T> SwapAt<T>(this ImmutableArray<T> self, int index1, int index2)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index1, nameof(index1));
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index1, self.Length, nameof(index1));
        ArgumentOutOfRangeException.ThrowIfNegative(index2, nameof(index2));
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index2, self.Length, nameof(index2));

        int i1 = Math.Min(index1, index2);
        int i2 = Math.Max(index1, index2);

        T elm1 = self[i1];
        T elm2 = self[i2];

        return [
            .. self[..i1], elm2,
            .. self[(i1 + 1)..i2], elm1,
            .. self[(i2 + 1)..]
            ];
    }

    public static ImmutableArray<T> Shuffle<T>(this ImmutableArray<T> self, Random rng)
    {
        T[] arr = [.. self];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        return [.. arr];
    }

    public static int FindIndexOf<T>(this ImmutableArray<T> self, Predicate<T> predicate)
    {
        for (int i = 0; i < self.Length; i++)
        {
            if (predicate(self[i]))
                return i;
        }
        return -1;
    }
}
