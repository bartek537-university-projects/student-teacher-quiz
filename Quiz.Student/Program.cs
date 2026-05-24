using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession;

namespace QuizApp.Student;

internal static class Program
{
    private const string _appMutexId = "QuizApp.Student.Mutex";

    [STAThread]
    private static void Main()
    {
        using Mutex mutex = new(false, _appMutexId, out bool isOnlyAppInstance);

        if (!isOnlyAppInstance)
        {
            _ = MessageBox.Show("The app is already running.");
            return;
        }

        //FileSystemQuizRepository quizRepository = new();
        //FileSystemRecentFilesRepository recentFilesRepository = new(@".\recents.json");

        //GetQuiz.Handler getQuizHandler = new(quizRepository);
        //GetRecentFiles.Handler getRecentFilesHandler = new(recentFilesRepository);
        //AddRecentFile.Handler addRecentFileHandler = new(recentFilesRepository);

        ApplicationConfiguration.Initialize();

        //QuizSelectionView view = new();
        //QuizSelectionPresenter presenter = new(view, TimeProvider.System, getQuizHandler, addRecentFileHandler, getRecentFilesHandler);
        //view.Presenter = presenter;

        Quiz quiz = new()
        {
            Title = "Anatomia, gr. B",
            Questions = [
                new Question() {
                    Title = "Ile nóg ma hulajnoga?",
                    PlusPoints = 2,
                    MinusPoints = 0,
                    Answers = [
                        new Answer() { Title = "Jedną", IsCorrect = true },
                        new Answer() { Title = "Dwie", IsCorrect = false },
                        new Answer() { Title = "Czterdzieści dwie", IsCorrect = true },
                        new Answer() { Title = "Sto", IsCorrect = false },
                    ]
                },
                new Question() {
                    Title = "Ile rąk ma stonoga?",
                    PlusPoints = 4,
                    MinusPoints = 2,
                    Answers = [
                        new Answer() { Title = "Jedną", IsCorrect = true },
                        new Answer() { Title = "Dwie", IsCorrect = false },
                        new Answer() { Title = "Czterdzieści dwie", IsCorrect = true },
                        new Answer() { Title = "Sto", IsCorrect = false },
                    ]
                }
            ]
        };

        QuizSessionView view = new();
        QuizSessionPresenter presenter = new(view, TimeProvider.System, quiz);
        view.Presenter = presenter;

        System.Windows.Forms.Application.Run(view);
    }
}