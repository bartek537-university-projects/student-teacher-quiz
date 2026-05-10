namespace QuizApp.Core.Services.Encryption;

public interface ISymmetricKey : IDisposable
{
    byte[] Encrypt(byte[] plaintext);
    byte[] Decrypt(byte[] ciphertext);
}
