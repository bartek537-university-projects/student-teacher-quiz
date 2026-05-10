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
        button1 = new Button();
        btnLoad = new Button();
        txbTitle = new TextBox();
        btnClear = new Button();
        pnQuestions = new Panel();
        pnVisualBg = new Panel();
        questionSegment1 = new QuestionSegment();
        questionSegment2 = new QuestionSegment();
        pnQuestions.SuspendLayout();
        pnVisualBg.SuspendLayout();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button1.Location = new Point(582, 133);
        button1.Name = "button1";
        button1.Size = new Size(250, 40);
        button1.TabIndex = 0;
        button1.Text = "Zapisz quiz";
        button1.UseVisualStyleBackColor = true;
        button1.Click += btnSave_Click;
        // 
        // btnLoad
        // 
        btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLoad.Location = new Point(582, 87);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(250, 40);
        btnLoad.TabIndex = 1;
        btnLoad.Text = "Wczytaj quiz";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // txbTitle
        // 
        txbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txbTitle.Location = new Point(12, 12);
        txbTitle.Name = "txbTitle";
        txbTitle.Size = new Size(820, 23);
        txbTitle.TabIndex = 2;
        txbTitle.TextChanged += txbTitle_TextChanged;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClear.Location = new Point(582, 41);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(250, 40);
        btnClear.TabIndex = 4;
        btnClear.Text = "Nowy quiz";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // pnQuestions
        // 
        pnQuestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnQuestions.AutoScroll = true;
        pnQuestions.BackColor = SystemColors.ControlDarkDark;
        pnQuestions.Controls.Add(questionSegment2);
        pnQuestions.Controls.Add(questionSegment1);
        pnQuestions.Location = new Point(5, 5);
        pnQuestions.Margin = new Padding(5);
        pnQuestions.Name = "pnQuestions";
        pnQuestions.Size = new Size(554, 498);
        pnQuestions.TabIndex = 6;
        // 
        // pnVisualBg
        // 
        pnVisualBg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnVisualBg.AutoScroll = true;
        pnVisualBg.BackColor = SystemColors.ControlDarkDark;
        pnVisualBg.Controls.Add(pnQuestions);
        pnVisualBg.Location = new Point(12, 41);
        pnVisualBg.Name = "pnVisualBg";
        pnVisualBg.Size = new Size(564, 508);
        pnVisualBg.TabIndex = 7;
        // 
        // questionSegment1
        // 
        questionSegment1.BackColor = Color.Gainsboro;
        questionSegment1.Dock = DockStyle.Top;
        questionSegment1.Location = new Point(0, 0);
        questionSegment1.Name = "questionSegment1";
        questionSegment1.Size = new Size(554, 249);
        questionSegment1.TabIndex = 0;
        // 
        // questionSegment2
        // 
        questionSegment2.BackColor = Color.Gainsboro;
        questionSegment2.Dock = DockStyle.Top;
        questionSegment2.Location = new Point(0, 249);
        questionSegment2.Name = "questionSegment2";
        questionSegment2.Size = new Size(554, 249);
        questionSegment2.TabIndex = 1;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Gainsboro;
        ClientSize = new Size(844, 561);
        Controls.Add(pnVisualBg);
        Controls.Add(btnLoad);
        Controls.Add(button1);
        Controls.Add(btnClear);
        Controls.Add(txbTitle);
        Name = "MainForm";
        Text = "Aplikacja do tworzenia quizu - Teacher";
        Load += Form1_Load;
        pnQuestions.ResumeLayout(false);
        pnVisualBg.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button btnLoad;
    private TextBox txbTitle;
    private Button btnClear;
    private Panel pnQuestions;
    private Panel pnVisualBg;
    private QuestionSegment questionSegment2;
    private QuestionSegment questionSegment1;
}
