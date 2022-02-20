using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace CSharpTutorial;

public static class ObjectExtensions
{
    //public static string SerializeToJson<T>(this T self)
    //{
    //    return JsonSerializer.Serialize(self,
    //                new JsonSerializerOptions
    //                {
    //                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
    //                    WriteIndented = true
    //                });

    //}

    public static string SerializeToJson<T>(this T self)
    {
        return JsonSerializer.Serialize<object>(self,
                    new JsonSerializerOptions
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
                        WriteIndented = true
                    });

    }

    public static T DeserializeFromJson<T>(this string self)
    {
        return (T)JsonSerializer.Deserialize(self, typeof(T));

    }

    public static void Print(this string self)
    {
        Console.WriteLine(self);
    }
}