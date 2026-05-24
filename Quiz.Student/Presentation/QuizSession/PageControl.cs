using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

public partial class PageControl : UserControl
{
    public event Action? PreviousClick;
    public event Action? NextClick;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int PageCount
    {
        get;
        set
        {
            field = value;
            UpdatePages();
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int CurrentPage
    {
        get;
        set
        {
            field = value;
            UpdatePages();
        }
    }

    public PageControl()
    {
        InitializeComponent();
    }

    private void UpdatePages()
    {
        btnPrevious.Enabled = CurrentPage - 1 >= 1;
        btnNext.Enabled = CurrentPage + 1 < PageCount;

        var pageText = $"{CurrentPage} of {PageCount}";
        lbPage.Text = pageText;
    }

    private void btnPrevious_Click(object sender, EventArgs e)
    {
        PreviousClick?.Invoke();
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        NextClick?.Invoke();
    }
}
