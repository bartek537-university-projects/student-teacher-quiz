using System.Text;
using System.Text.Json;

namespace QuizApp.Core.Services.Serialization;

internal static class Serializer
{
    public static byte[] Serialize<T>(T obj) where T : class
    {
        string json = JsonSerializer.Serialize(obj);
        return Encoding.UTF8.GetBytes(json);
    }

    public static T Deserialize<T>(byte[] data) where T : class
    {
        try
        {
            string json = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(json) ??
                throw new InvalidOperationException("Json argument was null.");
        }
        catch (Exception ex)
        {
            throw new ProblemException(typeof(Serializer), "deserialization", ex);
        }
    }
}
