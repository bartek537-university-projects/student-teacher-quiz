namespace QuizApp.Core.Services.Encryption;

internal static class KeyFactory
{
    public async static Task<ISymmetricKey> AesFromPassword(string password)
    {
        // Możesz zrobić jakis wrapper na AES, który będzie np.
        // doklejał do danych jakiś salt. Dlatego zwracam tu interfejs,
        // a nie konkretną implementację.

        await Task.Delay(1000); // symulacja długotrwałej operacji
        return new AesKey([ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 ]);
    }
}
