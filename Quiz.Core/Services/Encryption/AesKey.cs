using QuizApp.Core.Domain;
using System.Security.Cryptography;

namespace QuizApp.Core.Services.Encryption;

internal sealed class AesKey : ISymmetricKey
{
    private readonly byte[] _key;

    public AesKey(int keySizeBits)
    {
        if (keySizeBits != 128 && keySizeBits != 192 && keySizeBits != 256)
            throw new ArgumentException("Key size must be 128, 192, or 256 bits.", nameof(keySizeBits));

        _key = RandomNumberGenerator.GetBytes(keySizeBits / 8);
    }

    public AesKey(byte[] keyBytes)
    {
        int keySizeBits = keyBytes.Length * 8;
        if (keySizeBits != 128 && keySizeBits != 192 && keySizeBits != 256)
            throw new ArgumentException("Key size must be 128, 192, or 256 bits.", nameof(keyBytes));

        _key = keyBytes[..];
    }

    public byte[] Encrypt(byte[] plaintext)
    {
        try
        {
            byte[] nonce = new byte[12];
            RandomNumberGenerator.Fill(nonce);

            byte[] ciphertext = new byte[plaintext.Length];
            byte[] tag = new byte[16];

            using var aesGcm = new AesGcm(_key, 16);
            aesGcm.Encrypt(nonce, plaintext, ciphertext, tag);

            byte[] result = new byte[nonce.Length + tag.Length + ciphertext.Length];
            Buffer.BlockCopy(nonce, 0, result, 0, nonce.Length);
            Buffer.BlockCopy(tag, 0, result, nonce.Length, tag.Length);
            Buffer.BlockCopy(ciphertext, 0, result, nonce.Length + tag.Length, ciphertext.Length);

            return result;
        }
        catch (Exception ex)
        {
            throw new ProblemException(typeof(AesKey), "encryption", ex);
        }
    }

    public byte[] Decrypt(byte[] ciphertext)
    {
        try
        {
            if (ciphertext.Length < 28)
            {
                throw new ArgumentException("Ciphertext is too short.");
            }

            ReadOnlySpan<byte> nonce = ciphertext.AsSpan(0, 12);
            ReadOnlySpan<byte> tag = ciphertext.AsSpan(12, 16);
            ReadOnlySpan<byte> actualCiphertext = ciphertext.AsSpan(28);

            byte[] plaintext = new byte[actualCiphertext.Length];

            using var aesGcm = new AesGcm(_key, 16);
            aesGcm.Decrypt(nonce, actualCiphertext, tag, plaintext);

            return plaintext;
        }
        catch (Exception ex)
        {
            throw new ProblemException(typeof(AesKey), "decryption", ex);
        }
    }

    public void Dispose()
    {
        if (_key != null)
        {
            CryptographicOperations.ZeroMemory(_key);
        }
    }
}