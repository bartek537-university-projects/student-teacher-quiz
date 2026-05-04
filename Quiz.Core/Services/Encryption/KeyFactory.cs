namespace QuizApp.Core.Services.Encryption;

internal static class KeyFactory
{
    public async static Task<IEncryptionKey> AesFromPassword(string password)
    {
        // Możesz zrobić jakis wrapper na AES, który będzie np.
        // doklejał do danych jakiś salt. Dlatego zwracam tu interfejs,
        // a nie konkretną implementację.

        return null!; // :)
    }
}
