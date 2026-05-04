namespace QuizApp.Core.Services.Encryption;

internal interface IEncryptionKey : IDisposable
{
    byte[] Encrypt(byte[] plaintext);
    byte[] Decrypt(byte[] ciphertext);
}
