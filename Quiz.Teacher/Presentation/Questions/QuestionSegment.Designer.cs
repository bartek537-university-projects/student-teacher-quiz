namespace QuizApp.Teacher.Presentation.Main
{
    partial class QuestionSegment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxTitle = new TextBox();
            btnDelete = new Button();
            tbxPlusPoints = new TextBox();
            tbxMinusPoints = new TextBox();
            cbxMinusPoints = new CheckBox();
            cbxPlusPoints = new CheckBox();
            lbAutoTitle = new Label();
            btnUp = new Button();
            btnDown = new Button();
            pnViusalBg = new Panel();
            pnAnswers = new Panel();
            answerTools = new AnswerTools();
            btNew = new Button();
            pnViusalBg.SuspendLayout();
            pnAnswers.SuspendLayout();
            SuspendLayout();
            // 
            // tbxTitle
            // 
            tbxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxTitle.Location = new Point(3, 43);
            tbxTitle.Name = "tbxTitle";
            tbxTitle.Size = new Size(538, 23);
            tbxTitle.TabIndex = 0;
            tbxTitle.TextChanged += tbxTitle_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnDelete.Location = new Point(505, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(36, 34);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "X";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbxPlusPoints
            // 
            tbxPlusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbxPlusPoints.Location = new Point(398, 72);
            tbxPlusPoints.MaxLength = 5;
            tbxPlusPoints.Name = "tbxPlusPoints";
            tbxPlusPoints.Size = new Size(67, 23);
            tbxPlusPoints.TabIndex = 2;
            tbxPlusPoints.KeyPress += imagineOnlyNumbers_KeyPress;
            tbxPlusPoints.Validated += tbxPlusPoints_TextChanged;
            // 
            // tbxMinusPoints
            // 
            tbxMinusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbxMinusPoints.Location = new Point(398, 101);
            tbxMinusPoints.MaxLength = 5;
            tbxMinusPoints.Name = "tbxMinusPoints";
            tbxMinusPoints.Size = new Size(67, 23);
            tbxMinusPoints.TabIndex = 4;
            tbxMinusPoints.KeyPress += imagineOnlyNumbers_KeyPress;
            tbxMinusPoints.Leave += tbxMinusPoints_TextChanged;
            // 
            // cbxMinusPoints
            // 
            cbxMinusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxMinusPoints.AutoSize = true;
            cbxMinusPoints.Location = new Point(471, 103);
            cbxMinusPoints.Name = "cbxMinusPoints";
            cbxMinusPoints.Size = new Size(67, 19);
            cbxMinusPoints.TabIndex = 5;
            cbxMinusPoints.Text = "Ujemne";
            cbxMinusPoints.UseVisualStyleBackColor = true;
            cbxMinusPoints.CheckedChanged += cbxMinusPoints_CheckedChanged;
            // 
            // cbxPlusPoints
            // 
            cbxPlusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxPlusPoints.AutoSize = true;
            cbxPlusPoints.Location = new Point(471, 74);
            cbxPlusPoints.Name = "cbxPlusPoints";
            cbxPlusPoints.Size = new Size(63, 19);
            cbxPlusPoints.TabIndex = 3;
            cbxPlusPoints.Text = "Punkty";
            cbxPlusPoints.UseVisualStyleBackColor = true;
            cbxPlusPoints.CheckedChanged += cbxPlusPoints_CheckedChanged;
            // 
            // lbAutoTitle
            // 
            lbAutoTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbAutoTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbAutoTitle.Location = new Point(3, 3);
            lbAutoTitle.Name = "lbAutoTitle";
            lbAutoTitle.Size = new Size(496, 34);
            lbAutoTitle.TabIndex = 8;
            lbAutoTitle.Text = "Pytanie 0";
            lbAutoTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUp.Location = new Point(398, 130);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(140, 34);
            btnUp.TabIndex = 6;
            btnUp.Text = "Przesuń w górę";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDown.Location = new Point(398, 169);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(140, 34);
            btnDown.TabIndex = 7;
            btnDown.Text = "Przesuń w dół";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // pnViusalBg
            // 
            pnViusalBg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnViusalBg.AutoScroll = true;
            pnViusalBg.BackColor = SystemColors.AppWorkspace;
            pnViusalBg.Controls.Add(pnAnswers);
            pnViusalBg.Location = new Point(3, 72);
            pnViusalBg.Name = "pnViusalBg";
            pnViusalBg.Size = new Size(389, 171);
            pnViusalBg.TabIndex = 12;
            // 
            // pnAnswers
            // 
            pnAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnAnswers.AutoScroll = true;
            pnAnswers.BackColor = SystemColors.AppWorkspace;
            pnAnswers.Controls.Add(answerTools);
            pnAnswers.Location = new Point(5, 5);
            pnAnswers.Margin = new Padding(5);
            pnAnswers.Name = "pnAnswers";
            pnAnswers.Size = new Size(379, 161);
            pnAnswers.TabIndex = 9;
            // 
            // answerTools1
            // 
            answerTools.BackColor = SystemColors.ControlLight;
            answerTools.Dock = DockStyle.Top;
            answerTools.Location = new Point(0, 0);
            answerTools.Name = "answerTools1";
            answerTools.Size = new Size(379, 35);
            answerTools.TabIndex = 3;
            // 
            // btNew
            // 
            btNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btNew.Location = new Point(398, 209);
            btNew.Name = "btNew";
            btNew.Size = new Size(140, 34);
            btNew.TabIndex = 8;
            btNew.Text = "Nowe pytanie";
            btNew.UseVisualStyleBackColor = true;
            btNew.Click += btNew_Click;
            // 
            // QuestionSegment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(btNew);
            Controls.Add(pnViusalBg);
            Controls.Add(lbAutoTitle);
            Controls.Add(cbxPlusPoints);
            Controls.Add(cbxMinusPoints);
            Controls.Add(tbxMinusPoints);
            Controls.Add(tbxPlusPoints);
            Controls.Add(btnDelete);
            Controls.Add(tbxTitle);
            Name = "QuestionSegment";
            Size = new Size(544, 249);
            pnViusalBg.ResumeLayout(false);
            pnAnswers.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxTitle;
        private Button btnDelete;
        private TextBox tbxPlusPoints;
        private TextBox tbxMinusPoints;
        private CheckBox cbxMinusPoints;
        private CheckBox cbxPlusPoints;
        private Label lbAutoTitle;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnUp;
        private Button btnDown;
        private Panel pnViusalBg;
        private Button btNew;
        private Panel pnAnswers;
        private AnswerTools answerTools;
    }
}
