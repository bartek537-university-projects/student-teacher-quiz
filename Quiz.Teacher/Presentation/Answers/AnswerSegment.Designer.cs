namespace QuizApp.Teacher.Presentation.Main
{
    partial class AnswerSegment
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
            cbxIsCorrect = new CheckBox();
            SuspendLayout();
            // 
            // tbxTitle
            // 
            tbxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxTitle.Location = new Point(6, 6);
            tbxTitle.Margin = new Padding(6);
            tbxTitle.Name = "tbxTitle";
            tbxTitle.Size = new Size(294, 23);
            tbxTitle.TabIndex = 1;
            tbxTitle.TextChanged += tbxTitle_TextChanged;
            // 
            // cbxIsCorrect
            // 
            cbxIsCorrect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbxIsCorrect.AutoSize = true;
            cbxIsCorrect.Location = new Point(309, 8);
            cbxIsCorrect.Margin = new Padding(3, 3, 6, 3);
            cbxIsCorrect.Name = "cbxIsCorrect";
            cbxIsCorrect.Size = new Size(79, 19);
            cbxIsCorrect.TabIndex = 2;
            cbxIsCorrect.Text = "Poprawna";
            cbxIsCorrect.UseVisualStyleBackColor = true;
            cbxIsCorrect.CheckedChanged += cbxIsCorrect_CheckedChanged;
            // 
            // AnswerSegment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(cbxIsCorrect);
            Controls.Add(tbxTitle);
            Name = "AnswerSegment";
            Size = new Size(394, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxTitle;
        private Button button1;
        private CheckBox cbxIsCorrect;
    }
}
