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
        panel1 = new Panel();
        questionSegment3 = new QuestionSegment();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button1.Location = new Point(528, 153);
        button1.Name = "button1";
        button1.Size = new Size(253, 50);
        button1.TabIndex = 0;
        button1.Text = "Zapisz quiz";
        button1.UseVisualStyleBackColor = true;
        button1.Click += btnSave_Click;
        // 
        // btnLoad
        // 
        btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLoad.Location = new Point(528, 97);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(253, 50);
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
        txbTitle.Size = new Size(769, 23);
        txbTitle.TabIndex = 2;
        txbTitle.TextChanged += txbTitle_TextChanged;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClear.Location = new Point(528, 41);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(253, 50);
        btnClear.TabIndex = 4;
        btnClear.Text = "Nowy quiz";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.AutoScroll = true;
        panel1.Controls.Add(questionSegment3);
        panel1.Location = new Point(12, 41);
        panel1.Name = "panel1";
        panel1.Size = new Size(510, 465);
        panel1.TabIndex = 6;
        // 
        // questionSegment3
        // 
        questionSegment3.BackColor = SystemColors.GradientInactiveCaption;
        questionSegment3.Dock = DockStyle.Top;
        questionSegment3.Location = new Point(0, 0);
        questionSegment3.Name = "questionSegment3";
        questionSegment3.Size = new Size(510, 210);
        questionSegment3.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(793, 518);
        Controls.Add(panel1);
        Controls.Add(btnLoad);
        Controls.Add(button1);
        Controls.Add(btnClear);
        Controls.Add(txbTitle);
        Name = "MainForm";
        Text = "Aplikacja do tworzenia quizu - Teacher";
        Load += Form1_Load;
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button btnLoad;
    private TextBox txbTitle;
    private Button btnClear;
    private Panel panel1;
    private QuestionSegment questionSegment3;
}
