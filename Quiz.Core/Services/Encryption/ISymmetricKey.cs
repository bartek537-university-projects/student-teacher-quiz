namespace QuizApp.Core.Services.Encryption;

internal interface ISymmetricKey
{
    byte[] Encrypt(byte[] plaintext);
    byte[] Decrypt(byte[] ciphertext);
}
