using System.Reflection;

namespace AnalyzerTests;

internal class C
{

    protected C() { }

    public static string? Get(Type type, string key)
    {
        return GetValue(type, key);
    }

    public static string? Get2(Type type, string key)
    {
        return GetValue2(type, key);
    }

    public static string? GetValue(Type resourceType, string key)
    {
        PropertyInfo? messageProperty = resourceType.GetProperty(key, BindingFlags.Static | BindingFlags.Public);
        if (messageProperty == null)
        {
            return null;
        }

        return messageProperty.GetValue(null) as string;
    }

    private static string? GetValue2(Type resourceType, string key)
    {
        Console.WriteLine("Called");

        PropertyInfo? messageProperty = resourceType.GetProperty(key, BindingFlags.Static | BindingFlags.Public);
        if (messageProperty == null)
        {
            return null;
        }

        return messageProperty.GetValue(null) as string;
    }

}
