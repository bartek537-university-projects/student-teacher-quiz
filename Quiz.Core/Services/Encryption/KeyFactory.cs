using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Core.Services.Encryption;

internal static class KeyFactory
{
    private const int ITERATIONS = 200_000;
    private const int KEY_SIZE_BITS = 32;

    private static byte[] HardCodedSalt
    {
        get
        {
            byte[] salt = new byte[16];
            BinaryPrimitives.WriteInt64LittleEndian(salt, -3767562395769532L);
            return salt;
        }
    }

    public static async Task<ISymmetricKey> AesFromPassword(string password)
    {
        byte[] keyBytes = await Task.Run(() =>
            Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                HardCodedSalt,
                ITERATIONS,
                HashAlgorithmName.SHA256,
                KEY_SIZE_BITS
            )
        );

        return new AesKey(keyBytes);
    }
}
