namespace Engine.Utils;
public static class CollectionExtensions
{
    public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            hashSet.Add(item);
        }
    }

    public static TV GetOrCreate<TK, TV>(this IDictionary<TK, TV> dictionary, TK key) where TV : new()
    {
        if (!dictionary.TryGetValue(key, out var value))
        {
            value = new TV();
            dictionary.Add(key, value);
        }
        return value;
    }
}
