namespace QuizApp.Teacher.Presentation.Main;

partial class AnswerEditorControl
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        txtAnswerTitle = new TextBox();
        chkIsCorrect = new CheckBox();
        btnMoveUp = new Button();
        btnMoveDown = new Button();
        btnRemove = new Button();
        SuspendLayout();
        // 
        // txtAnswerTitle
        // 
        txtAnswerTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtAnswerTitle.Location = new Point(3, 3);
        txtAnswerTitle.Name = "txtAnswerTitle";
        txtAnswerTitle.PlaceholderText = QuizApp.Teacher.Properties.Resources.AnswerTitlePlaceholder;
        txtAnswerTitle.Size = new Size(260, 23);
        txtAnswerTitle.TabIndex = 0;
        txtAnswerTitle.TextChanged += TxtAnswerTitle_TextChanged;
        // 
        // chkIsCorrect
        // 
        chkIsCorrect.AutoSize = true;
        chkIsCorrect.Location = new Point(269, 5);
        chkIsCorrect.Name = "chkIsCorrect";
        chkIsCorrect.Size = new Size(77, 19);
        chkIsCorrect.TabIndex = 1;
        chkIsCorrect.Text = QuizApp.Teacher.Properties.Resources.AnswerCorrectText;
        chkIsCorrect.UseVisualStyleBackColor = true;
        chkIsCorrect.CheckedChanged += ChkIsCorrect_CheckedChanged;
        // 
        // btnMoveUp
        // 
        btnMoveUp.Location = new Point(352, 3);
        btnMoveUp.Name = "btnMoveUp";
        btnMoveUp.Size = new Size(52, 23);
        btnMoveUp.TabIndex = 2;
        btnMoveUp.Text = QuizApp.Teacher.Properties.Resources.MoveUpText;
        btnMoveUp.UseVisualStyleBackColor = true;
        btnMoveUp.Click += BtnMoveUp_Click;
        // 
        // btnMoveDown
        // 
        btnMoveDown.Location = new Point(410, 3);
        btnMoveDown.Name = "btnMoveDown";
        btnMoveDown.Size = new Size(52, 23);
        btnMoveDown.TabIndex = 3;
        btnMoveDown.Text = QuizApp.Teacher.Properties.Resources.MoveDownText;
        btnMoveDown.UseVisualStyleBackColor = true;
        btnMoveDown.Click += BtnMoveDown_Click;
        // 
        // btnRemove
        // 
        btnRemove.Location = new Point(468, 3);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(60, 23);
        btnRemove.TabIndex = 4;
        btnRemove.Text = QuizApp.Teacher.Properties.Resources.RemoveText;
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += BtnRemove_Click;
        // 
        // AnswerEditorControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnRemove);
        Controls.Add(btnMoveDown);
        Controls.Add(btnMoveUp);
        Controls.Add(chkIsCorrect);
        Controls.Add(txtAnswerTitle);
        MinimumSize = new Size(540, 30);
        Name = "AnswerEditorControl";
        Size = new Size(540, 30);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtAnswerTitle;
    private CheckBox chkIsCorrect;
    private Button btnMoveUp;
    private Button btnMoveDown;
    private Button btnRemove;
}
