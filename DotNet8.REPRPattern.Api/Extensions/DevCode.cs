namespace DotNet8.REPRPattern.Api.Extensions;

public static class DevCode
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    public static T ToObject<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr)!;
    }

    public static IQueryable<TSource> Paginate<TSource>(
        this IQueryable<TSource> source,
        int pageNo,
        int pageSize
    )
    {
        return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
    }
}
