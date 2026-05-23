using QuizApp.Student.Presentation.QuizSession.Interfaces;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

internal partial class QuizSessionView : Form, IQuizSessionView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizSessionPresenter Presenter
    {
        private get;
        set
        {
            field = value;
            SetupPresenter();
        }
    }

    public QuizSessionView()
    {
        InitializeComponent();
    }

    private void SetupPresenter() { }
}
