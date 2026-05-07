using QuizApp.Teacher.Presentation.Main;

namespace QuizApp.Teacher;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.Run(new MainForm());
    }
}