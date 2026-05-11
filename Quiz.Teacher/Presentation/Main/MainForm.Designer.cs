using QuizApp.Teacher.View;

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
        btnSave = new Button();
        btnLoad = new Button();
        tbxTitle = new TextBox();
        btnClear = new Button();
        pnQuestions = new Panel();
        pnVisualBg = new Panel();
        pnLock = new QuizApp.Teacher.Presentation.Controls.InvisiblePanel();
        btnAddQuestion = new Button();
        lbAutoTitle = new Label();
        btnInspireQuestion = new Button();
        pnVisualBg.SuspendLayout();
        SuspendLayout();
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Location = new Point(848, 167);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(250, 40);
        btnSave.TabIndex = 3;
        btnSave.Text = "Zapisz quiz";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnLoad
        // 
        btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLoad.Location = new Point(848, 121);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(250, 40);
        btnLoad.TabIndex = 2;
        btnLoad.Text = "Wczytaj quiz";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // tbxTitle
        // 
        tbxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tbxTitle.Location = new Point(12, 46);
        tbxTitle.Name = "tbxTitle";
        tbxTitle.Size = new Size(1086, 23);
        tbxTitle.TabIndex = 0;
        tbxTitle.TextChanged += txbTitle_TextChanged;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClear.Location = new Point(848, 75);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(250, 40);
        btnClear.TabIndex = 1;
        btnClear.Text = "Nowy quiz";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // pnQuestions
        // 
        pnQuestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnQuestions.AutoScroll = true;
        pnQuestions.BackColor = SystemColors.ControlDarkDark;
        pnQuestions.Location = new Point(5, 7);
        pnQuestions.Margin = new Padding(5);
        pnQuestions.Name = "pnQuestions";
        pnQuestions.Size = new Size(820, 526);
        pnQuestions.TabIndex = 6;
        // 
        // pnVisualBg
        // 
        pnVisualBg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnVisualBg.AutoScroll = true;
        pnVisualBg.BackColor = SystemColors.ControlDarkDark;
        pnVisualBg.Controls.Add(pnQuestions);
        pnVisualBg.Location = new Point(12, 75);
        pnVisualBg.Name = "pnVisualBg";
        pnVisualBg.Size = new Size(830, 538);
        pnVisualBg.TabIndex = 7;
        // 
        // pnLock
        // 
        pnLock.BackColor = Color.RosyBrown;
        pnLock.Dock = DockStyle.Fill;
        pnLock.Location = new Point(0, 0);
        pnLock.Name = "pnLock";
        pnLock.Size = new Size(1110, 625);
        pnLock.TabIndex = 8;
        // 
        // btnAddQuestion
        // 
        btnAddQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAddQuestion.Location = new Point(848, 223);
        btnAddQuestion.Name = "btnAddQuestion";
        btnAddQuestion.Size = new Size(250, 40);
        btnAddQuestion.TabIndex = 4;
        btnAddQuestion.Text = "Dodaj pytanie";
        btnAddQuestion.UseVisualStyleBackColor = true;
        btnAddQuestion.Click += btnAddQuestion_Click;
        // 
        // lbAutoTitle
        // 
        lbAutoTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lbAutoTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
        lbAutoTitle.Location = new Point(12, 9);
        lbAutoTitle.Name = "lbAutoTitle";
        lbAutoTitle.Size = new Size(1086, 34);
        lbAutoTitle.TabIndex = 9;
        lbAutoTitle.Text = "Tytuł Quizu";
        lbAutoTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnInspireQuestion
        // 
        btnInspireQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnInspireQuestion.Location = new Point(848, 269);
        btnInspireQuestion.Name = "btnInspireQuestion";
        btnInspireQuestion.Size = new Size(250, 40);
        btnInspireQuestion.TabIndex = 5;
        btnInspireQuestion.Text = "Dodaj inspirację";
        btnInspireQuestion.UseVisualStyleBackColor = true;
        btnInspireQuestion.Click += btnInspireQuestion_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Gainsboro;
        ClientSize = new Size(1110, 625);
        Controls.Add(btnInspireQuestion);
        Controls.Add(lbAutoTitle);
        Controls.Add(btnAddQuestion);
        Controls.Add(btnLoad);
        Controls.Add(btnSave);
        Controls.Add(pnVisualBg);
        Controls.Add(btnClear);
        Controls.Add(tbxTitle);
        Controls.Add(pnLock);
        Name = "MainForm";
        Text = "Aplikacja do tworzenia quizu - Teacher";
        Load += MainForm_Load;
        pnVisualBg.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnSave;
    private Button btnLoad;
    private TextBox tbxTitle;
    private Button btnClear;
    private Panel pnQuestions;
    private Panel pnVisualBg;
    private Controls.InvisiblePanel pnLock;
    private Button btnAddQuestion;
    private Label lbAutoTitle;
    private Button btnInspireQuestion;
}
