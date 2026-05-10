namespace QuizApp.Teacher.Presentation.Main;

partial class QuestionEditorControl
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
        tlpRoot = new TableLayoutPanel();
        pnlHeader = new Panel();
        lblQuestionTitle = new Label();
        txtQuestionTitle = new TextBox();
        lblPlusPoints = new Label();
        nudPlusPoints = new NumericUpDown();
        lblMinusPoints = new Label();
        nudMinusPoints = new NumericUpDown();
        btnMoveUp = new Button();
        btnMoveDown = new Button();
        btnRemove = new Button();
        pnlBody = new Panel();
        flpAnswers = new FlowLayoutPanel();
        btnAddAnswer = new Button();
        tlpRoot.SuspendLayout();
        pnlHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPlusPoints).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudMinusPoints).BeginInit();
        pnlBody.SuspendLayout();
        SuspendLayout();
        // 
        // tlpRoot
        // 
        tlpRoot.ColumnCount = 1;
        tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpRoot.Dock = DockStyle.Fill;
        tlpRoot.RowCount = 2;
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tlpRoot.Controls.Add(pnlHeader, 0, 0);
        tlpRoot.Controls.Add(pnlBody, 0, 1);
        tlpRoot.Name = "tlpRoot";
        tlpRoot.Padding = new Padding(6);
        tlpRoot.Size = new Size(740, 210);
        tlpRoot.TabIndex = 0;
        // 
        // pnlHeader
        // 
        pnlHeader.AutoSize = true;
        pnlHeader.AutoSizeMode = AutoSizeMode.GrowOnly;
        pnlHeader.Controls.Add(btnRemove);
        pnlHeader.Controls.Add(btnMoveDown);
        pnlHeader.Controls.Add(btnMoveUp);
        pnlHeader.Controls.Add(nudMinusPoints);
        pnlHeader.Controls.Add(lblMinusPoints);
        pnlHeader.Controls.Add(nudPlusPoints);
        pnlHeader.Controls.Add(lblPlusPoints);
        pnlHeader.Controls.Add(txtQuestionTitle);
        pnlHeader.Controls.Add(lblQuestionTitle);
        pnlHeader.Dock = DockStyle.Fill;
        pnlHeader.Location = new Point(6, 6);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(728, 70);
        pnlHeader.TabIndex = 0;
        // 
        // lblQuestionTitle
        // 
        lblQuestionTitle.AutoSize = true;
        lblQuestionTitle.Location = new Point(3, 6);
        lblQuestionTitle.Name = "lblQuestionTitle";
        lblQuestionTitle.Size = new Size(75, 15);
        lblQuestionTitle.TabIndex = 0;
        lblQuestionTitle.Text = "Pytanie 1";
        // 
        // txtQuestionTitle
        // 
        txtQuestionTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtQuestionTitle.Location = new Point(3, 24);
        txtQuestionTitle.Name = "txtQuestionTitle";
        txtQuestionTitle.PlaceholderText = QuizApp.Teacher.Properties.Resources.QuestionTitlePlaceholder;
        txtQuestionTitle.Size = new Size(420, 23);
        txtQuestionTitle.TabIndex = 1;
        txtQuestionTitle.TextChanged += TxtQuestionTitle_TextChanged;
        // 
        // lblPlusPoints
        // 
        lblPlusPoints.AutoSize = true;
        lblPlusPoints.Location = new Point(429, 6);
        lblPlusPoints.Name = "lblPlusPoints";
        lblPlusPoints.Size = new Size(55, 15);
        lblPlusPoints.TabIndex = 2;
        lblPlusPoints.Text = QuizApp.Teacher.Properties.Resources.PlusPointsLabel;
        // 
        // nudPlusPoints
        // 
        nudPlusPoints.Location = new Point(490, 24);
        nudPlusPoints.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPlusPoints.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        nudPlusPoints.Name = "nudPlusPoints";
        nudPlusPoints.Size = new Size(80, 23);
        nudPlusPoints.TabIndex = 3;
        nudPlusPoints.ValueChanged += NudPlusPoints_ValueChanged;
        // 
        // lblMinusPoints
        // 
        lblMinusPoints.AutoSize = true;
        lblMinusPoints.Location = new Point(576, 6);
        lblMinusPoints.Name = "lblMinusPoints";
        lblMinusPoints.Size = new Size(55, 15);
        lblMinusPoints.TabIndex = 4;
        lblMinusPoints.Text = QuizApp.Teacher.Properties.Resources.MinusPointsLabel;
        // 
        // nudMinusPoints
        // 
        nudMinusPoints.Location = new Point(637, 24);
        nudMinusPoints.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudMinusPoints.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        nudMinusPoints.Name = "nudMinusPoints";
        nudMinusPoints.Size = new Size(80, 23);
        nudMinusPoints.TabIndex = 5;
        nudMinusPoints.ValueChanged += NudMinusPoints_ValueChanged;
        // 
        // btnMoveUp
        // 
        btnMoveUp.Location = new Point(429, 48);
        btnMoveUp.Name = "btnMoveUp";
        btnMoveUp.Size = new Size(60, 23);
        btnMoveUp.TabIndex = 6;
        btnMoveUp.Text = QuizApp.Teacher.Properties.Resources.MoveUpText;
        btnMoveUp.UseVisualStyleBackColor = true;
        btnMoveUp.Click += BtnMoveUp_Click;
        // 
        // btnMoveDown
        // 
        btnMoveDown.Location = new Point(495, 48);
        btnMoveDown.Name = "btnMoveDown";
        btnMoveDown.Size = new Size(60, 23);
        btnMoveDown.TabIndex = 7;
        btnMoveDown.Text = QuizApp.Teacher.Properties.Resources.MoveDownText;
        btnMoveDown.UseVisualStyleBackColor = true;
        btnMoveDown.Click += BtnMoveDown_Click;
        // 
        // btnRemove
        // 
        btnRemove.Location = new Point(561, 48);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(60, 23);
        btnRemove.TabIndex = 8;
        btnRemove.Text = QuizApp.Teacher.Properties.Resources.RemoveText;
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += BtnRemove_Click;
        // 
        // pnlBody
        // 
        pnlBody.AutoSize = true;
        pnlBody.AutoSizeMode = AutoSizeMode.GrowOnly;
        pnlBody.Controls.Add(flpAnswers);
        pnlBody.Controls.Add(btnAddAnswer);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(6, 82);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(0, 6, 0, 0);
        pnlBody.Size = new Size(728, 118);
        pnlBody.TabIndex = 1;
        // 
        // flpAnswers
        // 
        flpAnswers.AutoSize = true;
        flpAnswers.AutoSizeMode = AutoSizeMode.GrowOnly;
        flpAnswers.FlowDirection = FlowDirection.TopDown;
        flpAnswers.Location = new Point(3, 6);
        flpAnswers.Name = "flpAnswers";
        flpAnswers.Size = new Size(600, 0);
        flpAnswers.TabIndex = 0;
        flpAnswers.WrapContents = false;
        // 
        // btnAddAnswer
        // 
        btnAddAnswer.Location = new Point(3, 12);
        btnAddAnswer.Name = "btnAddAnswer";
        btnAddAnswer.Size = new Size(120, 23);
        btnAddAnswer.TabIndex = 1;
        btnAddAnswer.Text = QuizApp.Teacher.Properties.Resources.AddAnswerButtonText;
        btnAddAnswer.UseVisualStyleBackColor = true;
        btnAddAnswer.Click += BtnAddAnswer_Click;
        // 
        // QuestionEditorControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tlpRoot);
        MinimumSize = new Size(740, 200);
        Name = "QuestionEditorControl";
        Size = new Size(740, 210);
        tlpRoot.ResumeLayout(false);
        tlpRoot.PerformLayout();
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudPlusPoints).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudMinusPoints).EndInit();
        pnlBody.ResumeLayout(false);
        pnlBody.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tlpRoot;
    private Panel pnlHeader;
    private Label lblQuestionTitle;
    private TextBox txtQuestionTitle;
    private Label lblPlusPoints;
    private NumericUpDown nudPlusPoints;
    private Label lblMinusPoints;
    private NumericUpDown nudMinusPoints;
    private Button btnMoveUp;
    private Button btnMoveDown;
    private Button btnRemove;
    private Panel pnlBody;
    private FlowLayoutPanel flpAnswers;
    private Button btnAddAnswer;
}
