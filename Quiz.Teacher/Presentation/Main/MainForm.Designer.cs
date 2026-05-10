namespace QuizApp.Teacher.Presentation.Main;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tlpRoot = new TableLayoutPanel();
        pnlHeader = new Panel();
        lblQuizTitle = new Label();
        txtQuizTitle = new TextBox();
        btnLoad = new Button();
        btnSave = new Button();
        btnClear = new Button();
        btnAddQuestion = new Button();
        pnlContent = new Panel();
        flpQuestions = new FlowLayoutPanel();
        tlpRoot.SuspendLayout();
        pnlHeader.SuspendLayout();
        pnlContent.SuspendLayout();
        SuspendLayout();
        // 
        // tlpRoot
        // 
        tlpRoot.ColumnCount = 1;
        tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpRoot.Controls.Add(pnlHeader, 0, 0);
        tlpRoot.Controls.Add(pnlContent, 0, 1);
        tlpRoot.Dock = DockStyle.Fill;
        tlpRoot.Location = new Point(0, 0);
        tlpRoot.Name = "tlpRoot";
        tlpRoot.RowCount = 2;
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpRoot.Size = new Size(1000, 700);
        tlpRoot.TabIndex = 0;
        // 
        // pnlHeader
        // 
        pnlHeader.AutoSize = true;
        pnlHeader.AutoSizeMode = AutoSizeMode.GrowOnly;
        pnlHeader.Controls.Add(btnAddQuestion);
        pnlHeader.Controls.Add(btnClear);
        pnlHeader.Controls.Add(btnSave);
        pnlHeader.Controls.Add(btnLoad);
        pnlHeader.Controls.Add(txtQuizTitle);
        pnlHeader.Controls.Add(lblQuizTitle);
        pnlHeader.Dock = DockStyle.Fill;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(12);
        pnlHeader.Size = new Size(1000, 70);
        pnlHeader.TabIndex = 0;
        // 
        // lblQuizTitle
        // 
        lblQuizTitle.AutoSize = true;
        lblQuizTitle.Location = new Point(12, 16);
        lblQuizTitle.Name = "lblQuizTitle";
        lblQuizTitle.Size = new Size(68, 15);
        lblQuizTitle.TabIndex = 0;
        lblQuizTitle.Text = QuizApp.Teacher.Properties.Resources.QuizTitleLabel;
        // 
        // txtQuizTitle
        // 
        txtQuizTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtQuizTitle.Location = new Point(12, 34);
        txtQuizTitle.Name = "txtQuizTitle";
        txtQuizTitle.Size = new Size(520, 23);
        txtQuizTitle.TabIndex = 1;
        // 
        // btnLoad
        // 
        btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLoad.Location = new Point(550, 32);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(80, 26);
        btnLoad.TabIndex = 2;
        btnLoad.Text = QuizApp.Teacher.Properties.Resources.LoadButtonText;
        btnLoad.UseVisualStyleBackColor = true;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Location = new Point(636, 32);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(80, 26);
        btnSave.TabIndex = 3;
        btnSave.Text = QuizApp.Teacher.Properties.Resources.SaveButtonText;
        btnSave.UseVisualStyleBackColor = true;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClear.Location = new Point(722, 32);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(80, 26);
        btnClear.TabIndex = 4;
        btnClear.Text = QuizApp.Teacher.Properties.Resources.ClearButtonText;
        btnClear.UseVisualStyleBackColor = true;
        // 
        // btnAddQuestion
        // 
        btnAddQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAddQuestion.Location = new Point(808, 32);
        btnAddQuestion.Name = "btnAddQuestion";
        btnAddQuestion.Size = new Size(120, 26);
        btnAddQuestion.TabIndex = 5;
        btnAddQuestion.Text = QuizApp.Teacher.Properties.Resources.AddQuestionButtonText;
        btnAddQuestion.UseVisualStyleBackColor = true;
        // 
        // pnlContent
        // 
        pnlContent.AutoScroll = true;
        pnlContent.Controls.Add(flpQuestions);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(0, 70);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(12, 6, 12, 12);
        pnlContent.Size = new Size(1000, 630);
        pnlContent.TabIndex = 1;
        // 
        // flpQuestions
        // 
        flpQuestions.AutoSize = true;
        flpQuestions.AutoSizeMode = AutoSizeMode.GrowOnly;
        flpQuestions.FlowDirection = FlowDirection.TopDown;
        flpQuestions.Location = new Point(12, 6);
        flpQuestions.Name = "flpQuestions";
        flpQuestions.Size = new Size(960, 0);
        flpQuestions.TabIndex = 0;
        flpQuestions.WrapContents = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 700);
        Controls.Add(tlpRoot);
        MinimumSize = new Size(900, 600);
        Name = "MainForm";
        Text = QuizApp.Teacher.Properties.Resources.AppTitle;
        Load += Form1_Load;
        tlpRoot.ResumeLayout(false);
        tlpRoot.PerformLayout();
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlContent.ResumeLayout(false);
        pnlContent.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tlpRoot;
    private Panel pnlHeader;
    private Label lblQuizTitle;
    private TextBox txtQuizTitle;
    private Button btnLoad;
    private Button btnSave;
    private Button btnClear;
    private Button btnAddQuestion;
    private Panel pnlContent;
    private FlowLayoutPanel flpQuestions;
}
