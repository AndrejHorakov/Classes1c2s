namespace LinqWorking;

public static class MyLinqRealization
{
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
    {
        foreach (var item in source)
        {
            if (count > 0)
            {
                count--;
                continue;
            }
            yield return item;
        }
    }

    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
        foreach (var item in first)
            yield return item;
        foreach (var item in second)
            yield return item;
    }

    public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
    {
        foreach (var item in source)
        {
            if (count <= 0)
                yield break;
            count--;
            yield return item;
        }
    }

    public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
    {
        var length = source.Count();
        var array = new TSource[length];
        int index = 0;
        foreach (var item in source)
        {
            array[index++] = item;
        }
        return array;
    }

    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
        int count = 0;
        foreach (var _ in source)
            count++;
        
        return count;
    }
}