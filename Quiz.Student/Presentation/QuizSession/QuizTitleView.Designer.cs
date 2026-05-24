namespace QuizApp.Student.Presentation.QuizSession
{
    partial class QuizTitleView
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
            lbTitle = new Label();
            lbQuizId = new Label();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Segoe UI", 12F);
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Padding = new Padding(0, 12, 0, 0);
            lbTitle.Size = new Size(144, 33);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Loading your quiz...";
            // 
            // lbQuizId
            // 
            lbQuizId.AutoSize = true;
            lbQuizId.Dock = DockStyle.Top;
            lbQuizId.ForeColor = SystemColors.ActiveBorder;
            lbQuizId.Location = new Point(0, 33);
            lbQuizId.Name = "lbQuizId";
            lbQuizId.Padding = new Padding(0, 4, 0, 0);
            lbQuizId.Size = new Size(219, 19);
            lbQuizId.TabIndex = 1;
            lbQuizId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // QuizTitleView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbQuizId);
            Controls.Add(lbTitle);
            Name = "QuizTitleView";
            Size = new Size(256, 128);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Label lbQuizId;
    }
}
