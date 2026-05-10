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
            pnAnswers = new Panel();
            SuspendLayout();
            // 
            // tbxTitle
            // 
            tbxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxTitle.Location = new Point(3, 43);
            tbxTitle.Name = "tbxTitle";
            tbxTitle.Size = new Size(538, 23);
            tbxTitle.TabIndex = 0;
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
            // 
            // tbxPlusPoints
            // 
            tbxPlusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbxPlusPoints.Location = new Point(398, 72);
            tbxPlusPoints.Name = "tbxPlusPoints";
            tbxPlusPoints.Size = new Size(67, 23);
            tbxPlusPoints.TabIndex = 2;
            tbxPlusPoints.TextChanged += txbPlusPoints_TextChanged;
            // 
            // tbxMinusPoints
            // 
            tbxMinusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbxMinusPoints.Location = new Point(398, 101);
            tbxMinusPoints.Name = "tbxMinusPoints";
            tbxMinusPoints.Size = new Size(67, 23);
            tbxMinusPoints.TabIndex = 3;
            // 
            // cbxMinusPoints
            // 
            cbxMinusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxMinusPoints.AutoSize = true;
            cbxMinusPoints.Location = new Point(471, 103);
            cbxMinusPoints.Name = "cbxMinusPoints";
            cbxMinusPoints.Size = new Size(67, 19);
            cbxMinusPoints.TabIndex = 6;
            cbxMinusPoints.Text = "Ujemne";
            cbxMinusPoints.UseVisualStyleBackColor = true;
            // 
            // cbxPlusPoints
            // 
            cbxPlusPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxPlusPoints.AutoSize = true;
            cbxPlusPoints.Location = new Point(471, 74);
            cbxPlusPoints.Name = "cbxPlusPoints";
            cbxPlusPoints.Size = new Size(63, 19);
            cbxPlusPoints.TabIndex = 7;
            cbxPlusPoints.Text = "Punkty";
            cbxPlusPoints.UseVisualStyleBackColor = true;
            // 
            // lbAutoTitle
            // 
            lbAutoTitle.AutoSize = true;
            lbAutoTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbAutoTitle.Location = new Point(3, 3);
            lbAutoTitle.Name = "lbAutoTitle";
            lbAutoTitle.Size = new Size(101, 30);
            lbAutoTitle.TabIndex = 8;
            lbAutoTitle.Text = "Pytanie 0";
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUp.Location = new Point(398, 130);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(140, 34);
            btnUp.TabIndex = 10;
            btnUp.Text = "W górę";
            btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDown.Location = new Point(398, 170);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(140, 34);
            btnDown.TabIndex = 11;
            btnDown.Text = "W dół";
            btnDown.UseVisualStyleBackColor = true;
            // 
            // pnAnswers
            // 
            pnAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnAnswers.AutoScroll = true;
            pnAnswers.BackColor = SystemColors.GradientActiveCaption;
            pnAnswers.Location = new Point(3, 72);
            pnAnswers.Name = "pnAnswers";
            pnAnswers.Size = new Size(389, 132);
            pnAnswers.TabIndex = 12;
            // 
            // QuestionSegment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(pnAnswers);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(lbAutoTitle);
            Controls.Add(cbxPlusPoints);
            Controls.Add(cbxMinusPoints);
            Controls.Add(tbxMinusPoints);
            Controls.Add(tbxPlusPoints);
            Controls.Add(btnDelete);
            Controls.Add(tbxTitle);
            Name = "QuestionSegment";
            Size = new Size(544, 210);
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
        private Panel pnAnswers;
    }
}
