using System.Reflection;

namespace AnalyzerTests;

public class C
{

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

    private bool _atLeastOneRead = false;

    public void ReadStream(FileStream stream) // Noncompliant: Uses only System.IO.Stream methods
    {
        int a;
        while ((a = stream.ReadByte()) != -1)
        {
            if (a == 0) { throw new InvalidOperationException("bad"); }

            if (!_atLeastOneRead)
            {
                _atLeastOneRead = true;
            }
        }
    }

}
