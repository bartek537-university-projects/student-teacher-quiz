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
        button1 = new Button();
        btnLoad = new Button();
        tbxTitle = new TextBox();
        btnClear = new Button();
        pnQuestions = new Panel();
        pnVisualBg = new Panel();
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
        tbxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        tbxTitle.Location = new Point(12, 12);
        tbxTitle.Name = "txbTitle";
        tbxTitle.Size = new Size(820, 23);
        tbxTitle.TabIndex = 2;
        tbxTitle.TextChanged += txbTitle_TextChanged;
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
        Controls.Add(tbxTitle);
        Name = "MainForm";
        Text = "Aplikacja do tworzenia quizu - Teacher";
        Load += MainForm_Load;
        pnQuestions.ResumeLayout(false);
        pnVisualBg.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button btnLoad;
    private TextBox tbxTitle;
    private Button btnClear;
    private Panel pnQuestions;
    private Panel pnVisualBg;
}
