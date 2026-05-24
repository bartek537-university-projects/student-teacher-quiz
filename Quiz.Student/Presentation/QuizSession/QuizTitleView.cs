using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

public partial class QuizTitleView : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Title
    {
        get => lbTitle.Text;
        set => lbTitle.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string QuizId
    {
        get => lbQuizId.Text;
        set => lbQuizId.Text = value;
    }

    public QuizTitleView()
    {
        InitializeComponent();
    }
}
