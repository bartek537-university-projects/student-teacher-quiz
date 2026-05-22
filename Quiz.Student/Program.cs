using QuizApp.Student.Presentation.Main;
using QuizApp.Student.Presentation.QuizSelection;

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

        ApplicationConfiguration.Initialize();

        QuizSelectionView view = new();
        QuizSelectionPresenter presenter = new(view);
        view.Presenter = presenter;

        System.Windows.Forms.Application.Run(view);
    }
}