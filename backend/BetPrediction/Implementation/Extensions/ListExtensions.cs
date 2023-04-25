namespace Implementation.Extensions;

public static class ListExtensions
{
    public static T? GetByIndexOrDefault<T>(this List<T?>? list, int index)
    {
        if (list == null) return default;
        return index >= list.Count ? default : list[index];
    }
}