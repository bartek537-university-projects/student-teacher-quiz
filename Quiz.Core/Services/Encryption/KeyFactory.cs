using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Core.Services.Encryption;

internal static class KeyFactory
{
    public async static Task<ISymmetricKey> AesFromPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);

        return new AesKey(hash);
    }
}
