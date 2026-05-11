using System.ComponentModel;

namespace QuizApp.Teacher.Presentation.Controls;

[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
internal class InvisiblePanel : Panel
{
    private const int WS_EX_TRANSPARENT = 0x00000020;

    public InvisiblePanel()
    {
        SetStyle(ControlStyles.Opaque, true);
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= WS_EX_TRANSPARENT;
            return cp;
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e) { }
    protected override void OnPaint(PaintEventArgs e) { }
}