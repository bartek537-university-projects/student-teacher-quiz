namespace QuizApp.Core.Domain;

internal class ProblemException(Type encryptionClass, string action, Exception? innerException = null) :
    Exception(
        $"An error occurred in class '{encryptionClass.FullName}' during {action}.",
        innerException
        );
